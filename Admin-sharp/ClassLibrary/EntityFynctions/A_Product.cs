using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.EntityFynctions
{
    public abstract class A_Product
    {
        public abstract class ProductInfo
        {
            public string IdProduct { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int? Counts { get; set; }
            public string Type { get; set; }
            public string Get(string s)
            {
                return Type;
            }
            public A_Product GetP()
            {
                return A_Product.GetUncm(IdProduct);
            }

        }
            //public abstract ProductInfo GetInfo();

            public abstract void To_udpate();
            public abstract string Ret_Type();

            public abstract A_Product Get();


        

        public static A_Product GetUncm(string s)
        {
            var pr = Context.Db2.Components.Where(a => a.IdProduct == s).FirstOrDefault();
            if (pr != null)
                return Context.Db2.Components.Where(a => a.IdProduct == s).FirstOrDefault();
            else return Context.Db2.PhoneModels.Where(a => a.IdProduct == s).FirstOrDefault();
        }
    }
}