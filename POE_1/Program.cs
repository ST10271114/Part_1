using System;
using System.Collections.Generic;

namespace POE_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Recipe newRecipe = Recipe.CreateRecipe();

                // Subscribe to the OnCalorieExceed event for each new recipe
                newRecipe.OnCalorieExceed += NotifyCalorieExceed;

                recipes.Add(newRecipe);

                Console.WriteLine("\n*********************************************************");
                Console.WriteLine("Recipe Details:");
                Console.WriteLine("*********************************************************");

                Recipe.DisplayRecipeDetails(newRecipe);

                Console.Write("\nEnter scaling factor (0.5 for half, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());

                // Scale the recipe
                newRecipe.ScaleRecipe(factor);

                // Display scaled recipe
                Console.WriteLine($"\nScaled Recipe (Factor: {factor}):");
                Recipe.DisplayRecipeDetails(newRecipe);

                Console.WriteLine("Do you want to reset the quantities to their original values? (yes or no)");

                // Get user input
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "yes")
                {
                    newRecipe.ResetQuantity();

                    // Display the updated recipe after user has reset the values
                    Console.WriteLine("*********************************************************");
                    Console.WriteLine("Updated recipe details:");
                    Console.WriteLine("*********************************************************");
                    Recipe.DisplayRecipeDetails(newRecipe);
                }
                else
                {
                    Console.WriteLine("Quantities will not be reset.");
                }

                // Ask the user if they would like to add another recipe
                Console.WriteLine("Do you want to add another recipe? (yes or no)");

                // Get user input
                string addAnotherInput = Console.ReadLine();

                if (addAnotherInput.ToLower() != "yes")
                {
                    break; // Exit the loop if the user does not want to add another recipe
                }
            }

            Console.WriteLine("\nAll recipes entered:");
            foreach (Recipe recipe in recipes)
            {
                Recipe.DisplayRecipeDetails(recipe);
            }

            var sortedRecipe = recipes.OrderBy(r => r.Name);
            Console.WriteLine("\nList of Recipe:");
            foreach (var recipe in sortedRecipe)
            {
                Console.WriteLine($"{recipe.Name} ");
            }

            // Ask the user if they would like to display a specific recipe 
            Console.WriteLine("\nEnter a recipe you would like to display:");
            string recipeName = Console.ReadLine();

            Recipe selectedRecipe = null;
            foreach (Recipe recipe in sortedRecipe)
            {
                if (recipe.Name.Equals(recipeName))
                {
                    selectedRecipe = recipe;
                    break;
                }
            }

            if (selectedRecipe != null)
            {
                // Perform further actions with the selected recipe
                Recipe.DisplayRecipeDetails(selectedRecipe);
            }
            else
            {
                Console.WriteLine("The recipe could not be found.");
            }

            selectedRecipe?.DisplayTotalCalories();
        }

        // Notification action for calories exceeding 300
        static void NotifyCalorieExceed(string message)
        {
            // Display the message in red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor(); 
        }
    }

}

    
