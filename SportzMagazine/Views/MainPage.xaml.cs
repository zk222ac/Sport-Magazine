﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SportzMagazine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFram.Navigate(typeof (HomePage));
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFram.CanGoBack)
            {
                MainFram.GoBack();
            }        }

       

        private void Forward_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFram.CanGoForward)
            {
                MainFram.GoForward();
            }
        }


        private void Home_OnClick(object sender, RoutedEventArgs e)
        {
            MainFram.Navigate(typeof(HomePage));
        }
    }
}
