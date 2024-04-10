using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_1
{
    internal class Recipe


    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Ingredients[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        // Method to create a new recipe
        public static Recipe CreateRecipe()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Welcome! Please enter the details for your recipe:");
            Console.WriteLine("*********************************************************");

            Console.Write("\nName: ");
            recipe.Name = Console.ReadLine();

            Console.Write("\nDescription: ");
            recipe.Description = Console.ReadLine();

            Console.Write("\nNumber of Ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            recipe.Ingredients = new Ingredients[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Ingredients ingredient = new Ingredients(); ;

                Console.Write($"\nIngredient {i + 1} Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write($"\nQuantity for {ingredient.Name}: ");
                ingredient.Quantity = double.Parse(Console.ReadLine());

                Console.Write($"\nUnit of measurement for {ingredient.Name}: ");
                ingredient.Unit = Console.ReadLine();

                ingredient.InitialQuantity = ingredient.Quantity; // Store initial quantity

                recipe.Ingredients[i] = ingredient;
            }

            Console.Write("\nNumber of Steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            recipe.Steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nStep {i + 1}: ");
                recipe.Steps[i] = Console.ReadLine();
            }

            return recipe;
        }

        // Method to display recipe details
        public static void DisplayRecipeDetails(Recipe recipe)
        {
            Console.WriteLine($"Name: {recipe.Name}");
            Console.WriteLine($"Description: {recipe.Description}");

            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Length; i++)
            {
                Console.WriteLine($"Step {i + 1}: {recipe.Steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.InitialQuantity; // Reset to initial quantity
            }
        }
    }
}