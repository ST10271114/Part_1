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

            Console.WriteLine("Do you want to reset the quantities to their original values? (yes/no)");

            // Get user input
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "yes")

            {
                
                newRecipe.ResetQuantity();
                Console.WriteLine("Quantities have been reset to their original values.");

                Console.WriteLine("\nUpdated recipe details:");
                Recipe.DisplayRecipeDetails(newRecipe);

            }
            else
            {
                Console.WriteLine("Quantities will not be reset.");
               
            }
        }
    }
}