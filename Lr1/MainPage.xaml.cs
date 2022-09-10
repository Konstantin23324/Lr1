using Lr1.ViewModel;

namespace Lr1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        InitializeComponent();
        BindingContext = new AnimalViewModel();
    }
}

