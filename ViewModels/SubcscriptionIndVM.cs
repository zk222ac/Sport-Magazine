using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Devices.HumanInterfaceDevice;
using Windows.UI.Popups;
using SportzMagazine.Catalogs;
using SportzMagazine.Models;
using SportzMagazine.Persistency;

namespace SportzMagazine.ViewModels
{
    public class SubcscriptionIndVM:ViewModelBase
    {

        private Facade facade;
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
        public string Password { get; set; }
        public IndApplicant App1 { get; set; }

        private SubscriptionCatalog subcatalog;
        private ApplicantCatalog appcatalog;
        private ObservableCollection<Models.Subscription> listInd;

        public ObservableCollection<Models.Subscription> ListInd
        {
            get
            {
                return listInd;
            }
            set { listInd = value; OnPropertyChanged("ListInd"); }
        }

        private SubscriptionCatalog sublist;
        public RelayCommand makeSubscription { get; set; }

        public SubcscriptionIndVM()
        {
            App1=new IndApplicant();
            subcatalog=new SubscriptionCatalog();
            appcatalog=new ApplicantCatalog();
            makeSubscription =new RelayCommand(MakeNewSubscription);
            ListInd=new ObservableCollection<Models.Subscription>();

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
                string password = Password;
                SubDuration subdur = SubDuration;
            //ValidationString(Name);
            //ValidationString(cardholder);
            Regex regexstring= new Regex("^[a-zA-Z]+$");
            //Regex regexemail=new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(add) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(cardholder) || string.IsNullOrEmpty(cardno) || string.IsNullOrEmpty(password) ||
                    Cvv == 0 || NumberOfCopies == 0)

            {
                CheckInput();
            }
            
            else if (!regexstring.IsMatch(cardholder))
            {
                CheckStringValidation();

            }
            //else if (!regexemail.IsMatch(email))
            //{
            //    CheckEmailValidation();
            //}
            else if (!regexstring.IsMatch(Name))
            {
                CheckStringValidation();
            }


            else
            {
                App1 = appcatalog.CreateIndApplicant(name, add, email, phone, cardholder, cardno, expdate,
                    cvv,password);
               Models.Subscription subscription = subcatalog.CreatIndividualSubs(App1, nocopy, subdur);
                ListInd.Add(subscription);
                facade.SaveSubscriptionAsXaml(ListInd);
            }

        }

        public async void CheckInput()
        {
            MessageDialog messageDialog = new MessageDialog("All filds must be filled!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 1;
            UICommand result = await messageDialog.ShowAsync() as UICommand;

        }
        public async void CheckStringValidation()
        {
            MessageDialog messageDialog = new MessageDialog("Invalid Name Or CardHolder Name!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 1;
            UICommand result = await messageDialog.ShowAsync() as UICommand;
            }
       

    }

       

        //public static void ValidationString(string input)
        //{
        //    Regex regex = new Regex("^[a-zA-Z]+$");

        //    if (!regex.IsMatch(input))
        //    {
        //        throw new InvalidINputString(input);
        //    }
        //}
    }

