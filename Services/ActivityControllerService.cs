using WebActivityMVCPattern.Models;

namespace WebActivityMVCPattern.Services
{

    public class ActivityControllerService
    {
        static ActivityTrackerModel _activityTrackerData;

        public ActivityControllerService()
        {
            _activityTrackerData = new ActivityTrackerModel();

            _activityTrackerData.ActivityTypes.Add("Biking");
            _activityTrackerData.ActivityTypes.Add("Snowboarding");

            _activityTrackerData.SavedActivities.Add(new ActivityModel { ActivityType = "Biking", ActivityStarted = new DateTime(2022, 2, 10, 14, 50, 5), ActivityDurationMinutes = 20 });
            _activityTrackerData.SavedActivities.Add(new ActivityModel { ActivityType = "Snowboarding", ActivityStarted = new DateTime(2022, 2, 14, 12, 25, 5), ActivityDurationMinutes = 35 });


        }

        public ActivityTrackerModel GetFullModel()
        {
            return _activityTrackerData;
        }
    }
}
