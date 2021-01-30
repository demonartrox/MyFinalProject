using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _Productdal;

        public ProductManager(IProductDal productdal)
        {
            _Productdal = productdal;
        }

        public List<Product> GetAll()
        {
            //İş Kodları
            //yetkisi var mı
            return _Productdal.GetAll();
        }
    }
}
