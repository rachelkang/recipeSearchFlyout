using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class RecipeDetailPage : ContentPage
	{
        RecipeDetailViewModel _viewModel;
        string _recipeId;

        public RecipeDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecipeDetailViewModel();

            _viewModel.RecipeId = id;
            _recipeId = id;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async void EditRecipe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditRecipePage(_recipeId));
        }
	}
}