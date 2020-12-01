using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class SearchResultsPage : ContentPage
	{
		SearchResultsViewModel _viewModel;

		public SearchResultsPage(string searchQuery)
		{
			MessagingCenter.Send(this, "ShowRecipeHits", searchQuery);
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.SearchCommand.Execute(null);
		}
	}
}