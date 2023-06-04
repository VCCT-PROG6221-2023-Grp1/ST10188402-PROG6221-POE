using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Worker
    {
        
        static int ingredient_counter;
        static int step_counter = 0; //step counter
        static int totalCalories = 0;
        static List<Ingredient> ingredients = new List<Ingredient>(); //list of ingredients
        static List<Step> steps = new List<Step>(); //list of step descriptions
        List<Recipe> recipes = new List<Recipe>();
        Ingredient ingredient = new Ingredient("default", 0.0, "default unit", "default", 0);

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

                //Displays menu and stores user input
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("Recipe App");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Show A Recipe");
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
                    CreateRecipe(); //exits application
                }
                else if (intInput == 6)
                {
                    ShowAllRecipes(); //exits application
                }
                else if (intInput == 7)
                {
                    exit = true; //exits application
                }

            }
            while (!exit);
        }

        /// <summary>
        /// Shows all recipes
        /// </summary>
        public void ShowAllRecipes()
        {
            foreach(Recipe recipe in recipes)
            {
                recipe.PrintRecipeInfo();
            }
        }

        /// <summary>
        /// Acquires user information recquired for recipe (Ingredients, amount of steps, step details)
        /// --TO DO--
        /// </summary>
        public void CreateRecipe()
        {
            string stringInput = string.Empty;
            string name = string.Empty;
            int intInput = 0;
            Console.WriteLine("\n-------------------------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Create Recipe");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Name:");
            stringInput = Console.ReadLine();
            name = stringInput;
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
            recipes.Add(new Recipe(name, totalCalories, ingredients, steps));
            totalCalories = 0;
                    
        }

        /// <summary>
        /// Adds details of steps to steps array
        /// </summary>
        public void AddSteps()
        {
            int intInput = 0;
            string userInput = string.Empty;
            Console.WriteLine("\n------------------------");
            Console.WriteLine("How many steps would you like to add?"); //prompts user for how many steps they would want
            Console.WriteLine("-------------------------------");
            try 
            { 
            intInput = int.Parse(Console.ReadLine());
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            //adds a step and saves the details in steps[]
            for (int i = 0; i < intInput; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Step " + (i+1) + ": ");
                userInput = Console.ReadLine();
                steps.Add(new Step(userInput));
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
            int food_group = 0;
            int calories = 0;
            string stringInput = string.Empty; //gets user Input in string

            //for each ingredient get its name, the unit of measurement and quantity of ingredient
            for (int i = 0; i < ingredientAmount; i++)
            {
                //gets ingredient name
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Ingredient " + (i + 1));
                Console.WriteLine("-------------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Ingredient Name");
                Console.BackgroundColor = ConsoleColor.Black;
                ingredientName = Console.ReadLine();
                ingredient.setName(ingredientName);

                //gets ingredient measurement unit
                Console.WriteLine("-------------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Ingredient Measurement Unit");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("1. Grams");
                Console.WriteLine("2. Kilograms");
                Console.WriteLine("3. Teaspoons");
                Console.WriteLine("4. Tablespoons");
                Console.WriteLine("5. Cups");
                Console.WriteLine("-------------------------------");
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

                //gets ingredient food group
                Console.WriteLine("-------------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Ingredient Measurement Unit");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("1. Starchy");
                Console.WriteLine("2. Vegetables and fruits");
                Console.WriteLine("3. Dry beans, peas, lentils and soya");
                Console.WriteLine("4. Chicken, fish, meat and eggs");
                Console.WriteLine("5. Milk and dairy products");
                Console.WriteLine("6. Fats and oil");
                Console.WriteLine("7. Water");
                Console.WriteLine("-------------------------------");
                stringInput = Console.ReadLine();

                try
                {
                    food_group = int.Parse(stringInput);
                    if (measurementUnit > 7)
                    {
                        Console.WriteLine("Incorrect value");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient.setFoodGroup(food_group);
                string foodGroupString = ingredient.getFoodGroup(); 

                //gets calories
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Calories");
                Console.WriteLine("-------------------------------");
                stringInput = Console.ReadLine();

                try
                {
                    calories = int.Parse(stringInput);
                    if (measurementUnit < 0)
                    {
                        Console.WriteLine("Negative calories? Seriously...");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ingredient.setCalories(calories);
                totalCalories = totalCalories + calories;

                //creates ingredient object and adds it to list
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, measurementString, foodGroupString, calories));                

            
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
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Scale Recipe");
            Console.BackgroundColor = ConsoleColor.Black;
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
                    }

                    //if user input = 2 double quantity
                    else if (userInput == 2)
                    {
                        ingredient.setQuantity(ingredient.getQuantity() * 2);
                    }

                    //if user input = 3 triple quantity
                    else if (userInput == 3)
                    {
                        ingredient.setQuantity(ingredient.getQuantity() * 3);
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
        /// Resets value of recipe to original values
        /// --TO DO--
        /// </summary>
        public void ResetRecipe()
        {
            int i = 0; //counter 
            //for each ingredient reset its value to original
            foreach (Ingredient ingredient in ingredients)
            {
                i++;
            }
        }

        /// <summary>
        /// Clears recipe data
        /// --TO DO--
        /// </summary>
        public void ClearRecipe()
        {
            string stringInput = string.Empty;  
            int intInput = 0;
            bool valid = false;
            bool existCheck = false;
            int recipe_index = 0;
            Console.WriteLine("-------------------------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Create Recipe");
            Console.BackgroundColor = ConsoleColor.Black;
            //prompt user to find out whether they want to clear recipe
            do
            {
                do
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Enter Name of Recipe you wish to delete");
                    Console.WriteLine("-------------------------------------------");
                    stringInput = Console.ReadLine();

                    existCheck = recipes.Exists(x => x.name.Contains(stringInput));
                }
                while (!existCheck);

                recipe_index = recipes.FindIndex(x => x.name.Contains(stringInput));

                Console.WriteLine("Would you like to clear recipe?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                try
                {
                    intInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect Value entered");
                }
                //if input is 1 or 2 the input is valid and the loop is exited
                if(intInput == 1 || intInput == 2)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Incorrect Value entered");
                }
            } 
            while (!valid);
            if (intInput == 1) 
            {
                recipes.RemoveAt(recipe_index);
                step_counter = 0;
            }
        }

        /// <summary>
        /// Displays recipe
        /// --TO DO--
        /// </summary>
        public void ShowRecipe()
        {
            string stringInput = string.Empty;
            bool existCheck = false;
            int recipe_index = 0;
            // do
            // {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter Name of Recipe you wish to show");
            Console.WriteLine("-------------------------------------------");
            stringInput = Console.ReadLine();

            existCheck = recipes.Exists(recipe => recipe.name.Equals(stringInput));
            // }
            // while (!existCheck)
            if (existCheck)
            {
                recipe_index = recipes.FindIndex(recipe => recipe.name == stringInput);

                Console.WriteLine("\n------------------------");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("----------" + "------------");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("------------------------");
                Console.WriteLine("--------Ingredients--------");
                try
                {
                    recipes[recipe_index].PrintIngredients();
                }
                catch
                {
                    Console.WriteLine("Recipe does not exist");
                }

                Console.WriteLine("------------------------");
                Console.WriteLine("------------Steps-----------");
                recipes[recipe_index].PrintSteps();
            }
            else
            {
                Console.WriteLine("Recipe does not exist");
            }
        }
    } 
}
//______________________________0---------------------------> End of File <---------------------------0______________________________
