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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        void Submit_Clicked(object t , EventArgs e)
        {
            string name = Name.Text;
            string surname = Surname.Text;
            string username = Username.Text;
            string pw = Password.Text;

            Register_Action(name,surname,username, pw);
        }

        void Register_Action(string n,string s ,string u, string p) {
            User us = new User()
            {
                Name = n,
                Surname = s,
                Username = u,
                Password = p
            };
        
            SFWebServer.Main.Post(SFResources.User,us);

        }
    }
}