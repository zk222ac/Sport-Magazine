using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.Catalogs;
using SportzMagazine.Models;
using SportzMagazine.Persistency;

namespace SportzMagazine.ViewModels
{
    public class RenewVM: ViewModelBase
    {
        public int NoOfCopies { get; set; }
        public SubDuration SubsDuration { get; set; }
        private ObjectClean clean;
        private ObservableCollection<Subscription> listOfRenews;

        public ObservableCollection<Subscription> ListOfRenews {
            get { return  listOfRenews; }
            set { listOfRenews= value;OnPropertyChanged("ListOfRenews");}
        }

        public IList<SubDuration> SubsAmounts{get { return Enum.GetValues(typeof(SubDuration)).Cast<SubDuration>().ToList(); }}

        public RelayCommand RenewIndividualSubscription { get; set; }
        public RelayCommand RenewCorporateSubscription { get; set; }

        private SubscriptionCatalog subcatalog;
        private IndApplicant App1= new IndApplicant();
        private CorporApplicant App2= new CorporApplicant();
        public RenewVM()
        {
            RenewIndividualSubscription= new RelayCommand(RenewIndividual);

            RenewCorporateSubscription = new RelayCommand(RenewCorporate);
            clean = new ObjectClean();
            subcatalog = new SubscriptionCatalog();
            ListOfRenews= new ObservableCollection<Subscription>();
        }

        public async void RenewIndividual(object obj)
        {
            int noCopies = NoOfCopies;
            SubDuration subscrDuration = SubsDuration;
            Subscription subscr1 = subcatalog.CreatIndividualSubs(App1, noCopies, SubsDuration);
            ListOfRenews.Add(subscr1);
            clean.SaveIndividual(ListOfRenews);
        }
        public async void RenewCorporate(object obj)
        {
            int noCopies = NoOfCopies;
            SubDuration subscrDuration = SubsDuration;
            Subscription subscr2 = subcatalog.CreatCorporateSubs(App2, noCopies, SubsDuration);
            ListOfRenews.Add(subscr2);
            clean.SaveCorporate(ListOfRenews);
        }
    }


}
