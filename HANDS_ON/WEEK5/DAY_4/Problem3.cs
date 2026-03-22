using System;

class EmployeePerformance
{
    // Method returning Tuple
    public static (double sales, int rating) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }

    static void Main()
    {
        // 1. Input
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Monthly Sales Amount: ");
        double sales = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Customer Rating (1-5): ");
        int rating = Convert.ToInt32(Console.ReadLine());

        // 2. Get Tuple values
        var (empSales, empRating) = GetPerformanceData(sales, rating);

        // 3. Pattern Matching using switch expression
        string performance = (empSales, empRating) switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        // 4. Output
        Console.WriteLine("\n----- Employee Performance -----");
        Console.WriteLine($"Employee Name : {name}");
        Console.WriteLine($"Sales Amount  : {empSales}");
        Console.WriteLine($"Rating        : {empRating}");
        Console.WriteLine($"Performance   : {performance}");
    }
}