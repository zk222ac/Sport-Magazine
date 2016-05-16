using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using SportzMagazine.Catalogs;
using SportzMagazine.Models;
using SportzMagazine.Persistency;

namespace SportzMagazine.ViewModels
{
    class SubscriptionCorpVM : ViewModelBase
    {
        private Facade facade;

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string MailStop { get; set; }
        public string CompanyDepartment { get; set; }
        public int NumberOfCopies { get; set; }
        public string Password { get; set; }

        public SubDuration SubDuration { get; set; }

        public IList<SubDuration> SubsAmounts
        {
            get { return Enum.GetValues(typeof (SubDuration)).Cast<SubDuration>().ToList(); }

        }

        private SubscriptionCatalog subcatalog;
        private ApplicantCatalog appcatalog;
        private ObservableCollection<Models.Subscription> list;

        public ObservableCollection<Models.Subscription> List
        {
            get { return list; }
            set
            {
                list = value;
                OnPropertyChanged("List");
            }
        }
        public CorporApplicant App2 { get; set; }

        private SubscriptionCatalog sublist;
        public RelayCommand makeSubscriptioncorp { get; set; }

        public SubscriptionCorpVM()
        { 
            App2=new CorporApplicant();
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
            string password = Password;
            SubDuration subdur = SubDuration;

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(MailStop) ||
                string.IsNullOrEmpty(CompanyDepartment) || NumberOfCopies == 0||string.IsNullOrEmpty(Password))
            {
                CheckInput();
            }
            else
            {
                App2= appcatalog.CreateCorpApplicant(name, add, email, phone, title, mstop, cd,password);
                Models.Subscription sub = subcatalog.CreatCorporateSubs(App2, nocopy, subdur);
                List.Add(sub);
                facade.SaveSubscriptionAsXaml(List);

            }
        }

        public async void CheckInput()
        {

            MessageDialog messageDialog = new MessageDialog("All filds must be filled!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 1;
            UICommand result = await messageDialog.ShowAsync() as UICommand;

        }
    }
}
