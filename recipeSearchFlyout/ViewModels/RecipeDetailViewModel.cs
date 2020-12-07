using System;
using System.Diagnostics;
using recipeSearchFlyout.Models;
using Xamarin.Forms;

namespace recipeSearchFlyout.ViewModels
{
    public class RecipeDetailViewModel : BaseViewModel
    { 
        string _recipeId;
        string _recipeName;
        string _imageUrl;
        string _ingredients;
        string _recipeBody;
        FormattedString _recipeUrl;

        bool _recipeNameVisible;
        bool _imageUrlVisible;
        bool _ingredientsVisible;
        bool _recipeBodyVisible;
        bool _recipeUrlVisible;

        public string Id { get; set; }

        public RecipeDetailViewModel()
        {
            RecipeNameVisible = true;
            ImageUrlVisible = true;
            IngredientsVisible = true;
            RecipeBodyVisible = true;
            RecipeUrlVisible = true;
        }

        public string RecipeId
        {
            get
            {
                return _recipeId;
            }
            set
            {
                if (value == null)
                    return;

                _recipeId = value;
                LoadItemId(value);
            }
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

        public bool RecipeNameVisible
        {
            get => _recipeNameVisible;
            set => SetProperty(ref _recipeNameVisible, value);
        }

        public bool ImageUrlVisible
        {
            get => _imageUrlVisible;
            set => SetProperty(ref _imageUrlVisible, value);
        }

        public bool IngredientsVisible
        {
            get => _ingredientsVisible;
            set => SetProperty(ref _ingredientsVisible, value);
        }

        public bool RecipeBodyVisible
        {
            get => _recipeBodyVisible;
            set => SetProperty(ref _recipeBodyVisible, value);
        }

        public bool RecipeUrlVisible
        {
            get => _recipeUrlVisible;
            set => SetProperty(ref _recipeUrlVisible, value);
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetRecipeAsync(itemId);
                Id = item.Id;
                RecipeName = item.RecipeName;
                ImageUrl = item.ImageUrl;
                Ingredients = item.Ingredients;
                RecipeBody = item.RecipeBody;
                RecipeUrl = item.RecipeUrl;

                Title = RecipeName;

                var emptyFormattedString = new FormattedString();
                emptyFormattedString.Spans.Add(new Span { Text = "" });

                RecipeNameVisible = !String.IsNullOrEmpty(RecipeName);
                ImageUrlVisible = !String.IsNullOrEmpty(ImageUrl);
                IngredientsVisible = !String.IsNullOrEmpty(Ingredients);
                RecipeBodyVisible = !String.IsNullOrEmpty(RecipeBody);
                RecipeUrlVisible = !(RecipeUrl == null || FormattedString.Equals(RecipeUrl, emptyFormattedString));

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            LoadItemId(_recipeId);
        }
    }
}
