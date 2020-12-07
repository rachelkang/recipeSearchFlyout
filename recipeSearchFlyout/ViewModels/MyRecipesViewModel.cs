using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using recipeSearchFlyout.Models;
using recipeSearchFlyout.Views;

namespace recipeSearchFlyout.ViewModels
{
	public class MyRecipesViewModel : BaseViewModel
	{
        public Item _selectedRecipe;

        public ObservableCollection<Item> Recipes { get; }
        public Command LoadRecipesCommand { get; }
        public Command NewRecipeCommand { get; }
        public Command<Item> RecipeTapped { get; }

        public MyRecipesViewModel()
        {
            Title = "Recipes";
			Recipes = new ObservableCollection<Item>();
            LoadRecipesCommand = new Command(async () => await ExecuteLoadItemsCommand());

			RecipeTapped = new Command<Item>(OnRecipeSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Recipes.Clear();
                var recipes = await DataStore.GetRecipesAsync(true);
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedRecipe = null;

            //await ExecuteLoadItemsCommand();
            LoadRecipesCommand.Execute(null);
        }

        public Item SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                SetProperty(ref _selectedRecipe, value);
                OnRecipeSelected(value);
            }
        }

        void OnRecipeSelected(Item recipe)
        {
            if (recipe == null)
                return;

            MessagingCenter.Send(this, "SelectMyRecipe", recipe.Id);
        }
    }
}