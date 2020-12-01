using System;
using Xamarin.Forms;

namespace recipeSearchFlyout.Models
{
	public class Recipe
	{
        public string Id { get; set; }
        public string RecipeName { get; set; }
        public string ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string RecipeBody { get; set; }
        public FormattedString RecipeUrl { get; set; }
    }
}