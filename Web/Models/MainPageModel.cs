using PresentationLayer.Models;

namespace Web.Models
{
    public class MainPageModel
    {
        public ICollection<ViewEvents> Events { get; set; }

        public ICollection<ViewProducts> PopularProducts { get; set; }
    }
}
