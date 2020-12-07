using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class EditRecipePage : ContentPage
	{
        EditRecipeViewModel _viewModel;

        public EditRecipePage(string id)
        {
            InitializeComponent();
            BindingContext = _viewModel = new EditRecipeViewModel();

            _viewModel.Id = id;

			MessagingCenter.Subscribe<EditRecipeViewModel>(this, "PopOffCurrentModal", async (sender) =>
            {
                await Navigation.PopModalAsync();
            });        }

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
            MessagingCenter.Unsubscribe<EditRecipeViewModel>(this, "PopOffCurrentModal");
            MessagingCenter.Unsubscribe<EditRecipeViewModel>(this, "RemoveDeletedRecipePage");
        }
	}
}