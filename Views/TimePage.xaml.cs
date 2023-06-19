using _4ps.ViewModels;

namespace _4ps.Views;

public partial class TimePage : ContentPage
{
	public TimePage(TimeViewModel timeViewModel)
    {
		InitializeComponent();

		BindingContext = timeViewModel;
	}
}