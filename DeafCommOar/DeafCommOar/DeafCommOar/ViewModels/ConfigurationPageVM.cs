using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using DeafCommOar.Views;
using System.ComponentModel;

namespace DeafCommOar.ViewModels
{
    class ConfigurationPageVM : INotifyPropertyChanged
    {
        public void populateOars(StackLayout oars, int numoars)
        {
            ConfigurationOarView curroar;
            oars.Children.Clear();
            for (int i = 0; i < numoars; i++)
            {
                curroar = new ConfigurationOarView();
                if (i % 2 == 1)
                {
                    curroar.StageChanged(this, null);                    
                }
                oars.Children.Add(curroar);
            }
        }

        public void completeConfiguration(StackLayout oars)
        {
            String layout = "";
            foreach(ConfigurationOarView cov in oars.Children)
            {
                layout += cov.Orientation;
            }

            App.Current.MainPage = new DeafCommOar.CoxswainControllerPage(layout);
        }
        public event PropertyChangedEventHandler 
            
            PropertyChanged;
    }
}
