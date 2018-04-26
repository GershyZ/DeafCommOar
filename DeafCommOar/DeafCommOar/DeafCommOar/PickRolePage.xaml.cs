using DeafCommOar.ViewModels;
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
	public partial class PickRolePage : ContentPage
	{
        private PickRolePageVM _PickRoleVM = new PickRolePageVM();         
        public PickRolePage ()
		{
			InitializeComponent ();
            BindingContext = _PickRoleVM;            
		}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            sl_coxswain_controls.IsVisible = false;
            sl_athlete_form.IsVisible = false;
            String role = _PickRoleVM.getRole(((Picker)sender).SelectedIndex);
            if(role.ToCharArray()[0] == 'C')
            {
                sl_coxswain_controls.IsVisible = true;
            }
            if(role.ToCharArray()[0] == 'R') {
                sl_athlete_form.IsVisible = true;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String role = _PickRoleVM.getRole(((Picker)sender).SelectedIndex);
            if (role.ToCharArray()[0] == 'C')
            {
                App.Current.MainPage = new Pages.ConfigurationPage();
            }
            if (role.ToCharArray()[0] == 'R')
            {
                App.Current.MainPage = new Pages.CommandReceiverPage();
            }
        }
    }
}