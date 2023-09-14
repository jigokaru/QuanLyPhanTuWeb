using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace QuanLyPhanTuWeb.Helper
{
    public class uplloadFile
    {
        static string cloudName = "dxd5phqje";
        static string apiKey = "893454761776484";
        static string apiSecret = "em3TvWsa2GDC0bKldF-w356y_8w";
        static private readonly Random rnd = new Random();

        static public Account account = new Account(cloudName, apiKey, apiSecret);
        static public Cloudinary _cloudinary = new Cloudinary(account);
        public static async Task<string> UploadFile(IFormFile? file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file selected.");
            }

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = "xyz-abc" + "_" + DateTime.Now.Ticks + "image",// ID công khai tùy ý cho file phải tuyệt đối là không được giống nhau
                                                                              //Transformation = new Transformation().Width(400).Height(400).Crop("fill") // Cố định kích thước ảnh thành tỷ lệ 3*4 pixel
                };

                var uploadResult = await uplloadFile._cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    // Xử lý lỗi tải lên
                    throw new Exception(uploadResult.Error.Message);
                }

                // Lấy URL công khai của file tải lên
                string imageUrl = uploadResult.SecureUrl.ToString();

                // Tiếp tục xử lý hoặc lưu thông tin về file trong cơ sở dữ liệu


                return imageUrl;
            }
        }
    }
}
