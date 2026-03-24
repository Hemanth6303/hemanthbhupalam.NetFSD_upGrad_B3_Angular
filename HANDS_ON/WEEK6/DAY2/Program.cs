using ConsoleApp1;

class Program
{
    static void Main()
    {
        ProductDAO dao = new ProductDAO();

        while (true)
        {
            Console.WriteLine("\n1. Insert\n2. View\n3. Update\n4. Delete\n5. SELECT \n5. Exit");
            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Product p = new Product();

                        Console.Write("Name: ");
                        p.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        p.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        p.Price = Convert.ToDecimal(Console.ReadLine());

                        dao.InsertProduct(p);
                        Console.WriteLine("Inserted successfully!");
                        break;

                    case 2:
                        var products = dao.GetAllProducts();
                        foreach (var item in products)
                            Console.WriteLine(item);
                        break;

                    case 3:
                        Product up = new Product();

                        Console.Write("Enter ID: ");
                        up.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("New Name: ");
                        up.ProductName = Console.ReadLine();

                        Console.Write("New Category: ");
                        up.Category = Console.ReadLine();

                        Console.Write("New Price: ");
                        up.Price = Convert.ToDecimal(Console.ReadLine());

                        dao.UpdateProduct(up);
                        Console.WriteLine("Updated successfully!");
                        break;

                    case 4:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        dao.DeleteProduct(id);
                        Console.WriteLine("Deleted successfully!");
                        break;
                    case 5:
                        Console.Write("Enter ID: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());

                        var product= dao.GetProductById(id1);
                        if(product!=null)
                           Console.WriteLine(product);
                        else
                            Console.WriteLine("product not found!");

                        break;

                    case 6:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}