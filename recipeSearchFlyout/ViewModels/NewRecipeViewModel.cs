using System;
using System.Diagnostics;
using recipeSearchFlyout.Models;
using Xamarin.Forms;

namespace recipeSearchFlyout.ViewModels
{
    public class NewRecipeViewModel : BaseViewModel
    {
        string _recipeName;
        string _imageUrl;
        string _ingredients;
        string _recipeBody;
        FormattedString _recipeUrl;

        public NewRecipeViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_recipeName);
        }

        public string RecipeName
        {
            get => _recipeName;
            set => SetProperty(ref _recipeName, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        public string Ingredients
        {
            get => _ingredients;
            set => SetProperty(ref _ingredients, value);
        }

        public string RecipeBody
        {
            get => _recipeBody;
            set => SetProperty(ref _recipeBody, value);
        }

        public FormattedString RecipeUrl
        {
            get => _recipeUrl;
            set => SetProperty(ref _recipeUrl, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private void OnCancel()
        {
            MessagingCenter.Send(this, "PopOffCurrentModal");
        }

        private async void OnSave()
        {
            Item newRecipe = new()
            {
                Id = Guid.NewGuid().ToString(),
                RecipeName = RecipeName,
                ImageUrl = ImageUrl,
                Ingredients = Ingredients,
                RecipeBody = RecipeBody,
                RecipeUrl = RecipeUrl
            };

            await DataStore.AddRecipeAsync(newRecipe);

            MessagingCenter.Send(this, "PopOffCurrentModal");
        }
    }
}
