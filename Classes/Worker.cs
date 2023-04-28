using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Worker
    {
        static int MAX_STEPS = 20;
        static int MAX_INGREDIENTS = 20;
        static int ingredient_counter;
        static int step_counter = 0; //step counter
        string[] steps = new string[MAX_STEPS]; //details of a step
        bool recipe_made = false; //if true recipe was made, if false no recipe
        List<Ingredient> ingredients = new List<Ingredient>(); //array of ingredients
        Ingredient ingredient = new Ingredient("default", 0.0, "default unit");
        double[] original_ingredient_val = new double[MAX_INGREDIENTS];

        /// <summary>
        /// Displays menu to 1.Create recipe, 2.Scale Recipe, 3.Reset Values, 4.Clear Recipe, 5. Show Recipe
        /// --TO DO--
        /// </summary>
        public void Menu()
        {
            bool exit = false;
            do
            {
                string stringInput = string.Empty; //declare variable for user input in string
                int intInput = 0; //declare variable for user input to converted to int

                //if no recipe is made application will automatically start recipe creation process
                if (!recipe_made)
                {
                    Console.WriteLine("Welcome to recipe app!");
                    Console.WriteLine("-------------------------------");
                    CreateRecipe();
                    recipe_made = true;
                }

                //Displays menu and stores user input
                Console.WriteLine("Recipe App");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Show Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset Recipe Values");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Create Recipe");
                Console.WriteLine("6. Exit");
                stringInput = Console.ReadLine();

                try
                {
                    intInput = int.Parse(stringInput); //converting user input to int
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // if invalid character entered display error message
                }

                if (intInput == 1)
                {
                    ShowRecipe();   //calls show recipe method
                }
                else if (intInput == 2)
                {
                    ScaleRecipe();  //calls scale recipe method
                }
                else if (intInput == 3)
                {
                    ResetRecipe();  //calls reset recipe method
                }
                else if (intInput == 4)
                {
                    ClearRecipe (); //calls clear recipe method
                }
                else if (intInput == 5)
                {
                    CreateRecipe(); //calls create recipe method
                }
                else if (intInput == 6)
                {
                    exit = true; //exits application
                }

            }
            while (!exit);
        }

        /// <summary>
        /// Acquires user information recquired for recipe (Ingredients, amount of steps, step details)
        /// --TO DO--
        /// </summary>
        public void CreateRecipe()
        {
            string stringInput = string.Empty;
            int intInput = 0;
            do
            {
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine("Create Recipe");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("999 to exit ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Ingredients:");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("How many ingredients would you like to add?");
                stringInput = Console.ReadLine();

                try
                {
                    intInput = int.Parse(stringInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient_counter = intInput;
                AddIngredients(intInput);
                AddSteps();
                intInput = 999;
            }
            while (intInput != 999);
                    
        }

        /// <summary>
        /// Adds details of steps to steps array
        /// </summary>
        public void AddSteps()
        {
            string userInput = string.Empty;
            bool finish = false;
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Provide the details to the steps");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("999 to finish");
            Console.WriteLine("-------------------------------");
            while (!finish)
            {
                //if user input is not equal to exit key then add more steps
                if (userInput == "999")
                {
                    finish = true;
                    break;
                }
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Step " + (step_counter+1) + ": ");
                userInput = Console.ReadLine();
                steps[step_counter] = userInput;
                step_counter++;
            }
        }

        /// <summary>
        /// Adds Ingredient information for each ingredient
        /// </summary>
        /// <param name="ingredientAmount">amount of ingredients being added</param>
        public void AddIngredients(int ingredientAmount)
        {

            string ingredientName = string.Empty; //stores ingredient name
            double ingredientQuantity = 0; //stores ingredient quantity
            int measurementUnit = 0; //stores measurement unit
            string stringInput = string.Empty; //gets user Input in string

            //for each ingredient get its name, the unit of measurement and quantity of ingredient
            for (int i = 0; i < ingredientAmount; i++)
            {
                //gets ingredient name
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Ingredient " + (i + 1));
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Enter Ingredient Name");
                ingredientName = Console.ReadLine();
                ingredient.setName(ingredientName);

                //gets ingredient measurement unit
                Console.WriteLine("Enter Ingredient Measurement Unit");
                Console.WriteLine("1. Grams");
                Console.WriteLine("2. Kilograms");
                Console.WriteLine("3. Teaspoons");
                Console.WriteLine("4. Tablespoons");
                Console.WriteLine("5. Cups");
                stringInput = Console.ReadLine();

                try
                {
                    measurementUnit = int.Parse(stringInput);
                    if (measurementUnit > 5)
                    {
                        Console.WriteLine("Incorrect value");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient.setMeasurementUnit(measurementUnit);
                string measurementString = ingredient.getMeasurementUnit();

                //gets quantity of ingredients
                Console.WriteLine("Enter Quantity of ingredient");
                stringInput = Console.ReadLine();

                try
                {
                    ingredientQuantity = Convert.ToDouble(stringInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient.setQuantity(ingredientQuantity);
                original_ingredient_val[i] = ingredientQuantity;

                //creates ingredient object
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, measurementString));
                MeasurementUnitCheck(measurementString, ingredientQuantity);
                

            
            }
        }

        /// <summary>
        /// Scales Recipe down or up according to user needs
        /// --TO DO--
        /// </summary>
        public void ScaleRecipe()
        {   
            bool finish = false;
            int userInput = 0;
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("Scale Recipe");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. half amounts");
            Console.WriteLine("2. double amounts");
            Console.WriteLine("3. triple amounts");

            //prompt for user input until correct value is entered
            do
            { 

                try
                {
                userInput = int.Parse(Console.ReadLine()); //stores user input
                }
                catch(Exception e)
                { 
                Console.WriteLine(e.Message);
                }

                foreach (Ingredient ingredient in ingredients)
                {
                    //if user input = 1 half quantity
                    if (userInput == 1)
                    {
                        ingredient.setQuantity(ingredient.getQuantity() / 2);
                        MeasurementUnitCheck(ingredient.getMeasurementUnit(), ingredient.getQuantity());
                    }

                    //if user input = 2 double quantity
                    else if (userInput == 2)
                    {
                        ingredient.setQuantity(ingredient.getQuantity() * 2);
                        MeasurementUnitCheck(ingredient.getMeasurementUnit(), ingredient.getQuantity());
                    }

                    //if user input = 3 triple quantity
                    else if (userInput == 3)
                    {
                        ingredient.setQuantity(ingredient.getQuantity() * 3);
                        MeasurementUnitCheck(ingredient.getMeasurementUnit(), ingredient.getQuantity());
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value entered");
                    }
                }
            }
            while (finish);
        }

        /// <summary>
        /// Checks Measurement unit and returns whether the unit should go down one or up 1
        /// </summary>
        /// <param name="Measurement">measurement unit</param>
        /// <param name="quantity">quantity of ingredient</param>
        /// <returns></returns>
        public void MeasurementUnitCheck(string Measurement, double quantity)
        {
            
            //if measurement unit is = grams and the quantity of grams is greater than 1000 convert to kilograms
            if (Measurement.Equals(ingredient.measurement_units[0])) 
            {
                if (quantity > 1000)
                {
                    ingredient.setMeasurementUnit(1);
                }
            }
            //if measurement unit is = kilograms and the quantity of grams is less than 1 convert to grams
            else if (Measurement.Equals(ingredient.measurement_units[1]))
            {
                if (quantity < 1)
                {
                    ingredient.setMeasurementUnit(0);
                }
            }
            //if measurement unit is = teaspoons and the quantity of teaspoons is greater than 3 convert to tablespoons
            else if (Measurement.Equals(ingredient.measurement_units[2]))
            {
                if (quantity > 3)
                {
                    ingredient.setMeasurementUnit(3);
                }
            }
            //if measurement unit is = tablespoons and the quantity of tablespoons is less than 1 convert to teaspoons
            else if (Measurement.Equals(ingredient.measurement_units[3]))
            {
                if (quantity < 1)
                {
                    ingredient.setMeasurementUnit(2);
                }
            }
            //if measurement unit is = tablespoons and the quantity of tablespoons is greater than 16 convert to cups
            else if (Measurement.Equals(ingredient.measurement_units[3]))
            {
                if (quantity > 16)
                {
                    ingredient.setMeasurementUnit(4);
                }
            }
            //if measurement unit is = cups and the quantity of cups is less than 1 convert to kilograms
            else if (Measurement.Equals(ingredient.measurement_units[4]))
            {
                if (quantity < 1)
                {
                    ingredient.setMeasurementUnit(3);
                }
            }

        }

        /// <summary>
        /// Resets value of recipe to original values
        /// --TO DO--
        /// </summary>
        public void ResetRecipe()
        {
            int i = 0; //counter 
            //for each ingredient reset its value to original
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.setQuantity(original_ingredient_val[i]);
                i++;
            }
        }

        /// <summary>
        /// Clears recipe data
        /// --TO DO--
        /// </summary>
        public void ClearRecipe()
        {
            ingredients.Clear(); //clears recipe
            recipe_made = false;
        }

        /// <summary>
        /// Displays recipe
        /// --TO DO--
        /// </summary>
        public void ShowRecipe()
        {

            Console.WriteLine("\n------------------------");
            Console.WriteLine("----------RECIPE------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("--------Ingredients--------");

            //for every ingredient in ingredients[] print out ingredient details
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient.getQuantity() + " " + ingredient.getMeasurementUnit() 
                    + " of " + ingredient.getName());
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("------------Steps-----------");
            //for every step print its details
            for (int j = 0; j < step_counter; j++)
            {
                Console.WriteLine("Step " + (j+1) + ":\n" + steps[j]);
            }
            Console.WriteLine("------------------------");
        }
    } 
}
//______________________________0---------------------------> End of File <---------------------------0______________________________
