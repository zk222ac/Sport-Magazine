using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportzMagazine.Models
{
   public  class AdminModel
    {
       
        private string _userName;
        private string _password;
       
       public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

       public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        //Constructor
        public AdminModel(string username, string password)
        {
            this._userName = username;
            this._password = password;

        }

        public AdminModel() { }

    }
}
