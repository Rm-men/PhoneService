using ClassLibrary.EntityFynctions;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public partial class Product
    {
        public class ProductInfo
        {
            public string IdProduct { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int? Counts { get; set; }
            public string Type { get; set; }
            public ProductInfo (ProductInfo pr)
                {
                IdProduct = pr.IdProduct;
                Name = pr.Name;
                Price = pr.Price;
                Counts = pr.Counts;
                Type = pr.Type;
                }
            public ProductInfo()
            {
            }

        }
        public static void  UpdateCounts(List<ProductInfo> lp)
        {
            foreach (ProductInfo pi in lp)
            {
                Context.Db2.Products.Where(a => a.IdProduct == pi.IdProduct).FirstOrDefault().Counts = pi.Counts;
            }
            Context.Db2.SaveChanges();
        }
        public static List<ProductInfo> GetProducts()
        {
            List<ProductInfo> l_prod =  new List<ProductInfo>
                (from p in Context.Db2.Products
                    select new ProductInfo()
                    {
                        IdProduct = p.IdProduct,
                        Name = p.Name,
                        Price = p.Price,
                        Counts = p.Counts,
                        Type = "",
                    }).ToList();
            foreach (ProductInfo pi in l_prod)
            {
                pi.Type = GetUncm(pi.IdProduct);
            }
            return l_prod;
        }       
        public static decimal Total_Price(decimal pr, int  ?count)
        {
            decimal d = 0;
            for (;count>0;count--)
            {
                d += pr;
            }
            return d;
        }
        public static List<ProductInfo> GetProducts(PushareAgreement pa)
        {
            List<ProductInfo> l_prod =  new List<ProductInfo>
                (from p in Context.Db2.Products
                 join po in Context.Db2.PositionInOrders on p.IdProduct equals po.IdProduct
                 where po.IdPushareAgreement == pa.IdPushareAgreement

                 select new ProductInfo()
                    {
                        IdProduct = p.IdProduct,
                        Name = p.Name,
                        Price = Total_Price(p.Price, po.CountStaf),
                        Counts = po.CountStaf,
                        Type = "",
                    }).ToList();
            foreach (ProductInfo pi in l_prod)
            {
                pi.Type = GetUncm(pi.IdProduct);
            }
            return l_prod;
        }
        public static Product GettProduct(string IdProduct)
        {
            return Context.Db2.Products.Where(a => a.IdProduct == IdProduct).FirstOrDefault();
        }
        public static string GetUncm(string s)
        {
            var pr = Context.Db2.Components.Where(a => a.IdProduct == s).FirstOrDefault();
            if (pr != null)
                return "Компонент";
            else
                return "Компонент";
        }
    }
}
