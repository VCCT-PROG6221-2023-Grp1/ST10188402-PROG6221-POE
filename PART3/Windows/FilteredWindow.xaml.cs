using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PART3.Classes;
using PROGPOE.Classes;

namespace PART3
{
    public partial class FilteredWindow : Window
    {
        private List<Recipe> allRecipes; // All recipes in RecipeManager

        public FilteredWindow()
        {
            InitializeComponent();

            // Get all recipes from the RecipeManager
            allRecipes = RecipeManager.GetAllRecipes();

            // Set the initial filtered recipes as all recipes
            lstRecipes.ItemsSource = allRecipes;
        }


        /// <summary>
        /// Applies filter to window
        /// </summary>
        private void ApplyFilters()
        {
            string ingredientFilter = txtIngredientFilter.Text.Trim().ToLower();
            string foodGroupFilter = (cmbFoodGroupFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            int maxCaloriesFilter = int.TryParse(txtMaxCaloriesFilter.Text, out int calories) ? calories : int.MaxValue;

            // Filter the recipes based on the selected filters
            List<Recipe> filteredRecipes = allRecipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientFilter) || recipe.getIngredients().Any(ingredient => ingredient.getName().ToLower().Contains(ingredientFilter))) &&
                (foodGroupFilter == "All" || recipe.getIngredients().Any(ingredient => ingredient.getFoodGroup() == foodGroupFilter)) &&
                recipe.getTotalCalories() <= maxCaloriesFilter
            ).ToList();

            List<string> recipeNames = filteredRecipes.Select(recipe => recipe.getName()).ToList();

            // Create a new list to hold the recipes
            List<RecipeViewModel> recipes = new List<RecipeViewModel>();

            // Generate the ingredient view models
            for (int i = 0; i < recipeNames.Count; i++)
            {
                Recipe recipe = filteredRecipes.ElementAt(i);
                RecipeViewModel recipeViewModel = new RecipeViewModel
                {
                    Name = recipe.getName(),
                    TotalCalories = recipe.getTotalCalories(),
                };
                recipes.Add(recipeViewModel);
            }

            // Set the filtered recipes as the ItemsSource of the ListBox
            lstRecipes.ItemsSource = recipes;
        }

        private void txtIngredientFilter_TextChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFoodGroupFilter_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void txtMaxCaloriesFilter_TextChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
