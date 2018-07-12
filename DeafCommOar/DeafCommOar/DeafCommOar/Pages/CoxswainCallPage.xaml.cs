using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeafCommOar.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoxswainCallPage : ContentPage
	{
        ViewModels.CoxswainControllerPageVM _coxswaincontrollerVM;

        public CoxswainCallPage(String oarlayout)
        {
            InitializeComponent();
            _coxswaincontrollerVM = new ViewModels.CoxswainControllerPageVM();
            _coxswaincontrollerVM.GetSinglesLayout(sl_singles, oarlayout);
            _coxswaincontrollerVM.PopulateGroups(sl_singles, sl_pairs, 2);                
        }        

        private void SendMessage(object sender, EventArgs e)
        {
            CurrentPlatform.Init();
            //await App.MobileService.GetTable<CoxswainCommand>().InsertAsync(cmd);

            foreach (Views.ToggleImageView tiv in sl_pairs.Children)
            {
                tiv.reset();
            }
            foreach (Views.ToggleImageView oar in sl_singles.Children)
            {
                oar.reset();
            }                
        }
    }
}