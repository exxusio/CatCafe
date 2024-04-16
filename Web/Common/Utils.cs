namespace Web.Common
{
    public static class Utils
    {
        public static async Task<byte[]> ConvertImageToBase64(IFormFile photography)
        {
            using (var memoryStream = new MemoryStream())
            {
                await photography.CopyToAsync(memoryStream);
                byte[] photographyBytes = memoryStream.ToArray();

                return photographyBytes;
            }
        }
    }
}
