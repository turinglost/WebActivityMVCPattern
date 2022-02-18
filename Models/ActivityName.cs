using System.ComponentModel.DataAnnotations;

namespace WebActivityMVCPattern.Models
{
    public class ActivityName
    {
        public ActivityName(string name)
        {
            Name = name;
        }

        [Key]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
