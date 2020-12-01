using System;
using System.ComponentModel;
using recipeSearchFlyout.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipeSearchFlyout.Views
{
	public partial class RecipeSearchPage : ContentPage
	{
		public RecipeSearchPage()
		{
			InitializeComponent();

			MessagingCenter.Subscribe<RecipeSearchViewModel, string>(this, "SearchRecipe", async (sender, searchQuery) =>
			{
				await Navigation.PushAsync(new SearchResultsPage(searchQuery));
			});

		}
	}
}