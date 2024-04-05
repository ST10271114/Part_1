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
        }
    }
}