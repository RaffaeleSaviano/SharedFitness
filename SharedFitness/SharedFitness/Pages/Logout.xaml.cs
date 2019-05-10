using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharedFitness.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Logout : ContentPage
	{
		public Logout ()
		{
			InitializeComponent ();
            logout();
            backtologin();
        }

        private void backtologin()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                /*MasterDetailPage mdp = Application.Current.MainPage as MasterDetailPage;
                if (mdp != null)
                {
                    mdp.Detail = null;
                    mdp.Master = null;
                }*/
                Application.Current.MainPage = new Login();

            });
        }

        public void logout()
        {
            if (Application.Current.Properties.ContainsKey("Username") && Application.Current.Properties.ContainsKey("Password"))
            {
                Application.Current.Properties.Remove("Username");
                Application.Current.Properties.Remove("Password");  
            }
        }
    }
}