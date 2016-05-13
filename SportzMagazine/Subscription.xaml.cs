using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using SportzMagazine.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SportzMagazine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Subscription : Page
    {
        private IndApplicant a;
        private int n;
        private int s;

        public Subscription(object a1)
        {
            this.InitializeComponent();
        }

        public Subscription(object a1, int n, int s) : this(a1)
        {
            this.n = n;
            this.s = s;
        }

        public Subscription(IndApplicant a, int n, int s)
        {
            this.a = a;
            this.n = n;
            this.s = s;
        }
    }
}
