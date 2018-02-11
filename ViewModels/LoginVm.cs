using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SportzMagazine.Models;
using SportzMagazine.Persistency;
using SportzMagazine.Views;

namespace SportzMagazine.ViewModels
{
  
    
   public class LoginVm:ViewModelBase
   {
       private ObjectClean objClean;
    
        public string Email { get; set; }
        public string Password { get; set; }


       public ObservableCollection<Subscription> UserCatalog;
       public RelayCommand UserLogInIndividual { get; set; }
        public RelayCommand UserLogInCorporate { get; set; }

        public LoginVm()
        {
            UserCatalog = new ObservableCollection<Subscription>();
            UserLogInIndividual = new RelayCommand(DoLogInIndividual);
            UserLogInCorporate = new RelayCommand(DoLogInCorporate);
            objClean = new ObjectClean();
        }

       public async void DoLogInIndividual(object oj)
       {
           try
           {
               ObservableCollection<Subscription> sb = await objClean.LoadIndividual();

               foreach (var user in sb)
                {
                    if ((user.App1.Email == Email) && (user.App1.Password == Password))
                    {

                        this.UserCatalog = sb;
                        //SetSelectedSubscription();

                        Frame frame = new Frame();
                        frame.Navigate(typeof(LoginInfo), user);
                        Window.Current.Content = frame;
                        Window.Current.Activate();

                    }
                   }
           }
           catch (Exception ex)
           {
               
           }

       }
        public async void DoLogInCorporate(object oj)
        {
            try
            {
                ObservableCollection<Subscription> sb = await objClean.LoadCorporate();

                foreach (var user in sb)
                {
                    if ((user.App2.Email == Email) && (user.App2.Password == Password))
                    {

                        this.UserCatalog = sb;
                        //SetSelectedSubscription();

                        Frame frame = new Frame();
                        frame.Navigate(typeof(LoginInfoCorp), user);
                        Window.Current.Content = frame;
                        Window.Current.Activate();

                    }
                  
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
