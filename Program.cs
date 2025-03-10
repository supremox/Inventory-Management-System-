using System;
using System.Collections.Generic;

// Product class representing an item in inventory
class Product
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public int QuantityInStock { get; set; }
    public double Price { get; set; }
}

// Inventory Manager class handling operations
class InventoryManager
{
    // Creating a Temporary Storage were we will store all the products using List
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        // Condition to check if the values are correct 
        if (product.ProductId <= 0 || product.Price < 0 || product.QuantityInStock < 0) 
        {
            Console.WriteLine("Invalid product details. Ensure valid ID, price, and quantity.");
            return;
        }
        else if (string.IsNullOrEmpty(product.Name))
        {
            Console.WriteLine("Product name cannot be empty.");
            return;
        }

        // Adding the product to the end of the list 
        products.Add(product);
        Console.WriteLine("=================================================================== ");
        Console.WriteLine("\n\t\t\tProduct added successfully.");
        Console.WriteLine("=================================================================== ");

    }

    public void RemoveProduct(int productId)
    {
         // Condition to check if the values are correct 
        if (productId <= 0) 
        {
            Console.WriteLine("\nInvalid ID.");
            return;
        }
        // To Remove the Product from list using Product ID I used a BIF Find in the List that I created in Inventory Manager
        var product = products.Find(p => p.ProductId == productId);
        // if the Product ID matches it will display the Product Details and remove it Succesfully
        if (product != null)
        {
            Console.WriteLine($"\nID: {product.ProductId}, Name: {product.Name}, Quantity: {product.QuantityInStock}, Price: {product.Price:C}");
            products.Remove(product);
            Console.WriteLine("=================================================================== ");
            Console.WriteLine("\t\t\tProduct removed successfully.");
            Console.WriteLine("=================================================================== ");

        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void UpdateProduct(int productId, int newQuantity)
    {
         // Condition to check if the values are correct 
        if (productId <= 0 || newQuantity <= 0) 
        {
            Console.WriteLine("\nInvalid Id or Quantity cannot be negative..");
            return;
        }
        // same as removing product i also use BIF Find to find the product that will be updated
        var product = products.Find(p => p.ProductId == productId);
        // if the product ID match i add a condtion were the quantity should be a positive integer 
        if (product != null)
        {
            Console.WriteLine("=================================================================== ");
            Console.WriteLine($"\nID: {product.ProductId}, Name: {product.Name}, Quantity: {newQuantity}, Price: {product.Price:C}");
            product.QuantityInStock = newQuantity;
            Console.WriteLine("=================================================================== ");
            Console.WriteLine("\n\t\tProduct quantity updated successfully.");
            Console.WriteLine("=================================================================== ");

        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ListProducts() // in this function we will show the List all the products in the inventory  
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
        }
        else
        {   
            Console.WriteLine("=================================================================== ");
            Console.WriteLine("\nCurrent Inventory:\n");
            // by using foreach, it will display products in each line
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.QuantityInStock}, Price: {product.Price:C}");
                Console.WriteLine("=================================================================== ");

            }
        }
    }

    public double GetTotalValue() // this function is for getting the total value of  all the products in the inventory 
    {
        double totalValue = 0;
        // by using foreach it will compute the total by multiplying the Quantity stocks by its price of each products 
        // after getting the total amount of each products that are in the Inventory it will then add all the total value of each pruducts
        foreach (var product in products)
        {
            totalValue += product.QuantityInStock * product.Price;
        }
        return totalValue;
    }

}

class Program
{
    static void Main(string[] args)
    {
        //This instance, named inventory, 
        //is used to manage the inventory operations throughout the program.
        InventoryManager inventory = new InventoryManager(); 
        //  The while (true) loop is used to continuously display 
        // the inventory management menu and process user input until the user decides to exit the application.
        while (true)
        {
            Console.WriteLine("\n=================== Inventory Management System =================== ");
            Console.WriteLine("=================================================================== ");
            Console.WriteLine("\t\t\t1. Add Product");
            Console.WriteLine("\t\t\t2. Remove Product");
            Console.WriteLine("\t\t\t3. Update Product Quantity");
            Console.WriteLine("\t\t\t4. List Products");
            Console.WriteLine("\t\t\t5. Get Total Inventory Value");
            Console.WriteLine("\t\t\t6. Exit");
             Console.WriteLine("=================================================================== ");
            Console.Write("\n\t\t\tEnter your choice: ");
            
            // this line [ int.TryParse(Console.ReadLine(), out int choice) ] reads the user's input from the console, 
            // tries to convert it to an integer, and stores the result in the choice variable. 
            // If the conversion is successful, the if condition will be true, 
            // and the program will proceed to the switch statement to handle the user's choice. 
            // If the conversion fails, the else block will execute, 
            // indicating that the input was invalid.
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("=================================================================== ");
                        Console.Write("\nEnter Product ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine() ?? string.Empty; // this line is for checking if has value or not
                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        double price = Convert.ToInt32(Console.ReadLine());
                        // all the data will be combined in to single cluster of data and will be stored in the List that was created in function AddProduct
                        // inventory.integerValidation(id,name, quantity, price);
                        inventory.AddProduct(new Product { ProductId = id, Name = name, QuantityInStock = quantity, Price = price });
                        break;

                    case 2:
                        Console.WriteLine("=================================================================== ");
                        Console.Write("\nEnter Product ID to remove: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        // the Value will now pass to the function RemoveProduct 
                        inventory.RemoveProduct(removeId);
                        break;
                    case 3:
                        Console.WriteLine("=================================================================== ");
                        Console.Write("\nEnter Product ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new Quantity: ");
                        int newQty = Convert.ToInt32(Console.ReadLine());
                        // the Value will now pass to the function UpdateProdut
                        inventory.UpdateProduct(updateId, newQty);
                        break;
                    case 4:
                        Console.WriteLine("=================================================================== ");
                        // methos is called to get all the products in the inventory
                        inventory.ListProducts();
                        break;
                    case 5:
                        Console.WriteLine("=================================================================== ");
                        // method is called to get the total value of all products in the inventory.
                        Console.WriteLine($"\nTotal Inventory Value: {inventory.GetTotalValue():C}");
                        Console.WriteLine("=================================================================== ");

                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1-6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number.");
            }
        }
    }
}
