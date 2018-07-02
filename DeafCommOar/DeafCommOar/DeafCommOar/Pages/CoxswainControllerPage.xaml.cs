using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeafCommOar
{
    //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/push-notifications/azure    
    //https://www.youtube.com/watch?v=j2YSMKOPBXg
    public partial class CoxswainControllerPage : ContentPage
	{
        ViewModels.CoxswainControllerPageVM _coxswaincontrollerVM;

		public CoxswainControllerPage(String oarlayout)
		{
			InitializeComponent();
            _coxswaincontrollerVM = new ViewModels.CoxswainControllerPageVM();
            _coxswaincontrollerVM.GetSinglesLayout(sl_singles, oarlayout);
            _coxswaincontrollerVM.PopulateGroups(sl_singles, sl_pairs,2);
            BulbCommand.reset();
		}

        private async Task SendMessageAsync(object sender, EventArgs e)
        {
            CurrentPlatform.Init();
            CoxswainCommand cmd = new CoxswainCommand { rower_binary = 27, message = "Testing...1 2" };
            await App.MobileService.GetTable<CoxswainCommand>().InsertAsync(cmd);

            foreach (Views.ToggleImageView tiv in sl_pairs.Children)
            {
                tiv.reset();
            }
            foreach (Views.ToggleImageView oar in sl_singles.Children)
            {
                oar.reset();
            }
            BulbCommand.reset();
        }
    }
}
