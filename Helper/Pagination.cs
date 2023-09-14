namespace QuanLyPhanTuWeb.Helper
{
    public class Pagination<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage
        {
            get
            {
                if (PageSize <= 0) return 1;
                var total = TotalCount / PageSize;
                if (TotalCount % PageSize > 0) return total += 1;
                return total;
            }
        }
        public IQueryable<T> Data { get; set; }

    }
}
