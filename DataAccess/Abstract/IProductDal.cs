using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //operasyonları yapacağız. getir, götür, ekle, sil gibi. interface metodları (add, update, delete vb) default publictir. ama kendi değildir.
    public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId); //ürünleri kategoriye göre filtrele kodu

    }
}
