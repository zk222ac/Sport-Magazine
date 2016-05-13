using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportzMagazine.Catalogs;
using SportzMagazine.Models;

namespace SportzMagazine.ViewModels
{
    class SubscriptionCorpVM:ViewModelBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string MailStop { get; set; }
        public string CompanyDepartment { get; set; }
        public int NumberOfCopies { get; set; }
        public SubDuration SubDuration { get; set; }
        public IList<SubDuration> SubsAmounts
        {
            get { return Enum.GetValues(typeof(SubDuration)).Cast<SubDuration>().ToList(); }

        }
        private SubscriptionCatalog subcatalog;
        private ApplicantCatalog appcatalog;
        private ObservableCollection<Models.Subscription> list;

        public ObservableCollection<Models.Subscription> List
        {
            get
            {
                return list;
            }
            set { list = value; OnPropertyChanged("List"); }
        }

        private SubscriptionCatalog sublist;
        public RelayCommand makeSubscriptioncorp { get; set; }

        public SubscriptionCorpVM()
        {
            subcatalog = new SubscriptionCatalog();
            appcatalog = new ApplicantCatalog();
            makeSubscriptioncorp = new RelayCommand(MakeNewSubscription);
            List = new ObservableCollection<Models.Subscription>();

        }

        private void MakeNewSubscription(object obj)
        {
            string name = Name;
            string add = Address;
            string email = Email;
            string phone = Phone;
            string title = Title;
            string mstop = MailStop;
            string cd = CompanyDepartment;
            int nocopy = NumberOfCopies;
            SubDuration subdur = SubDuration;
            CorporApplicant app = appcatalog.CreateCorpApplicant(name, add, email, phone, title, mstop, cd);
            Models.Subscription sub = subcatalog.CreatCorporateSubs(app, nocopy, subdur);
            List.Add(sub);

        }

    }
}
