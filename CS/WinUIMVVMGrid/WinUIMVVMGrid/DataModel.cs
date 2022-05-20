using System;
using System.Collections.ObjectModel;

namespace WinUIMVVMGrid {
    public class Product {
        public string ProductName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class ProductsDataModel {
        public static ObservableCollection<Product> GetProducts() {
            ObservableCollection<Product> products = new ObservableCollection<Product> {
                new Product() {
                    ProductName = "Chang", Country = "UK", City = "Cowes",
                    UnitPrice = 19, Quantity = 10, OrderDate = new DateTime(2021, 10, 23)
                },
                new Product() {
                    ProductName = "Gravad lax", Country = "Italy", City = "Reggio Emilia",
                    UnitPrice = 12.5, Quantity = 16, OrderDate = new DateTime(2021, 10, 22)
                },
                new Product() {
                    ProductName = "Ravioli Angelo", Country = "Brazil", City = "Rio de Janeiro",
                    UnitPrice = 19, Quantity = 12, OrderDate = new DateTime(2021, 10, 21)
                },
                new Product() {
                    ProductName = "Tarte au sucre", Country = "Germany", City = "Leipzig",
                    UnitPrice = 22, Quantity = 50, OrderDate = new DateTime(2021, 10, 15)
                },
                new Product() {
                    ProductName = "Steeleye Stout", Country = "USA", City = "Denver",
                    UnitPrice = 18, Quantity = 20, OrderDate = new DateTime(2021, 10, 8)
                },
                new Product() {
                    ProductName = "Pavlova", Country = "Austria", City = "Graz",
                    UnitPrice = 21, Quantity = 52, OrderDate = new DateTime(2021, 10, 1)
                },
                new Product() {
                    ProductName = "Longlife Tofu", Country = "USA", City = "Boise",
                    UnitPrice = 7.75, Quantity = 120, OrderDate = new DateTime(2021, 9, 17)
                },
                new Product() {
                    ProductName = "Alice Mutton", Country = "Mexico", City = "México D.F.",
                    UnitPrice = 21, Quantity = 15, OrderDate = new DateTime(2021, 9, 25)
                }
            };
            return products;
        }
    }
}
