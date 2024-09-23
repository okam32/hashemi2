using System.ComponentModel.DataAnnotations;

namespace hashemi2.Core.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string CanditorName { get; set; }
        public string EventName { get; set; }
        public string Date { get; set; }
        public string EventType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Details { get; set; }
        public string Description { get; set; } 

        public List<Request> Requset { get; set; }
    }
}
