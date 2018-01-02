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
	public partial class ConfigurationPage : ContentPage
	{
        ViewModels.ConfigurationPageVM configvm;
        public ConfigurationPage ()
		{
			InitializeComponent ();
            configvm = new ViewModels.ConfigurationPageVM();
		}

        private void show2Oars(object sender, EventArgs eventArgs)
        {
            configvm.populateOars(sl_oars, 2);
        }
        private void show4Oars(object sender, EventArgs eventArgs)
        {
            configvm.populateOars(sl_oars, 4);
        }
        private void show8Oars(object sender, EventArgs eventArgs)
        {
            configvm.populateOars(sl_oars, 8);
        }
        private void gotoMainPage(object sender, EventArgs eventArgs)
        {
            configvm.completeConfiguration(sl_oars);
        }     
    }
}