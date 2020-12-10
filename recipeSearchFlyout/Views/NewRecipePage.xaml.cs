using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;
using recipeSearchFlyout.ViewModels;

namespace recipeSearchFlyout.Views
{
	public partial class NewRecipePage : ContentPage
	{
        public Recipe Recipe { get; set; }

        public NewRecipePage()
        {
            InitializeComponent();
            BindingContext = new NewRecipeViewModel();

            MessagingCenter.Subscribe<NewRecipeViewModel>(this, MessageStrings.PopOffCurrentModal, async (sender) =>
            {
                await Navigation.PopModalAsync();
            });
        }
    }
}