namespace WebActivityMVCPattern.Models
{
    public class ActivityModel
    {
        public ActivityModel()
        {

        }
        public int Id { get; set; }
        public DateTime ActivityStarted { get; set; }
        public int ActivityDurationMinutes { get; set; }
        public string ActivityType { get; set; }
        public string ActivityComments { get; set; }
    }
}
