using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using recipeSearchFlyout.Services;
using recipeSearchFlyout.Views;
using recipeSearchFlyout.Models;

namespace recipeSearchFlyout
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			MainPage = new MainPage();

			//MainPage = new NavigationPage(new MainPage());
		}

		public static RecipeData Data { get; set; }

		public static Models.Recipe[] MyRecipes { get; set; }

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
