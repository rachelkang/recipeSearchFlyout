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

		string[] _searchParams;

		public SearchResultsPage(string[] searchParams)
		{
			// MessagingCenter.Send(this, "ShowRecipeHits", searchParams);

			InitializeComponent();
			BindingContext = _viewModel = new SearchResultsViewModel();

			//_viewModel.SearchQuery = searchParams[0];
			//_viewModel.SearchFilter = searchParams[1];

			_searchParams = searchParams;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.SearchCommand.Execute(_searchParams);
		}
	}
}