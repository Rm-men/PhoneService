using ClassLibrary.EntityFynctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class Component : A_Product
    {
        public override A_Product Get()
        {
            return this;
            //throw new NotImplementedException();
        }

        public override void To_udpate()
        {

        }
        public override string Ret_Type()
        {
            return this.TypeC;
        }
    }
}
