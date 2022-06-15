using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Frames
{
    public static class FunctionsOnPages
    {
        public static bool TB_NotNuls(params TextBox[] tbs)
        {
            foreach (TextBox tb in tbs)
            {
                if (tb.Text == "")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
