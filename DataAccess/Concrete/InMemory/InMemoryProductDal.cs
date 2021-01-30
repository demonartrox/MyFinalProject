using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // _ global değişkenlerde kullanılır.

        public InMemoryProductDal(List<Product> products)
        {
            _products = products;
        }

        public InMemoryProductDal() //constructor, drek klasın ismi ile.
        {
            //Oracle, Sql, Postgres, MongoDb den geliyormuş gibi simüle ettik.
            _products = new List<Product> {
                new Product {ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product {ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product {ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product {ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product {ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (var p in _products) //bu döngü ile liste tek tek dolaşılıyor.
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            // LINQ Language Integrated Query = Dile Gömülü Sorgulama
            //yukarıdaki ifle dönme yerine aşağıdaki linq sorgusunu kullanıyoruz.
            //Lambda =>, her p için p nin productId si benim gönderdiğim id ye eşitse eşitle.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //tek bir eleman bulmaya yarar.

            _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        // bu kısım otomatik oluştu. ama aynı kodu aşağıya elle yazdığımız için burayı iptal ettik. yoksa çalışmıyor.
        //public List<Product> GetAllByCategory(int categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Product product) //ekrandan gelen data, güncellenecek ürün bilgisi.
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //tek bir eleman bulmaya yarar.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
