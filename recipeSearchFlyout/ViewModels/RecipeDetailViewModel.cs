using System;

using recipeSearchFlyout.Models;

namespace recipeSearchFlyout.ViewModels
{
	public class RecipeDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public RecipeDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = item;
		}
	}
}
