using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Ingredient
    {
        string name;
        double quantity;
        string[] measurement_units = { "grams", "kilograms", "teaspoons", "tablespoons", "cups";
        string measurement_unit;

        public Ingredient(string name, double quantity, string measurement_unit)
        {
            this.name = name;
            this.quantity = quantity;
            this.measurement_unit = measurement_unit;
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
        /// sets Quantity of Ingredient
        /// </summary>
        /// <param name="new_quantity"> quantity entered</param>
        public void setQuantity(double new_quantity)
        {
            quantity = new_quantity;
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
    }
}
//______________________________---------------------------> End of File <---------------------------______________________________