namespace B2BSalonAPI.Configuration
{
    public class GlobalData
    {
        public string urlreplace(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return name.Replace(" ", "-");
            }
            else
            {
                return "";
            }
        }
        public string GenerateOTP()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            int otp = _rdm.Next(_min, _max);
            return otp.ToString();
        }
        public async Task<string> SaveImage(IFormFile ImageFile, IWebHostEnvironment _webHostEnvironment)
        {
            string ImageName = new string(Path.GetFileNameWithoutExtension(ImageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            ImageName = ImageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(ImageFile.FileName);
            var ImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "SalonImages", ImageName);
            using (var fileStream = new FileStream(ImagePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }
            return ImageName;
        }
    }
}
