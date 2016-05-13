using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.HumanInterfaceDevice;
using SportzMagazine.Catalogs;
using SportzMagazine.Models;

namespace SportzMagazine.ViewModels
{
    public class SubcscriptionIndVM:ViewModelBase
    {
        private DateTime _expDate;
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardHolder { get; set; }
        public string CardNo { get; set; }

        public DateTime ExpDate
        {
            get
            {
                return _expDate;
            }
            set
            {
                _expDate = value;
                string format = value.ToString("Y");




            }
        }

        public int NumberOfCopies { get; set; }
        //Combobox binding
        public SubDuration SubDuration { get; set; }
        //Get enum values, convert them into a list. You can see the binding on the UI :)
        public IList<SubDuration> SubsAmounts
        {
            get { return Enum.GetValues(typeof(SubDuration)).Cast<SubDuration>().ToList(); }



        }
        public int Cvv { get; set; }
        private SubscriptionCatalog subcatalog;
        private ApplicantCatalog appcatalog;
        private ObservableCollection<Models.Subscription> list;

        public ObservableCollection<Models.Subscription> List
        {
            get
            {
                return list;
            }
            set { list = value; OnPropertyChanged(); }
        }

        private SubscriptionCatalog sublist;
        public RelayCommand makeSubscription { get; set; }

        public SubcscriptionIndVM()
        {
            subcatalog=new SubscriptionCatalog();
            appcatalog=new ApplicantCatalog();
            makeSubscription =new RelayCommand(MakeNewSubscription);
            List=new ObservableCollection<Models.Subscription>();

        }

        private void MakeNewSubscription(object obj)
        {
            string name = Name;
            string add = Address;
            string email = Email;
            string phone = Phone;
            string cardholder = CardHolder;
            string cardno = CardNo;
            DateTime expdate = ExpDate;
            int cvv = Cvv;
            int nocopy = NumberOfCopies;
            SubDuration subdur = SubDuration;
            IndApplicant appind = appcatalog.CreateIndApplicant(name, add, email, phone, cardholder, cardno, expdate, cvv);
            Models.Subscription sub = subcatalog.CreatIndividualSubs(appind, nocopy, subdur);
            List.Add(sub);

        }
    }
}
