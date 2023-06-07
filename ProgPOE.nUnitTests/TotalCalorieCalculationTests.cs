using PROGPOE.Classes;

namespace ProgPOE.nUnitTests
{
    public class TotalCalorieCalculationTests
    {
        [Test]
        public void TotalCalorieCalculation_NoIngredients_ReturnsZero()
        {
            // create recipe with no ingredients
            Recipe recipe = new Recipe("Test Recipe", 0.0, new List<Ingredient>(), new List<Step>());

            // Call method
            double totalCalories = recipe.TotalCalorieCalculation();

            // Assert
            Assert.That(totalCalories, Is.EqualTo(0));
        }

        [Test]
        public void TotalCalorieCalculation_SingleIngredient_ReturnsIngredientCalories()
        {
            // Create ingredient
            Ingredient ingredient = new Ingredient("Ingredient 1", 100.0, "grams", "Food Group 1", 200);
            List<Ingredient> ingredients = new List<Ingredient> { ingredient };
            Recipe recipe = new Recipe("Test Recipe", 0.0, ingredients, new List<Step>());

            // Call method
            double totalCalories = recipe.TotalCalorieCalculation();

            // Assert
            Assert.That(totalCalories, Is.EqualTo(200));
        }

        [Test]
        public void TotalCalorieCalculation_MultipleIngredients_ReturnsSumOfIngredientCalories()
        {
            // Create Ingredients
            Ingredient ingredient1 = new Ingredient("Ingredient 1", 100.0, "grams", "Food Group 1", 200);
            Ingredient ingredient2 = new Ingredient("Ingredient 2", 50.0, "grams", "Food Group 2", 150);
            Ingredient ingredient3 = new Ingredient("Ingredient 3", 200.0, "grams", "Food Group 3", 300);
            List<Ingredient> ingredients = new List<Ingredient> { ingredient1, ingredient2, ingredient3 };
            Recipe recipe = new Recipe("Test Recipe", 0.0, ingredients, new List<Step>());

            // Call method
            double totalCalories = recipe.TotalCalorieCalculation();

            // Assert
            double expectedTotalCalories = 650;
            Assert.That(totalCalories, Is.EqualTo(expectedTotalCalories));
        }
    }
}