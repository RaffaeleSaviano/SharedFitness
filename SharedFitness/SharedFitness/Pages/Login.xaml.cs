using SharedFitness.Model;
using SharedFitness.Network.WebServers;
using SharedFitness.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool IsLogggging
        {
            get
            {
                return isLogggging;
            }
            set
            {
                isLogggging = value;
                OnPropertyChanged();
            }
        }
        private bool isLogggging = false;
		public Login ()
		{
			InitializeComponent ();
            LoadAI.BindingContext = this;
            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += LabelClicked;
            Register.GestureRecognizers.Add(tgr);
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            TryLastLogin();
        }
        private void Submit_Clicked(object sender, EventArgs e)
        {
            string user = Username.Text;
            string pw = Password.Text;
            Login_Action(user,pw);
        }

        public async void Login_Action(string user, string pw)
        {
            IsLogggging = true;
            User u = new User()
            {
                Username = user,
                Password = pw
            };
            bool result = await SFWebServer.Main.Login(u);
            if (result)
            {
                if (!Application.Current.Properties.ContainsKey("Username") && !Application.Current.Properties.ContainsKey("Password"))
                {
                    Application.Current.Properties.Add("Username", u.Username);
                    Application.Current.Properties.Add("Password", u.Password);
                }
                u = (await SFWebServer.Main.Get<IEnumerable<User>>(Network.WebServers.SFResources.User, "Username", u.Username)).First();
                SFapp.App.User = u;
                Application.Current.MainPage = new MainPageCS();
            }
            IsLogggging = false;
        }
        void TryLastLogin()
        {
            if(Application.Current.Properties.ContainsKey("Username") && Application.Current.Properties.ContainsKey("Password"))
            {
                string Username = Application.Current.Properties["Username"] as string;
                string Password = Application.Current.Properties["Password"] as string;
                Login_Action(Username, Password);
            }
        }
        void ChangePasswordView(object view, EventArgs eventArgs)
        {
            Password.IsPassword = !Password.IsPassword;
        }
        void LabelClicked(object view, EventArgs eventArgs)
        {
            ((NavigationPage)Application.Current.MainPage).PushAsync(new Register());
            //((NavigationPage)Application.Current.MainPage).PushAsync(new test());
        }

    }
}