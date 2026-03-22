using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Product
{
    public int ProductCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Mrp { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>()
        {
            new Product{ ProductCode=101, ProductName="Soap", Category="FMCG", Mrp=25 },
            new Product{ ProductCode=102, ProductName="Shampoo", Category="FMCG", Mrp=45 },
            new Product{ ProductCode=103, ProductName="Rice", Category="Grain", Mrp=60 },
            new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
            new Product{ ProductCode=105, ProductName="Oil", Category="FMCG", Mrp=120 },
            new Product{ ProductCode=106, ProductName="Dal", Category="Grain", Mrp=80 },
            new Product{ ProductCode=107, ProductName="paste", Category="FMCG", Mrp=40 }

        };

        // 1. FMCG Products
         var q1 = from p in products
         where p.Category == "FMCG"
         select p;
        Display(q1);

        // 2. Grain Products
        var q2 = from p in products
         where p.Category == "Grain"
         select p;
        Display(q2);

        // 3. Sort by Product Code
        Console.WriteLine("\n3. Sort by Product Code:");
        var q3 = from p in products
         orderby p.ProductCode
         select p;
        Display(q3);

        // 4. Sort by Category
        Console.WriteLine("\n4. Sort by Category:");
        var q4 = from p in products
         orderby p.Category
         select p;
        Display(q4);

        // 5. Sort by MRP (Ascending)
        Console.WriteLine("\n5. Sort by MRP Asc:");
        var q5 = from p in products
         orderby p.Mrp
         select p;
        Display(q5);

        // 6. Sort by MRP (Descending)
        Console.WriteLine("\n6. Sort by MRP Desc:");
        var q6 = from p in products
         orderby p.Mrp descending
         select p;
        Display(q6);

        // 7. Group by Category
        Console.WriteLine("\n7. Group by Category:");
        var q7 = from p in products
         group p by p.Category;
        foreach (var group in q7)
        {
            Console.WriteLine($"Category: {group.Key}");
            Display(group);
        }
        /*
        GroupBy → List of Groups
        Each Group:
        Key = grouping value
        Items = list of matching elements*/
        // 8. Group by MRP
        Console.WriteLine("\n8. Group by MRP:");
        var q8 = from p in products
         group p by p.Mrp;
        foreach (var group in q8)
        {
            Console.WriteLine($"MRP: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"   {p.ProductName}");
        }

        // 9. Highest Price in FMCG
        Console.WriteLine("\n9. Highest Price FMCG:");
        var q9 = (from p in products
          where p.Category == "FMCG"
          orderby p.Mrp descending
          select p).FirstOrDefault();
        Console.WriteLine($"{q9.ProductName} - {q9.Mrp}");

        // 10. Total Count
        Console.WriteLine("\n10. Total Products:");
        var q10 = (from p in products
           select p).Count();
        Console.WriteLine(q10);


        // 11. FMCG Count
        Console.WriteLine("\n11. FMCG Count:");
        var q11 = (from p in products
           where p.Category == "FMCG"
           select p).Count();
         Console.WriteLine(q11);
        
        // 12. Max Price
        Console.WriteLine("\n12. Max Price:");
        var q12 = (from p in products
           select p.Mrp).Max();

        Console.WriteLine(q12);

        // 13. Min Price
        Console.WriteLine("\n13. Min Price:");
        var q13 = (from p in products
           select p.Mrp).Min();

        Console.WriteLine(q13);

        // 14. All below 30?
        
        Console.WriteLine("\n14. All below 30:");
        var q14 = (from p in products
           select p).All(p => p.Mrp < 30);
         Console.WriteLine(q14);
        
        // 15. Any below 30? 
        //Atleast one should be there below 30 then it will return true otherwise it return false
        Console.WriteLine("\n15. Any below 30:");
        var q15 = (from p in products
           select p).Any(p => p.Mrp < 30);
         Console.WriteLine(q15);
        
    }

    // Common display method
    static void Display(IEnumerable<Product> list)
    {
        foreach (var p in list)
        {
            Console.WriteLine($"{p.ProductCode} - {p.ProductName} - {p.Category} - {p.Mrp}");
        }
    }
}