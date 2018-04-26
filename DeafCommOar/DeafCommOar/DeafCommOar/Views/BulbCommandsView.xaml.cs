using System;
using System.Collections.Generic;
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
        
        public long CommandValue
        {
            get
            {
                long commandsum = 0;
                int power = 0;
                foreach (BulbView bv in sl_bulbs.Children)
                {
                    commandsum += (long)Math.Pow(bv.Stage, power);
                    power++;
                }
                return commandsum;
            }
            set
            {
                string tert = App.DecimalToArbitrarySystem(value, 3);
                int index = 0;
                foreach(BulbView b in sl_bulbs.Children)
                {
                    if (index < tert.Length)
                    {
                        b.Stage = tert.ToCharArray()[index];
                    }
                    else b.Stage = 0;
                }
            }
        }
        public void reset()
        {
            foreach (BulbView bv in sl_bulbs.Children)
            {
                bv.reset();
            }
        }
    }
}