using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Recipe
    {
        string name;
        int totalCalories;
        List<Ingredient> ingredients;
        List<Step> steps;


        /// <summary>
        /// Sets steps of recipe
        /// </summary>
        /// <param steps="new_steps"> steps entered </param>
        public void setSteps(List<Step> new_steps)
        {
            steps = new_steps;
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
            return steps;
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
            ingredients = new_ingredients;
        }

        /// <summary>
        /// Gets list of Ingredients in a recipe
        /// </summary>
        /// <returns> list of ingredients in recipe </returns>
        public List<Ingredient> getIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// Sets total amount of calories in a recipe
        /// </summary>
        /// <param totalCalories="new_totalCalories"> total calories </param>
        public void setTotalCalories(int new_totalCalories)
        {
            totalCalories = new_totalCalories;
        }

        /// <summary>
        /// Gets total calories of a recipe
        /// </summary>
        /// <returns> total calories </returns>
        public int getTotalCalories()
        {
            return totalCalories;
        }
    }
}
//______________________________0---------------------------> End of File <---------------------------0______________________________

