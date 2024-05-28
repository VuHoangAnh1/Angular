using System.ComponentModel.DataAnnotations;

namespace LearnAngular.API.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
