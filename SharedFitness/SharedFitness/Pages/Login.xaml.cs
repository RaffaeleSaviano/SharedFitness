using SharedFitness.Model;
using SharedFitness.Network.WebServers;
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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += LabelClicked;
            Register.GestureRecognizers.Add(tgr);
		}

        private void Submit_Clicked(object sender, EventArgs e)
        {
            string user = Username.Text;
            string pw = Password.Text;
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                LoadAI.IsRunning = true;
                LoadAI.IsEnabled = true;
                LoadAI.IsVisible = true;
                Submit.IsEnabled = false;
            });
            Login_Action(user,pw);
        }

        public async void Login_Action(string user, string pw)
        {
            User u = new User()
            {
                Username = user,
                Password = pw
            };
            bool result = await SFWebServer.Main.Login(u);
            if (result)
            {
                u = (await SFWebServer.Main.Get<IEnumerable<User>>(Network.WebServers.SFResources.User, "Username", u.Username)).First();
                ((App)Application.Current).MainSFapp.User = u;
                Application.Current.MainPage = new MainPageCS();
            }
            else
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {
                    LoadAI.IsRunning = false;
                    LoadAI.IsVisible = false;
                    LoadAI.IsEnabled = false;
                    Submit.IsEnabled = true;
                });

            }
        }

        void ChangePasswordView(object view, EventArgs eventArgs)
        {
            Password.IsPassword = !Password.IsPassword;
        }
        void LabelClicked(object view, EventArgs eventArgs)
        {
            ((NavigationPage)Application.Current.MainPage).PushAsync(new Register());
        }
    }
}