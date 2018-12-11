using System.Collections.Generic;

namespace Sdt.Practice.Application.Countries.Dto
{
    public class PagedResponse<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int ItemCount { get; set; }

        public IEnumerable<T> Payload { get; set; }
    }
}