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
    public class SubcscriptionIndVM : ViewModelBase
    {

       
        private ObjectClean clean;
        private DateTime _expDate;
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardHolder { get; set; }
        public string CardNo { get; set; }

        public DateTime ExpDate
        {
            get { return _expDate; }
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
            get { return Enum.GetValues(typeof (SubDuration)).Cast<SubDuration>().ToList(); }

        }

        public int Cvv { get; set; }
        public string Password { get; set; }
        public IndApplicant App1 { get; set; }

        private SubscriptionCatalog subcatalog;
        private ApplicantCatalog appcatalog;
        private ObservableCollection<Subscription> listInd;

        public ObservableCollection<Subscription> ListInd
        {
            get { return listInd; }
            set
            {
                listInd = value;
                OnPropertyChanged("ListInd");
            }
        }

        public RelayCommand makeSubscription { get; set; }

        public SubcscriptionIndVM()
        {
            App1 = new IndApplicant();
            subcatalog = new SubscriptionCatalog();
            appcatalog = new ApplicantCatalog();
            makeSubscription = new RelayCommand(MakeNewSubscription);
            ListInd = new ObservableCollection<Subscription>();
            clean = new ObjectClean();

            // load default data which is avaliable in the file
            //LoadDafaultData();
        }

        public async void MakeNewSubscription(object obj)
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

            
            Regex regexstring = new Regex("^[a-zA-Z]+$");
            Regex regexEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            Regex regexphone = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(add) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(cardholder) || string.IsNullOrEmpty(cardno) ||
                string.IsNullOrEmpty(password) ||
                Cvv == 0 || NumberOfCopies == 0)

            {
                CheckInput();
            }

            else if (!regexstring.IsMatch(name))
            {
                CheckStringValidation();

            }
            else if (!regexstring.IsMatch(cardholder))
            {
                CheckStringValidation();
            }
            else if (!regexEmail.IsMatch(email))
            {
                CheckEmailValidation();
            }

            //else if (!regexphone.IsMatch(phone))
            //{
            //    CheckPhoneValidation();
            //}


            App1 = appcatalog.CreateIndApplicant(name, add, email, phone, cardholder, cardno, expdate,
                cvv, password);

            Subscription subscription = subcatalog.CreatIndividualSubs(App1, nocopy, subdur);

            ListInd.Add(subscription);
            clean.SaveIndividual(ListInd);

            //LoadDafaultData();

        }

        public async void LoadDafaultData()
        {
            try
            {
                ObservableCollection<Subscription> subscriptions = await clean.LoadIndividual();
                this.ListInd = subscriptions;
            }
            catch (Exception exception)
            {
               listInd.Clear();
                
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

        public async void CheckEmailValidation()
        {
            MessageDialog messageDialog = new MessageDialog("Invalid Email!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 1;
            UICommand result = await messageDialog.ShowAsync() as UICommand;
        }

        public async void CheckPhoneValidation()
        {
            MessageDialog messageDialog = new MessageDialog("INVALID PHONE NUMBER!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 1;
            UICommand result = await messageDialog.ShowAsync() as UICommand;

        }

       

    }
}

