using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class Token
    {
        [Key]
        public int? Id { get; set; }
        public string? stoken { get; set; }
        private DateTime? _expiresAt = DateTime.Now.AddSeconds(10);
        public DateTime? expiresAt
        {
            get { return _expiresAt; }
            set
            {
                _expiresAt = value;
                if (_expiresAt.HasValue)
                {
                    if (_expiresAt.Value < DateTime.Now)
                    {
                        expired = true;
                        revoked = true;
                    }
                    else
                    {
                        expired = false;
                        revoked = false;
                        Task.Run(async () =>
                        {
                            await Task.Delay((_expiresAt.Value - DateTime.Now));
                            expired = true;
                            revoked = true;
                        });
                    }
                }
                else
                {
                    expired = false;
                    revoked = false;
                }
            }
        }


        public bool? expired { get; private set; }

        public bool? revoked { get; private set; }

        public string? token_type { get; set; }
        public int? phatTuId { get; set; }
        public PhanTu? phatTu { get; set; }
    }
}
