using ComedorComunitario.Data.ViewModel;

namespace ComedorComunitario.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}