using System.Text.Json;

namespace Web.Models
{
    public class BasketModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CookieKey = "Basket";

        public BasketModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Dictionary<int, int> Get(string userId)
        {
            var kay = $"{CookieKey}-{userId}";
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies[kay];
            var basket = cookie != null ? JsonSerializer.Deserialize<Dictionary<int, int>>(cookie) : new Dictionary<int, int>();
            return basket;
        }

        public void Update(string userId, Dictionary<int, int> basket)
        {
            Save(userId, basket);
        }

        private void Save(string userId, Dictionary<int, int> basket)
        {
            var key = $"{CookieKey}-{userId}";
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            var jsonBasket = JsonSerializer.Serialize(basket);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, jsonBasket, options);
        }
    }
}
