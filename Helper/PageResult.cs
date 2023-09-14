namespace QuanLyPhanTuWeb.Helper
{
    public class PageResult<T>
    {
        public IQueryable<T>? Data { get; set; }
        public PageResult() { }
        

        public static Pagination<T> ToPageResult(IQueryable<T> query,int pageNumber,
                                                int pageSize)
        {
            if (pageSize > 0)
            {
                //pageNumber = pageNumber < 1 ? 1 : pageNumber;
                //query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                int totalItems = query.Count();
                int totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                return new Pagination<T>
                {
                    Data = query,
                    TotalCount = totalItems,
                    PageSize = pageSize,
                    PageNumber = pageNumber,
                };

            }
            return ToPageResult(query, pageNumber, pageSize);
            
        }
    }
}
