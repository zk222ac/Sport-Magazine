using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SportzMagazine.Models;
using SportzMagazine.Persistency;
using SportzMagazine.Views;

namespace SportzMagazine.ViewModels
{
    public class AdminVM:ViewModelBase
    {
        private ObjectClean objClean;
        private ObservableCollection<Subscription> list1;
        private ObservableCollection<Subscription> list2;

        public IndApplicant App1 { get; set; }
        public CorporApplicant App2 { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        public AdminModel Admin { get; set; }
        public ObservableCollection<Subscription> List1 {get { return list1; }set { list1 = value;OnPropertyChanged("List1"); } }
        public ObservableCollection<Subscription> List2 { get { return list1; } set { list1 = value;OnPropertyChanged("List2"); } }

        public ObservableCollection<AdminModel> AdminList { get; set; }

        public RelayCommand LoginAdmin { get; set; }

        public AdminVM()
        {
            objClean=new ObjectClean();
            list1 =new ObservableCollection<Subscription>();
            list2 = new ObservableCollection<Subscription>();

            AdminList = new ObservableCollection<AdminModel>();
            Admin=new AdminModel();
            LoginAdmin = new RelayCommand(DoLoginAdmin);
            AdminList.Add(new AdminModel("Admin1","Admin1"));
           

        }

        public async void LoadDafaultData()
        {
            try
            {
                ObservableCollection<Subscription> subscriptions1 = await objClean.LoadIndividual();
                ObservableCollection<Subscription> subscriptions2 = await objClean.LoadCorporate();

                List1= subscriptions1;
                List2 = subscriptions2;
            }
            catch (Exception exception)
            {
                List1.Clear();

            }

        }
        
        public async void DoLoginAdmin(object ob)
        {
            try
            {
              foreach (var admin in AdminList)
                {
               if ((admin.UserName ==Admin.UserName ) && (admin.Password == Admin.Password))
               {
                        LoadDafaultData();

                        //Frame frame = new Frame();
                        //frame.Navigate(typeof(Admin), list1);
                        //frame.Navigate(typeof(Admin), list2);
                        //Window.Current.Content = frame;
                        //Window.Current.Activate();

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
