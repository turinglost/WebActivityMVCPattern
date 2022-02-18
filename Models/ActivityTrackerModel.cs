using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebActivityMVCPattern.Models
{
    public class ActivityTrackerModel
    {
        List<SelectListItem> _activityDropDownList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        List<string> _activityTypes;

        public ActivityTrackerModel()
        {
            ActivityTypes = new List<string>();
            CurrentActivity = new ActivityModel();
            SavedActivities = new List<ActivityModel>();
        }

        public ActivityModel CurrentActivity { get; set; }
        public ActivityModel LastActivity { get; set; }
        public int ActivityCount { get; set; }
        public List<ActivityModel> SavedActivities { get; set; }
        public List<string> ActivityTypes { get { return _activityTypes; }
            set { 
                _activityTypes = value;
                _activityDropDownList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

                foreach(string s in _activityTypes)
                {
                    _activityDropDownList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(s, s));
                }
            }
        }

        public System.Collections.Generic.IEnumerable<SelectListItem> ActivityTypesDropDown
        {
            get {
                return _activityDropDownList;
            }
        }

    }
}
