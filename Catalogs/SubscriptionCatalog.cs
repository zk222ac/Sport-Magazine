using SportzMagazine.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.ViewModels;


namespace SportzMagazine.Catalogs
{
    public class SubscriptionCatalog
    {
        private ObservableCollection<Subscription> subsList;
        

        public SubscriptionCatalog()
        {
            subsList = new ObservableCollection<Subscription>();
        }


        public Subscription CreatIndividualSubs(IndApplicant a,int n,  SubDuration s)
        {
           Subscription subind=new Subscription {App1 = a,NumberOfCopies = n,SubDuration =s };
            subsList.Add(subind);
            return subind;
        }

        public Subscription CreatCorporateSubs(CorporApplicant a, int n, SubDuration s)
        {
            Subscription subcorp= new Subscription {App2 = a,NumberOfCopies = n,SubDuration = s};
            subsList.Add(subcorp);
            return subcorp;
        }


        

    }
}
