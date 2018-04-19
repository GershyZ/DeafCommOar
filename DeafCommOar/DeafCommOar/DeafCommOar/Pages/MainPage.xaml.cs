using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeafCommOar
{
	public partial class MainPage : ContentPage
	{
        ViewModels.MainPageVM _mainPageVM;

		public MainPage(String oarlayout)
		{
			InitializeComponent();
            _mainPageVM = new ViewModels.MainPageVM();
            _mainPageVM.GetSinglesLayout(sl_singles, oarlayout);
            _mainPageVM.PopulateGroups(sl_singles, sl_pairs,2);
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
