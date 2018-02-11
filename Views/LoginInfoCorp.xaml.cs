using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SportzMagazine.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SportzMagazine.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginInfoCorp : Page
    {
        public LoginInfoCorp()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Subscription passedParameter = e.Parameter as Subscription;
            Applicant app = new Applicant();

            //if (e.Parameter == passedParameter.App1)
            //{
            name.Text = passedParameter.App2.Name.ToString();
            address.Text = passedParameter.App2.Address.ToString();
            email.Text = passedParameter.App2.Email.ToString();
            phone.Text = passedParameter.App2.Phone.ToString();
            noOfCopies.Text = passedParameter.NumberOfCopies.ToString();
            subsDuration.Text = passedParameter.SubDuration.ToString();
            //    }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SubmitionMessage));
        }
    }
}
