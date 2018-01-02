using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeafCommOar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BulbCommandsView : ContentView
	{
		public BulbCommandsView ()
		{
			InitializeComponent ();
		}
        public double CommandValue
        {
            get
            {
                double commandsum = 0;
                int power = 0;
                foreach (BulbView bv in sl_bulbs.Children)
                {
                    commandsum += Math.Pow(bv.Stage, power);
                    power++;
                }
                return commandsum;
            }            
        }
        public void reset()
        {
            foreach(BulbView bv in sl_bulbs.Children)
            {
                bv.reset();
            }
        }

    }
}