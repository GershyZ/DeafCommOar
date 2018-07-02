using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeafCommOar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickRolePage : TabbedPage
    {
        public PickRolePage ()
        {
            InitializeComponent();
        }

        public void CreateTeamHotspot(object s, EventArgs e)
        {
            App.Current.MainPage = new Pages.ConfigurationPage();
        }

        public void ModifyCommands(object s, EventArgs e)
        {
            App.Current.MainPage = new Pages.CreateCommandsPage();
        }
    }
}