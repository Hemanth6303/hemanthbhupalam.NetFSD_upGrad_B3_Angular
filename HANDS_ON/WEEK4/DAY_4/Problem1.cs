namespace ConsoleApp1
{

    class Product
    {
        private int productId;
        private String productName;
        private double unitPrice;
        private int quantity;

        public Product(int productId)
        {
            this.productId = productId;
        }
        public int ProductId
        {
            get { return productId; }
        }
        public String ProductName
        {
            set { productName = value; }
            get { return productName; }
        }
        public double UnitPrice
        {
            set { unitPrice= value; }
            get { return unitPrice; }

        }
        public int Quantity
        {
            set { quantity = value; }
            get { return quantity; }
        }

        public void showDetails()
        {
            double Amount = UnitPrice * quantity;

            Console.WriteLine(" productId "+ productId + " productName "+productName+" TotalAmount "+Amount);
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the productId: ");
            String input=Console.ReadLine();
            int productId;
            int.TryParse(input, out productId);
            Product productobj = new Product(productId);


            Console.WriteLine("Enter the product Name");
            productobj.ProductName = Console.ReadLine();

            Console.WriteLine("Enter the product Price");
            String input1 = Console.ReadLine();
            double productPrice;
            double.TryParse(input1, out productPrice);
            productobj.UnitPrice = productPrice;

            Console.WriteLine("Enter the product Quantity");
            String input2 = Console.ReadLine();
            int productQuantity;
            int.TryParse(input2, out productQuantity);
            productobj.Quantity = productQuantity;

            productobj.showDetails();

        }
    }
}
