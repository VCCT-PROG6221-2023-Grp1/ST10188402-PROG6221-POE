using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Worker
    {
        static int MAX_STEPS = 15;
        static int MAX_INGREDIENTS = 20;
        static int step_counter = 0; //step counter
        string[] steps = new string[MAX_STEPS]; //details of a step
        bool recipe_made = false; //if true recipe was made, if false no recipe
        Ingredient[] ingredients = new Ingredient[MAX_INGREDIENTS]; //array of ingredients
        Ingredient ingredient = new Ingredient("default", 0.0, "default unit");

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
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Create Recipe");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Ingredients: ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("999 to exit");
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

                AddIngredients(intInput);
                AddSteps();
            }
            while (intInput != 999);
                    
        }


        public void AddSteps()
        {
            string userInput = string.Empty;
            bool finish = false;
            Console.WriteLine("------------------------");
            Console.WriteLine("Provide the details to the steps");
            Console.WriteLine("999 to finish------------------------");

            while (!finish)
            {
                Console.WriteLine("Step" + (step_counter+1) + ": ");
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
                Console.WriteLine("Ingredient " + (i + 1));
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient.setMeasurementUnit(measurementUnit);

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

                //creates ingredient object
                Ingredient addIngredient = new Ingredient(ingredient.getName(), ingredient.getQuantity(), ingredient.getMeasurementUnit());
                //ingredient object is added to array
               // ingredients[i] = addIngredient;

            
            }
        }

        /// <summary>
        /// Scales Recipe down or up according to user needs
        /// --TO DO--
        /// </summary>
        public void ScaleRecipe()
        {
        }

        /// <summary>
        /// Resets value of recipe to original
        /// --TO DO--
        /// </summary>
        public void ResetRecipe()
        {
        }

        /// <summary>
        /// Clears recipe data
        /// --TO DO--
        /// </summary>
        public void ClearRecipe()
        {
        }

        /// <summary>
        /// Displays recipe
        /// --TO DO--
        /// </summary>
        public void ShowRecipe()
        {
        }
    } 
}
//______________________________---------------------------> End of File <---------------------------______________________________
