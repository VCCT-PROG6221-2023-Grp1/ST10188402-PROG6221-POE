using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    public class Worker
    {
        
        static int ingredient_counter;
        List<Ingredient> ingredients = new List<Ingredient>(); //list of ingredients
        static 
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
                Console.WriteLine("6. Show All Recipes");
                Console.WriteLine("7. Exit");
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
                Console.WriteLine("-----------------------");
            }
        }

        /// <summary>
        /// Acquires user information recquired for recipe (Ingredients, amount of steps, step details)
        /// --TO DO--
        /// </summary>
        public void CreateRecipe()
        {
             //list of ingredients
            string stringInput = string.Empty;
            string name = string.Empty;
            int intInput = 0;
            double totalCalories = 0;
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
            List<Ingredient> ingredients = AddIngredients(intInput);
            List<Step> steps = AddSteps();
            
            Recipe recipe = new Recipe(name, 0, ingredients, steps);
            totalCalories = recipe.TotalCalorieCalculation();
            recipes.Add(recipe);
            
            recipe.CaloriesExceeded += Recipe_CaloriesExceeded;
            recipe.setTotalCalories(totalCalories);
            recipes = SortRecipes();


        }

        /// <summary>
        /// Sorts Recipe list into new list
        /// </summary>
        /// <returns>new sorted list</returns>
        public List<Recipe> SortRecipes()
        {
            return recipes.OrderBy(r => r.name).ToList();
        }


        private static void Recipe_CaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The recipe: " + recipeName+ " exceeds 300 calories. \nTotal calories: "
                + totalCalories);
        }

        /// <summary>
        /// Adds details of steps to steps array
        /// </summary>
        public List<Step> AddSteps()
        {
            List<Step> steps = new List<Step>(); //list of step descriptions
            int intInput = 0;
            string userInput = string.Empty;
            bool validCheck = false;
            do
            {
                Console.WriteLine("\n------------------------");
                Console.WriteLine("How many steps would you like to add?"); //prompts user for how many steps they would want
                Console.WriteLine("-------------------------------");
                try
                {
                    intInput = int.Parse(Console.ReadLine());
                    if (intInput > 0) 
                    {
                        validCheck = true;
                        break;
                    }
                    Console.WriteLine("Incorrect value");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (!validCheck);

            //adds a step and saves the details in steps[]
            for (int i = 0; i < intInput; i++)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Step " + (i+1) + ": ");
                userInput = Console.ReadLine();
                steps.Add(new Step(userInput));
            }
            return steps;
        }

        /// <summary>
        /// Adds Ingredient information for each ingredient
        /// </summary>
        /// <param name="ingredientAmount">amount of ingredients being added</param>
        public List<Ingredient> AddIngredients(int ingredientAmount)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string ingredientName = string.Empty; //stores ingredient name
            double ingredientQuantity = 0; //stores ingredient quantity
            int measurementUnit = 0; //stores measurement unit
            int food_group = 0;
            int calories = 0;
            string stringInput = string.Empty; //gets user Input in string
            bool validCheck = false;

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
                do
                {
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
                        if (measurementUnit <= 5)
                        {
                            validCheck = true;
                            break;
                        }
                        Console.WriteLine("Incorrect value");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (!validCheck);
                validCheck = false;
                ingredient.setMeasurementUnit(measurementUnit);

                //gets quantity of ingredients
                do {
                    Console.WriteLine("Enter Quantity of ingredient");
                    stringInput = Console.ReadLine();

                    try
                    {
                        ingredientQuantity = Convert.ToDouble(stringInput);
                        if (ingredientQuantity <= 7)
                        {
                            validCheck =true;
                            break;
                        }
                        Console.WriteLine("Incorrect value");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while(!validCheck);
                validCheck = false;
                ingredient.setQuantity(ingredientQuantity);
                ingredient.setOriginalQuantity();

                //gets ingredient food group
                do {
                    Console.WriteLine("-------------------------------");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter Ingredient Food Group");
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
                        if (food_group <= 7)
                        {
                            validCheck = true;
                            break;
                        }
                        Console.WriteLine("Incorrect value");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (!validCheck);
                validCheck = false;
                ingredient.setFoodGroup(food_group);

                //gets calories
                do {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Calories");
                    Console.WriteLine("-------------------------------");
                    stringInput = Console.ReadLine();

                    try
                    {
                        calories = int.Parse(stringInput);
                        if (calories < 0)
                        {
                            Console.WriteLine("Negative calories? Seriously...");
                        }
                        else if (calories > 0)
                        {
                            validCheck = true;
                            break;
                        }
                        Console.WriteLine("Incorrect value");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (!validCheck);
                ingredient.setCalories(calories);
                ingredient.setOriginalCalories();
                //creates ingredient object and adds it to list
                ingredients.Add(new Ingredient(ingredient.getName(), ingredient.getQuantity(), ingredient.getMeasurementUnit(), ingredient.getFoodGroup(), ingredient.getCalories()));                
            }
            return ingredients;
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
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter Name of Recipe you wish to scale");
            Console.WriteLine("-------------------------------------------");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.name.Equals(recipeName));

            if (recipe != null) {
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
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    recipe.setScale(userInput); //sets scale of recipe
                    recipe.ScaleRecipeIngredients(); //scales recipe
                    Console.WriteLine("Successfully Scaled!");
                    

                }
                while(finish);
                recipe.CaloriesExceeded += Recipe_CaloriesExceeded;
                recipe.setTotalCalories(recipe.getTotalCalories());
            }
        }

        /// <summary>
        /// Resets value of recipe to original values
        /// --TO DO--
        /// </summary>
        public void ResetRecipe()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter Name of Recipe you wish to Reset");
            Console.WriteLine("-------------------------------------------");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.name.Equals(recipeName));

            if (recipe != null)
            {
                recipe.ResetRecipe();
                Console.WriteLine("Reset Successfully!");
                Console.WriteLine("-------------------------------------------");
            }
            else
            {
                Console.WriteLine("Recipe does not exist");
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
            Console.WriteLine("Clear Recipe");
            Console.BackgroundColor = ConsoleColor.Black;
            //prompt user to find out whether they want to clear recipe
            do
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Enter Name of Recipe you wish to delete");
                Console.WriteLine("-------------------------------------------");
                stringInput = Console.ReadLine();

                existCheck = recipes.Exists(x => x.name.Contains(stringInput));
              
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
                Console.WriteLine("Successfully removed!");

            }
        }

        /// <summary>
        /// Displays recipe
        /// --TO DO--
        /// </summary>
        public void ShowRecipe()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter Name of Recipe you wish to show");
            Console.WriteLine("-------------------------------------------");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.name.Equals(recipeName));

            if (recipe != null)
            {
                Console.WriteLine("-------------------------------------------");
                recipe.PrintRecipeInfo();
                Console.WriteLine("Ingredients:");
                recipe.PrintIngredients();
                Console.WriteLine("Steps:");
                recipe.PrintSteps();
            }
            else
            {
                Console.WriteLine("Recipe does not exist");
            }
        }
    } 
}
//______________________________0---------------------------> End of File <---------------------------0______________________________
