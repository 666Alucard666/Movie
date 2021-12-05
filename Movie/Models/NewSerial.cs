using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Movie.Models
{
    public class NewSerialData
    {
        public List<NewSerialDataDetail> Items { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class NewSerialDataDetail
    {
        public string Id { get; set; }
        public string SerialTitle { set; get; }
        public string EpisodeNumber { set; get; }
        public string EpisodeTitle { set; get; }
        public string Year { set; get; }
        public string ReleaseState { set; get; }
    }
}
