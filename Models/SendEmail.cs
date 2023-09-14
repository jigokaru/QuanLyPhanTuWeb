namespace QuanLyPhanTuWeb.Models
{
    public class SendEmail
    {
        public static string temlapteHtmlMail(string code)
        {
            string htmlContent = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset=""utf-8"" />
            <title></title>
        </head>
        <body>
            <h1>đổi mật khẩu</h1>
            <a>mã code của bạn là: {code}</a>
        </body>
        </html>";
            return htmlContent;
        }
    }
}
