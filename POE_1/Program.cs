using System;

namespace POE_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Recipe newRecipe = Recipe.CreateRecipe();

            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Recipe Details:");
            Console.WriteLine("*********************************************************");
            Recipe.DisplayRecipeDetails(newRecipe);

            Console.Write("\nEnter scaling factor (0.5, 2, or 3): ");
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
                Console.WriteLine("Quantities have been reset to their original values.");
                //Display the updated recipe after user has reset the values
                Console.WriteLine("\n*********************************************************");
                Console.WriteLine("\nUpdated recipe details:");
                Console.WriteLine("\n*********************************************************");
                Recipe.DisplayRecipeDetails(newRecipe);

            }
            else
            {
                Console.WriteLine("Quantities will not be reset.");

            }

            Console.WriteLine("Do you want to clear the Recipe? (yes or no)");

            // Get user input
            string clearInput = Console.ReadLine();

            if (clearInput.ToLower() == "yes")
            {
                newRecipe.Clear();

              
                // Prompt the user to add a new recipe

                Console.WriteLine("\nEnter a new recipe:");
                newRecipe = Recipe.CreateRecipe();

                // Display the new recipe
                Console.WriteLine("\nNew Recipe Details:");
                Recipe.DisplayRecipeDetails(newRecipe);
            }
            else
            {
                // If user inputs "no" then the Recipe will not be cleared and it will not ask them to add a new recipe

                Console.WriteLine("Recipe not cleared ");
            }
        }
    }
}