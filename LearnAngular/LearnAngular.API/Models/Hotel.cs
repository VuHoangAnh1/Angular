using System.ComponentModel.DataAnnotations;

namespace LearnAngular.API.Models
{
    public class Hotel
    {
        [Key]
        public Guid Id { get; set; }
        public string HotelsName { get; set; }
        public string HotelsAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
    }
}
