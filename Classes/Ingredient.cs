using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    public class Ingredient
    {
        string name;
        double quantity;
        static double originalQuantity;
        string[] measurement_units = { "grams", "kilograms", "teaspoons", "tablespoons", "cups" };
        string measurement_unit;
        double calories;
        static double originalCalories;
        string[] food_groups = { "Starchy", "Vegetables and fruits", "Dry beans, peas, lentils and soya",
            "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oil", "Water" };
        string foodGroup;

        /// <summary>
        /// Resets quantity to original value
        /// </summary>
        public void ResetQuantity()
        {
            setQuantity(originalQuantity);
            setCalories(originalCalories);
        }

        /// <summary>
        /// Ingredient Object
        /// </summary>
        /// <param name="name">name of ingredient</param>
        /// <param name="quantity">quantity of ingredients</param>
        /// <param name="measurement_unit">measurement unit of ingredient</param>
        public Ingredient(string name, double quantity, string measurement_unit, string foodGroup, double calories)
        {
            this.name = name;
            this.quantity = quantity;
            this.measurement_unit = measurement_unit;
            this.foodGroup = foodGroup;
            this.calories = calories;

        }

        /// <summary>
        /// Gets Ingredient name
        /// </summary>
        /// <returns> name of ingredient </returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// Sets name of ingredient
        /// </summary>
        /// <param name="new_name"> name entered </param>
        public void setName(string new_name)
        {
            name = new_name;
        }

        /// <summary>
        /// Gets quantity of ingredient
        /// </summary>
        /// <returns> ingredient quantity</returns>
        public double getQuantity()
        {
            return quantity;
        }

        /// <summary>
        /// sets original Quantity of Ingredient
        /// </summary>
        public void setOriginalQuantity(double new_originalQuantity)
        {
            originalQuantity = new_originalQuantity;
        }

        /// <summary>
        /// sets original Quantity of Ingredient
        /// </summary>
        public void setOriginalCalories(double new_originalCalories)
        {
            originalCalories = new_originalCalories;
        }

        /// <summary>
        /// sets Quantity of Ingredient
        /// </summary>
        /// <param name="new_quantity"> quantity entered</param>
        public void setQuantity(double new_quantity)
        {
            quantity = new_quantity;
        }

        /// <summary>
        /// sets Quantity of Ingredient
        /// </summary>
        /// <param name="new_quantity"> quantity entered</param>
        public void setCalories(double new_calories)
        {
            calories = new_calories;
        }

        /// <summary>
        /// Gets unit of measurement of ingredient
        /// </summary>
        /// <returns></returns>
        public double getCalories()
        {
            return calories;
        }

        /// <summary>
        /// Gets unit of measurement of ingredient
        /// </summary>
        /// <returns></returns>
        public string getMeasurementUnit()
        {
            return measurement_unit;
        }

        /// <summary>
        /// Sets unit of measurement of ingredient
        /// </summary>
        /// <param name="new_measurement_unit"> number entered to decide what unit</param>
        public void setMeasurementUnit(int new_measurement_unit)
        {
            measurement_unit = measurement_units[new_measurement_unit-1]; 
        }

        /// <summary>
        /// Gets food group of ingredient
        /// </summary>
        /// <returns>food group</returns>
        public string getFoodGroup()
        {
            return foodGroup;
        }

        /// <summary>
        /// Sets food group of ingredient
        /// </summary>
        /// <param foodGroup="new_foodGroup"> number entered to decide what unit</param>
        public void setFoodGroup(int new_foodGroup)
        {
            foodGroup = food_groups[new_foodGroup - 1];
        }
    }
}
//______________________________0---------------------------> End of File <---------------------------0______________________________