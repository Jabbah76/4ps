using CommunityToolkit.Mvvm.ComponentModel;

namespace _4ps.Models
{
    public partial class TimeOff : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public DateTime startDate;

        [ObservableProperty]
        public DateTime endDate;
    }
}
