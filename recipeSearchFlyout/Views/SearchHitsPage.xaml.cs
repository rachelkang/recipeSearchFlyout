﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class SearchHitsPage : ContentPage
	{
		SearchHitsViewModel _viewModel;

		string[] _searchParams;

		public SearchHitsPage(string[] searchParams)
		{
			InitializeComponent();
			BindingContext = _viewModel = new SearchHitsViewModel();

			_searchParams = searchParams;

			MessagingCenter.Subscribe<SearchHitsViewModel, string>(this, MessageStrings.SelectRecipeHit, async (sender, hitId) =>
			{
				await Navigation.PushAsync(new HitDetailPage(hitId));
			});
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_viewModel.SearchQuery != null)
			{
				_searchParams[0] = _viewModel.SearchQuery;
			}

			_viewModel.SearchCommand.Execute(_searchParams);
		}
	}
}