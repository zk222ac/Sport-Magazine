using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportzMagazine.ViewModels
{
    class InvalidINputString:Exception
    {
        public InvalidINputString(string name):base(string.Format("Invalid Input! {0}",name))
        {

        }
    }
}
