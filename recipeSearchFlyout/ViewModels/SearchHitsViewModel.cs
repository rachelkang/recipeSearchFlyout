using System;
using System.Threading.Tasks;
using System.Windows.Input;
using recipeSearchFlyout.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace recipeSearchFlyout.ViewModels
{
	public class SearchHitsViewModel : BaseViewModel
	{
        RestService _restService;

        RecipeData _recipeData;
        string _searchQuery;
        string _noResultsLabel;
        bool _noResultsLabelVisible;
        bool _searchResultsVisible;

        public Command<Hit> ItemTapped { get; }
        public Command<string[]> SearchCommand { get; }

        public SearchHitsViewModel()
        {
            Title = "Search all recipes";
            _restService = new RestService();
            NoResultsLabelVisible = false;
            SearchResultsVisible = true;

            ItemTapped = new Command<Hit>(OnItemSelected);
            SearchCommand = new Command<string[]>(async (searchParams) => {
                if (searchParams != null)
				{
                    SearchQuery = searchParams[0];
                    SearchFilter = searchParams[1];
                }
                await OnSearch();
            });
        }

        public RecipeData RecipeData
        {
            get => _recipeData;
            set => SetProperty(ref _recipeData, value);
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set => SetProperty(ref _searchQuery, value);
        }

        public string SearchFilter { get; set; }

        public string NoResultsLabel
        {
            get => _noResultsLabel;
            set => SetProperty(ref _noResultsLabel, value);
        }

        public bool NoResultsLabelVisible
        {
            get => _noResultsLabelVisible;
            set => SetProperty(ref _noResultsLabelVisible, value);
        }

        public bool SearchResultsVisible
        {
            get => _searchResultsVisible;
            set => SetProperty(ref _searchResultsVisible, value);
        }

        async Task OnSearch()
        {
            NoResultsLabelVisible = false;

            if (!string.IsNullOrWhiteSpace(SearchQuery) || !string.IsNullOrWhiteSpace(SearchFilter))
            {
                RecipeData recipeData = await _restService.GetRecipeDataAsync(GenerateRequestUri(Constants.EdamamEndpoint));

                if (recipeData == null || recipeData.Hits.Length == 0)
                {
                    NoResultsLabel = $"Sorry - we couldn't find any recipes for {SearchQuery} :(";
                    NoResultsLabelVisible = true;
                    SearchResultsVisible = false;
                }
                else
                {
                    NoResultsLabelVisible = false;
                    SearchResultsVisible = true;

                    for (int i = 0; i < recipeData.Hits.Length; i++)
                    {
                        recipeData.Hits[i].Id = i;
                    }

                    RecipeData = recipeData;
                    App.Data = RecipeData;

                    OnPropertyChanged(nameof(RecipeData));
                }
            }
        }

        string GenerateRequestUri(string endpoint)
        {
			string searchFilterName;

			if (!string.IsNullOrEmpty(SearchFilter))
            {
				searchFilterName = SearchFilter.Substring(SearchFilter.IndexOf("=") + 1);
				Title = $"Search {searchFilterName} recipes";

                if (string.IsNullOrEmpty(SearchQuery))
                {
                    SearchQuery = searchFilterName;
                }
            }

            string requestUri = endpoint;
            requestUri += $"?q={SearchQuery}";
            requestUri += $"&app_id={Constants.EdamamAppId}";
            requestUri += $"&app_key={Constants.EdamamAppKey}";
            requestUri += $"&to=100";

            if (!string.IsNullOrEmpty(SearchFilter))
            {
                requestUri += $"&{SearchFilter}";
            }

            return requestUri;
        }

        void OnItemSelected(Hit hit)
        {
            if (hit == null)
                return;

            MessagingCenter.Send(this, MessageStrings.SelectRecipeHit, (hit.Id).ToString());
        }
    }
}