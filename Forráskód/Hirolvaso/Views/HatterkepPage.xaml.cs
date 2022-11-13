using Hirolvaso.ViewModels;

namespace Hirolvaso.Views;

public partial class HatterkepPage : ContentPage
{
    public HatterkepPage(HatterkepViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}