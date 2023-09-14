using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using QuanLyPhanTuWeb.Iservices;
using QuanLyPhanTuWeb.Models;

namespace QuanLyPhanTuWebWeb.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext appDbContext;

        
        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
            appDbContext = new AppDbContext();
        }

        public string sendEmail(string email)
        {
            TokenResetPassword tokenResetPassword = appDbContext.TokenResetPassword.FirstOrDefault(x => x.emailToken ==  email);
            if (tokenResetPassword == null)
            {
                return "khong tim thấy email đăng kí!";
            }
            else
            {
                var Message = new MimeMessage();
                Message.From.Add(MailboxAddress.Parse("hoanganh.110201@gmail.com"));
                Message.To.Add(MailboxAddress.Parse(email));
                Message.Subject = "hello";
                Message.Body = new TextPart(TextFormat.Html)
                {
                    Text =  SendEmail.temlapteHtmlMail(tokenResetPassword.PasswordResetToken)

            };
                using var smtp = new SmtpClient();
                smtp.Connect(_configuration.GetSection("EmailHost").Value, 465, SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.Send(Message);
                smtp.Disconnect(true);
                return "vui lòng kiểm tra email!";
            }
           
        }
    }
}
