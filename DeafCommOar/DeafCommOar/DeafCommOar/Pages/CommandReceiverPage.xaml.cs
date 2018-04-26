using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeafCommOar.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommandReceiverPage : ContentPage
	{
		public CommandReceiverPage ()
		{
			InitializeComponent ();
		}

        public void ParseCommand(long code)
        {
            bcv_receiver.CommandValue = code;
        }
	}
}