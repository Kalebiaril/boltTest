using Newtonsoft.Json.Converters;
using SearchWebApi.Enums;
using System;
using System.Text.Json.Serialization;

namespace SearchWebApi.DB
{
    public class SearchDataModel
    {
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
