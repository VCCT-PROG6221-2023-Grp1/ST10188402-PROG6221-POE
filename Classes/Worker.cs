using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class Worker
    {
        static int step_counter = 0; //step counter
        string[] step_details; //details of a step
        bool recipe_made = false; //if true recipe was made, if false no recipe
        Ingredient[] ingredients; //array of ingredients

        /// <summary>
        /// Displays menu to 1.Create recipe, 2.Scale Recipe, 3.Reset Values, 4.Clear Recipe, 5. Show Recipe
        /// --TO DO--
        /// </summary>
        public void Menu()
        {
            bool exit = false;
            do
            {
                string stringInput = string.Empty;
                int intInput = 0;

                if (!recipe_made)
                {
                    Console.WriteLine("Welcome to recipe app!");
                    Console.WriteLine("-------------------------------");
                    CreateRecipe();
                }

                Console.WriteLine("Recipe App");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Show Recipe");
                Console.WriteLine("2. Scale Recipe");
                Console.WriteLine("3. Reset Recipe Values");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Create Recipe");
                stringInput = Console.ReadLine();

                try
                {
                    intInput = int.Parse(stringInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
