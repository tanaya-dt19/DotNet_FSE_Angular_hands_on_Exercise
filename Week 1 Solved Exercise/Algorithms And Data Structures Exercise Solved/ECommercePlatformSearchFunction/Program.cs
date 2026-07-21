using System;

class Product {
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category) {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program {
    //Linear Search
    static Product LinearSearch(Product[] products, int id) { 
        foreach(Product p in products)
        {
            if(p.ProductId == id)
            {
                return p;
            }
        }
        return null;
    }

    //Binary Search
    static Product BinarySearch(Product[] products, int id)
    {
        int left = 0;
        int right = products.Length - 1;

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if (products[mid].ProductId == id)
            {
                return products[mid];
            }

            if(id < products[mid].ProductId)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return null;
    }

    static void Main(string[] args)
    {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Mouse", "Electronics"),
            new Product(103, "Mobile", "Electronics"),
            new Product(104, "Cloths", "Fashion"),
            new Product(105, "Printer", "Electronics")
        };

        //Linear Search
        int searchId1 = 104;
        Product result1 = LinearSearch(products, searchId1);

        if(result1 != null)
        {
            Console.WriteLine("Linear Search Found : "+ result1.ProductName);
        }

        //Binary Search
        int searchId2 = 103;
        Product result2 = BinarySearch(products, searchId2);

        if(result2 != null)
        {
            Console.WriteLine("Binary Search Found: " + result2.ProductName);
        }

        Console.ReadKey();
    }
}