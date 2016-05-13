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
            //ValidationString(Name);
            //ValidationString(cardholder);
            Regex regexstring= new Regex("^[a-zA-Z]+$");
            //Regex regexemail=new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$");
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email) ||
                    string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(CardHolder) || string.IsNullOrEmpty(CardNo) ||
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
                IndApplicant appind = appcatalog.CreateIndApplicant(name, add, email, phone, cardholder, cardno, expdate,
                    cvv);
                Models.Subscription sub = subcatalog.CreatIndividualSubs(appind, nocopy, subdur);
                List.Add(sub);
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
            MessageDialog messageDialog = new MessageDialog("Invalid Email address!");
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

