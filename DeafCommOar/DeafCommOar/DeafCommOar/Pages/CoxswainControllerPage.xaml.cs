using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeafCommOar
{
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

        private void SendMessage(object sender, EventArgs e)
        {
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
