using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using recipeSearchFlyout.ViewModels;
using Color = Xamarin.Forms.Color;
using System;

namespace recipeSearchFlyout.Views
{
	public partial class HitDetailPage : ContentPage
	{

		HitDetailViewModel _viewModel;
		Color primary = Color.FromHex("#2BB0ED");
		string alertMessage = "This recipe has been added to your personal recipe collection! Go to the 'My Recipes' tab to view and modify this recipe from there :)";

		public HitDetailPage(string hitId)
		{
			InitializeComponent();
			BindingContext = _viewModel = new HitDetailViewModel();

			_viewModel.HitId = hitId;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			var messageOptions = new MessageOptions
			{
				Foreground = primary,
				FontSize = 7,
				Message = alertMessage
			};

			var actionOptions = new List<SnackBarActionOptions>
			{
				new SnackBarActionOptions
				{
					ForegroundColor = Color.White,
					BackgroundColor = primary,
					FontSize = 7
				}
			};

			var options = new SnackBarOptions
			{
				MessageOptions = messageOptions,
				Duration = TimeSpan.FromMilliseconds(5000),
				BackgroundColor = primary,
				IsRtl = false,
				Actions = actionOptions
			};

			await this.DisplaySnackBarAsync(options);
		}
	}
}