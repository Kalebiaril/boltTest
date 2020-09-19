using SearchWebApi.Enums;
using System;

namespace SearchWebApi.DB
{
    public class SearchData
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SearchEngine SearchEngine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Request { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EnteredDate { get; set; }
    }
}
