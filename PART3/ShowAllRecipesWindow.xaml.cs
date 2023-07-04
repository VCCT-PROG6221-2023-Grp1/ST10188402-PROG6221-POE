using System.Collections.Generic;
using System.Windows;
using PART3.Classes;
using PROGPOE.Classes;

namespace PART3
{
    public partial class ShowAllRecipesWindow : Window
    {
        private List<Recipe> allRecipes; // All recipes in RecipeManager

        public ShowAllRecipesWindow()
        {
            InitializeComponent();

            // Get all recipes from the RecipeManager
            allRecipes = RecipeManager.GetAllRecipes();

            // Create a new list to hold the numbered recipe details
            List<string> numberedRecipeDetails = new List<string>();

            // Generate the numbered recipe details
            for (int i = 0; i < allRecipes.Count; i++)
            {
                Recipe recipe = allRecipes[i];
                string details = $"{i + 1}. {recipe.getName()} - Total Calories: {recipe.getTotalCalories()}";
                numberedRecipeDetails.Add(details);
            }

            // Set the numbered recipe details as the ItemsSource of the ListBox
            lstRecipes.ItemsSource = numberedRecipeDetails;
        }

        private void lstRecipes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if a recipe is selected
            if (lstRecipes.SelectedIndex != -1)
            {
                // Get the selected recipe index
                int selectedRecipeIndex = lstRecipes.SelectedIndex;

                // Get the selected recipe from the allRecipes list
                if (selectedRecipeIndex >= 0 && selectedRecipeIndex < allRecipes.Count)
                {
                    Recipe selectedRecipe = allRecipes[selectedRecipeIndex];

                    // Create and show the ShowRecipeWindow with the selected recipe
                    ShowRecipeWindow showRecipeWindow = new ShowRecipeWindow(selectedRecipe);
                    showRecipeWindow.ShowDialog();
                }
            }
        }
    }
}
