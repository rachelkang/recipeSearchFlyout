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
		RecipeDetailViewModel viewModel;

		public RecipeDetailPage(RecipeDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}

		public RecipeDetailPage()
		{
			InitializeComponent();
		}
	}
}