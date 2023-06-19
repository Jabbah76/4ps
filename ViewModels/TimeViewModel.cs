using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Input;

using _4ps.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _4ps.ViewModels
{
    public partial class TimeViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<TimeOff> timeOffList;

        public bool HasOverlappingDates
        {
            get
            {
                //foreach (var timeOff in TimeOffList)
                for (int counter1 = 0; counter1 < TimeOffList.Count - 1; counter1++)
                {
                    //foreach (var timeOffToCompare in TimeOffList)
                    for (int counter2 = counter1 + 1; counter2 < TimeOffList.Count; counter2++)
                    {
                        if (TimeOffList[counter1].StartDate <= TimeOffList[counter2].EndDate && TimeOffList[counter2].StartDate <= TimeOffList[counter1].EndDate)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public TimeViewModel()
        {
            TimeOffList = new ObservableCollection<TimeOff>
            {
                { new TimeOff { Name = "Medewerker A", StartDate = DateTime.Now, EndDate = DateTime.Now } },
                { new TimeOff { Name = "Medewerker B", StartDate = DateTime.Now, EndDate = DateTime.Now } },
                { new TimeOff { Name = "Medewerker C", StartDate = DateTime.Now, EndDate = DateTime.Now } },
                { new TimeOff { Name = "Medewerker D", StartDate = DateTime.Now, EndDate = DateTime.Now } }
            };
        }

        [RelayCommand]
        public async Task CheckOverlap()
        {
            if (HasOverlappingDates)
            {
                await Application.Current.MainPage.DisplayAlert("Popup", "Overlappende periodes gevonden.", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Popup", "Alles OK.", "OK");
            }
        }
    }
}
