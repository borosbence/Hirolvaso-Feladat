using Hirolvaso.ViewModels;

namespace Hirolvaso.Views;

public partial class HirekPage : ContentPage
{
    public HirekPage(HirekViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}