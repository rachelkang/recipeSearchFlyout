using System;
using System.Diagnostics;
using recipeSearchFlyout.Models;
using Xamarin.Forms;

namespace recipeSearchFlyout.ViewModels
{
    public class EditRecipeViewModel : BaseViewModel
    {
        string _id;
        string _recipeName;
        string _ingredients;
        string _imageUrl;
        string _recipeBody;
        FormattedString _recipeUrl;

        public EditRecipeViewModel()
        {
            UpdateCommand = new Command(OnUpdate, ValidateUpdate);
            DeleteCommand = new Command(OnDelete);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => UpdateCommand.ChangeCanExecute();
            this.PropertyChanged +=
                (_, __) => DeleteCommand.ChangeCanExecute();
        }

        private bool ValidateUpdate()
        {
            return !String.IsNullOrWhiteSpace(_recipeName);
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                LoadItemId(value);
            }
        }

        public string RecipeName
        {
            get => _recipeName;
            set => SetProperty(ref _recipeName, value);
        }

        public string Ingredients
        {
            get => _ingredients;
            set => SetProperty(ref _ingredients, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
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

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetRecipeAsync(itemId);
                RecipeName = item.RecipeName;
                Ingredients = item.Ingredients;
                ImageUrl = item.ImageUrl;
                RecipeBody = item.RecipeBody;
                RecipeUrl = item.RecipeUrl;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public Command UpdateCommand { get; }
        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }

        private void OnCancel()
        {
            MessagingCenter.Send(this, MessageStrings.PopOffCurrentModal);
        }

        private async void OnDelete()
        {
            await DataStore.DeleteRecipeAsync(_id);

			MessagingCenter.Send(this, MessageStrings.RemoveDeletedRecipePage);
			MessagingCenter.Send(this, MessageStrings.PopOffCurrentModal);
        }

        private async void OnUpdate()
        {
            Item newItem = new Item()
            {
                Id = _id,
                RecipeName = RecipeName,
                Ingredients = Ingredients,
                ImageUrl = ImageUrl,
                RecipeBody = RecipeBody,
                RecipeUrl = RecipeUrl
            };

            await DataStore.UpdateRecipeAsync(newItem);

            MessagingCenter.Send(this, MessageStrings.PopOffCurrentModal);
        }
    }
}
