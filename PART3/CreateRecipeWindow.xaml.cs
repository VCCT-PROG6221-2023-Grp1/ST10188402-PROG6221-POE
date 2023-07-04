using PART3.Classes;
using PROGPOE.Classes;
using System.Collections.Generic;
using System.Windows;

namespace PART3
{
    public partial class CreateRecipeWindow : Window
    {
        private List<Ingredient> ingredients;
        private List<Step> steps;
        private static double TotalCalories = 0;

        public CreateRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to add an ingredient and handle the result
            AddIngredientWindow addIngredientWindow = new AddIngredientWindow();
            if (addIngredientWindow.ShowDialog() == true)
            {
                Ingredient newIngredient = addIngredientWindow.NewIngredient;
                ingredients.Add(newIngredient);
                TotalCalories = TotalCalories + newIngredient.getCalories();
            }
        }


        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to add a step and handle the result
            AddStepWindow addStepWindow = new AddStepWindow();
            if (addStepWindow.ShowDialog() == true)
            {
                Step newStep = addStepWindow.NewStep;
                steps.Add(newStep);
            }
        }


        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Create a new recipe object with the entered data
            string recipeName = txtRecipeName.Text;

            Recipe newRecipe = new Recipe(recipeName, TotalCalories, ingredients, steps);

            // Add the recipe to the RecipeManager
            RecipeManager.AddRecipe(newRecipe);
            TotalCalories = 0;

            // Close the window
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without creating the recipe
            Close();
        }
    }
}
