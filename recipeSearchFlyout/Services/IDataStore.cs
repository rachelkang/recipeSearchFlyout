using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipeSearchFlyout.Services
{
	public interface IDataStore<T>
	{
		Task<bool> AddRecipeAsync(T item);
		Task<bool> UpdateRecipeAsync(T item);
		Task<bool> DeleteRecipeAsync(string id);
		Task<T> GetRecipeAsync(string id);
		Task<IEnumerable<T>> GetRecipesAsync(bool forceRefresh = false);
	}
}
