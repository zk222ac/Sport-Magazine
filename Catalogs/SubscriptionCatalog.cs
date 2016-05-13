using SportzMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.ViewModels;

namespace SportzMagazine.Catalogs
{
    public class SubscriptionCatalog
    {
        private List<Models.Subscription> subsList;
        

        public SubscriptionCatalog()
        {
            subsList = new List<Models.Subscription>();
        }


        public Models.Subscription CreatIndividualSubs(IndApplicant a,int n,  SubDuration s)
        {
           Models.Subscription subind=new Models.Subscription {App1 = a,NumberOfCopies = n,SubDuration =s };
            subsList.Add(subind);
            return subind;
        }

        public Models.Subscription CreatCorporateSubs(CorporApplicant a, int n, SubDuration s)
        {
            Models.Subscription subcorp= new Models.Subscription {App2 = a,NumberOfCopies = n,SubDuration = s};
            subsList.Add(subcorp);
            return subcorp;
        }


        

    }
}
