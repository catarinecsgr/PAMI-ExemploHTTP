using ExemploHTTP.ViewModels;

namespace ExemploHTTP.Views;

public partial class PostagensView : ContentPage
{
	public PostagensView()
	{
        BindingContext = new PostagemViewModel();
		InitializeComponent();
    }
}