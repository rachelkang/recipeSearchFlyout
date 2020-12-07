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
		MyRecipesViewModel _viewModel;

		public MyRecipesPage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new MyRecipesViewModel();

			MessagingCenter.Subscribe<MyRecipesViewModel, string>(this, "SelectRecipe", async (sender, id) =>
			{
				await Navigation.PushAsync(new RecipeDetailPage(id));
			});

			MessagingCenter.Subscribe<EditRecipeViewModel>(this, "RemoveDeletedRecipePage", (sender) =>
			{
				Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
			});
		}

		async void NewRecipe_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewRecipePage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();

			if (_viewModel.Recipes.Count == 0)
				_viewModel.IsBusy = true;
		}
	}
}