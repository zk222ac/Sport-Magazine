using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportzMagazine.Models
{
    public class IndApplicant:Applicant
    {
        //private string cardHolder;
        //private string cardNo;
        //private string expDate;
        //private int cvv;

        public string CardHolder { get; set; }
        public string CardNo { get; set; }
        public DateTime ExpDate { get; set; }
        public int Cvv { get; set; }

        
    }
}
