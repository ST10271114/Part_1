using System;
using System.Collections.Generic;


namespace POE_1
{
    internal class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredients>();
            Steps = new List<string>();
        }

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

            for (int i = 0; i < numIngredients; i++)
            {
                Ingredients ingredient = new Ingredients();

                Console.Write($"\nIngredient {i + 1} Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write($"\nQuantity for {ingredient.Name}: ");
                ingredient.Quantity = double.Parse(Console.ReadLine());

                ingredient.InitialQuantity = ingredient.Quantity;

                Console.Write($"\nCalories for {ingredient.Name}: ");
                ingredient.Calories = double.Parse(Console.ReadLine());

                Console.WriteLine("\nSelect the food group for the ingredient:");
                Console.WriteLine("1. Starchy foods");
                Console.WriteLine("2. Vegetables and fruits");
                Console.WriteLine("3. Dry beans, peas, lentils, and soya");
                Console.WriteLine("4. Milk and dairy products");
                Console.WriteLine("5. Fats and oils");
                Console.WriteLine("6. Water");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ingredient.FoodGroup = "Starchy foods";
                        break;
                    case 2:
                        ingredient.FoodGroup = "Vegetables and fruits";
                        break;
                    case 3:
                        ingredient.FoodGroup = "Dry beans, peas, lentils, and soya";
                        break;
                    case 4:
                        ingredient.FoodGroup = "Milk and dairy products";
                        break;
                    case 5:
                        ingredient.FoodGroup = "Fats and oils";
                        break;
                    case 6:
                        ingredient.FoodGroup = "Water";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Defaulting to Other.");
                        ingredient.FoodGroup = "Other";
                        break;
                }

                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("\nNumber of Steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nStep {i + 1}: ");
                recipe.Steps.Add(Console.ReadLine());
            }

            return recipe;
        }

        public static void DisplayRecipeDetails(Recipe recipe)
        {
            Console.WriteLine($"Name: {recipe.Name}");
            Console.WriteLine($"Description: {recipe.Description}");

            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {recipe.Steps[i]}");
            }
            Console.WriteLine($"Recipe Name: {recipe.Name}");
        }
    

    public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Reset the quantities of ingredients to their initial values
        public void ResetQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                
                ingredient.Quantity = ingredient.InitialQuantity; 
            }

        }
        // Method to clear and ask the user to insert a new recipe
        public void Clear()
        {
            Name = "";
            Description = "";
            Ingredients = null;
            Steps = null;
        }
        // Define a delegate for notification
        public delegate void RecipeNotification(string message);

        // Event to be triggered when the total calories exceed 300
        public event RecipeNotification OnCalorieExceed;

        // Method to calculate and display the total calories of all ingredients in the recipe
        public void DisplayTotalCalories()
        {
            double totalCalories = 0;

            foreach (var ingredient in Ingredients)
            {
               
                Console.WriteLine($"Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity}, Calories: {ingredient.Calories}");

                totalCalories += ingredient.Calories * ingredient.Quantity;
            }

            //  output to display the total calories
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                OnCalorieExceed?.Invoke("Warning: Total calories exceed 300!");
            }
        }
    }
}