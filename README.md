# PROGPOE
## What it does
This application creates recipes by acquiring the steps and ingredients(name of ingredient, unit of measurement of ingredient and quantity of ingredient) needed for said recipe from the user and compiling that together into lists

## How to use
-Upon launching the application the user will be prompted with the menu with the following 8 options:

  -1. Show Recipe
      
      - This will ask the user to enter the name of the recipe and then print the recipe details
      
  -2. Scale Recipe
      
      - This will ask for the user to enter the name of the recipe they wish to scale 
      - This will then show a new menu that allows the user to either halve, double or triple the quantity of ingredients and total calories of the recipe and when a choice is made it will return  
        to previous menu
        
  -3. Reset Recipe Values
      
      - This will ask for the user to enter the name of the recipe they want to reset
      - This will then resets the quantities and calories of ingredients as well as the total calories back to what they were set to originally 
  
  -4. Clear Recipe
      
      - This will ask for the user to enter the name of the recipe they wish to delete
      - Then it asks the user if they are sure to clear recipe data and if user enters yes option all recipe data is cleared and the application will then remove the recipe
      
  -5. Create Recipe
      
      - This will create a recipe by asking for the name, amount of ingredients, ingredient name, measurement unit, quantity of that measurement of the ingredient, food group and calories of the ingredient and the steps and their description
      -this information is then saved in memory
      
  -6. Show All Recipes
      
      -Shows all created recipes in alphabetical order
  
  -7. What are food groups
      
      - Provides a link to learn about food groups
      
  -8. Exit
      
      - exits application
      
## What is Different

-The application no longer prompts the user for recipe creation immediately when opened

-The application can save multiple recipes

-The application now saves food groups and calories of ingredients

-The application now saves the total calories of a recipe

-The application now prompts user when total calories exceeds 300

-The application has the what are food groups option now

      
## Software Requirements

This application was developed in C# on the .NET Framework v4.8

To view the code for this application you can use an application such as Microsoft Visual Studio

## License
MIT


