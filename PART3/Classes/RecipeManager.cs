using System.Collections.Generic;
using System.Linq;
using PROGPOE.Classes;

namespace PART3.Classes
{
    public static class RecipeManager
    {
        private static List<Recipe> recipes = new List<Recipe>();
        private static List<Recipe> originalRecipes = new List<Recipe>();

        /// <summary>
        /// Adds recipe
        /// </summary>
        /// <param name="recipe"> recipe</param>
        public static void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            originalRecipes.Add(recipe);
        }

        /// <summary>
        /// Scales recipe ingredients
        /// </summary>
        /// <param name="recipe"> name of recipe</param>
        /// <param name="scaleFactor"> factor to be multiplied by</param>
        public static void ScaleRecipeIngredients(Recipe recipe, double scaleFactor)
        {
            foreach (Ingredient ingredient in recipe.getIngredients())
            {
                double scaledQuantity = ingredient.getQuantity() * scaleFactor;
                ingredient.setQuantity(scaledQuantity);
                recipe.setTotalCalories(recipe.getTotalCalories() * scaleFactor);
            }
        }


        /// <summary>
        /// Resets recipe values
        /// </summary>
        /// <param name="recipe"></param>
        public static void ResetRecipeIngredients(Recipe recipe)
        {
            Recipe originalRecipe = originalRecipes.Find(r => r.getName() == recipe.getName());
            if (originalRecipe != null)
            {
                // Reset the recipe's properties to the original values
                recipe.setIngredients(originalRecipe.getIngredients());
            }
            return;
        }


        /// <summary>
        /// Gets all Recipes
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        /// <summary>
        /// Deletes Recipe
        /// </summary>
        /// <param name="recipe">recipe</param>
        public static void DeleteRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
            originalRecipes.Remove(recipe);
        }

        /// <summary>
        /// gets recipe by name
        /// </summary>
        /// <param name="recipeName">name of recipe</param>
        /// <returns></returns>
        public static Recipe GetRecipeByName(string recipeName)
        {
            return recipes.FirstOrDefault(r => r.getName() == recipeName);
        }
    }
}
