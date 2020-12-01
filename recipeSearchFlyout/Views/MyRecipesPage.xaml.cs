using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.Views;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class MyRecipesPage : ContentPage
	{
		MyRecipesViewModel viewModel;

		public MyRecipesPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new MyRecipesViewModel();
		}

		async void OnItemSelected(object sender, EventArgs args)
		{
			var layout = (BindableObject)sender;
			var item = (Item)layout.BindingContext;
			await Navigation.PushAsync(new RecipeDetailPage(new RecipeDetailViewModel(item)));
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new NewRecipePage()));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.IsBusy = true;
		}
	}
}