namespace Sdt.Practice.Application.Dto
{
    public class PageRequest
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageCount { get; set; } = 20;
    }
}