﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROGPOE.Classes
{
    public delegate void RecipeCaloriesExceededHandler(string recipeName, double totalCalories);

    public class Recipe
    {
        public string name;
        double totalCalories;
        double originalTotalCalories;
        public List<Ingredient> recipeIngredients = new List<Ingredient>();
        List<Step> recipeSteps = new List<Step>();
        double[] scales = { 0.5, 2, 3 };
        double scale = 0;

        public event RecipeCaloriesExceededHandler CaloriesExceeded;

        public double TotalCalorieCalculation()
        {
            foreach (Ingredient ingredient in recipeIngredients)
            {
                totalCalories = ingredient.getCalories() + totalCalories;
                originalTotalCalories = totalCalories;
            }
            return totalCalories;
        }

        /// <summary>
        /// resets recipe to original values
        /// </summary>
        public void ResetRecipe()
        {
            foreach (Ingredient ingredient in recipeIngredients)
            {
                ingredient.ResetQuantity();
                totalCalories = originalTotalCalories;
            }
        }

        /// <summary>
        /// Scales ingredients of recipe
        /// </summary>
        /// <param name="scale"></param>
        public void ScaleRecipeIngredients()
        {
            foreach (Ingredient ingredient in recipeIngredients)
            {
                ingredient.setQuantity(ingredient.getQuantity() * scale);
                ingredient.setCalories(ingredient.getCalories() * scale);
                totalCalories *= scale;
            }
        }


        /// <summary>
        /// sets scale to be multiplied
        /// </summary>
        /// <param name="new_scale"></param>
        public void setScale(int new_scale)
        {
            scale = scales[new_scale - 1];
        }

        /// <summary>
        /// recipe object
        /// </summary>
        /// <param name="name">Recipe Name</param>
        /// <param name="totalCalories">Total Calories</param>
        /// <param name="ingredients">List of Ingredients</param>
        /// <param name="steps">List of Steps</param>
        public Recipe(string name, double totalCalories, List<Ingredient> recipeIngredients, List<Step> recipeSteps)
        {
            this.name = name;
            this.totalCalories = totalCalories;
            this.recipeIngredients = recipeIngredients;
            this.recipeSteps = recipeSteps;
        }

        /// <summary>
        /// Prints recipe name and total calories
        /// </summary>
        public void PrintRecipeInfo()
        {
            Console.WriteLine("Recipe: " + name);
            Console.WriteLine("Total Calories: " + totalCalories);
        }

        /// <summary>
        /// prints all ingredients 
        /// </summary>
        public void PrintIngredients()
        {
            foreach (Ingredient ingredient in recipeIngredients)
            {
                Console.WriteLine("- " + ingredient.getName() + ", Quantity - " + ingredient.getQuantity()
                    + " " + ingredient.getMeasurementUnit() + ", Food Group - " + ingredient.getFoodGroup()
                    + ", Calories: " + ingredient.getCalories());
            }
        }

        /// <summary>
        /// Prints step descriptions of all steps 
        /// </summary>
        public void PrintSteps()
        {
            int count = 0;
            foreach (Step step in recipeSteps)
            {
                Console.WriteLine("- Step " + (count+1) + ": " + step.stepDescription);
            }
        }

        /// <summary>
        /// Sets steps of recipe
        /// </summary>
        /// <param steps="new_steps"> steps entered </param>
        public void setSteps(List<Step> new_steps)
        {
            recipeSteps = new_steps;
        }


        /// <summary>
        /// Sets name of recipe
        /// </summary>
        /// <param name="new_name"> name entered </param>
        public void setName(string new_name)
        {
            name = new_name;
        }

        /// <summary>
        /// Gets recipe steps
        /// </summary>
        /// <returns> list of steps of recipe </returns>
        public List<Step> getSteps()
        {
            return recipeSteps;
        }

        /// <summary>
        /// Gets recipe name
        /// </summary>
        /// <returns> name of recipe </returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Sets list of ingredients in a recipe
        /// </summary>
        /// <param ingredients="new_ingredients"> list of ingredients </param>
        public void setIngredients(List<Ingredient> new_ingredients)
        {
            recipeIngredients = new_ingredients;
        }

        /// <summary>
        /// Gets list of Ingredients in a recipe
        /// </summary>
        /// <returns> list of ingredients in recipe </returns>
        public List<Ingredient> getIngredients()
        {
            return recipeIngredients;
        }

        /// <summary>
        /// Sets total amount of calories in a recipe
        /// </summary>
        /// <param totalCalories="new_totalCalories"> total calories </param>
        public void setTotalCalories(double new_totalCalories)
        {
            totalCalories = new_totalCalories;

            if (new_totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(name, new_totalCalories);
            }
        }

        /// <summary>
        /// Gets total calories of a recipe
        /// </summary>
        /// <returns> total calories </returns>
        public double getTotalCalories()
        {
            return totalCalories;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            recipeIngredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            recipeIngredients.Remove(ingredient);
        }

        public void AddStep(Step step)
        {
            recipeSteps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            recipeSteps.Remove(step);
        }
    }
}
//______________________________0---------------------------> End of File <---------------------------0______________________________

