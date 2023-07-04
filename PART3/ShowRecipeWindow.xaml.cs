using System.Collections.Generic;
using System.Windows;
using PART3.Classes;
using PROGPOE.Classes;

namespace PART3
{
    public partial class ShowRecipeWindow : Window
    {
        public ShowRecipeWindow(Recipe recipe)
        {
            InitializeComponent();

            // Set the recipe details
            txtRecipeName.Text = recipe.getName();
            txtTotalCalories.Text = recipe.getTotalCalories().ToString();

            // Create a new list to hold the ingredients
            List<IngredientViewModel> ingredients = new List<IngredientViewModel>();

            // Generate the ingredient view models
            for (int i = 0; i < recipe.getIngredients().Count; i++)
            {
                Ingredient ingredient = recipe.getIngredients()[i];
                IngredientViewModel ingredientViewModel = new IngredientViewModel
                {
                    Heading = $"Ingredient {i + 1}",
                    Name = ingredient.getName(),
                    FoodGroup = ingredient.getFoodGroup(),
                    Calories = ingredient.getCalories(),
                    Quantity = ingredient.getQuantity(),
                    MeasurementUnit = ingredient.getMeasurementUnit()
                };
                ingredients.Add(ingredientViewModel);
            }

            // Set the ingredients as the ItemsSource of the ListBox
            lstIngredients.ItemsSource = ingredients;

            // Create a new list to hold the steps
            List<StepViewModel> steps = new List<StepViewModel>();

            // Generate the step view models
            for (int i = 0; i < recipe.getSteps().Count; i++)
            {
                Step step = recipe.getSteps()[i];
                StepViewModel stepViewModel = new StepViewModel
                {
                    Heading = $"Step {i + 1}",
                    Description = step.getStepDescription(),
                };
                steps.Add(stepViewModel);
            }

            // Set the steps as the ItemsSource of the ListBox
            lstSteps.ItemsSource = steps;
        }
    }
}
