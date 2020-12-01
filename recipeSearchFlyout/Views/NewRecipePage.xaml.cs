using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using recipeSearchFlyout.Models;

namespace recipeSearchFlyout.Views
{
	public partial class NewRecipePage : ContentPage
	{
		public Item Item { get; set; }

		public NewRecipePage()
		{
			InitializeComponent();
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopModalAsync();
		}

		async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}