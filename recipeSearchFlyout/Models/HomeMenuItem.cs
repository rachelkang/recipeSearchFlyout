using System;
using System.Collections.Generic;
using System.Text;

namespace recipeSearchFlyout.Models
{
	public enum MenuItemType
	{
		RecipeSearch,
		MyRecipes
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
