using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DeafCommOar.ViewModels
{
    class MainPageVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        internal void GetSinglesLayout(StackLayout singles, string layout)
        {
            var orientation = new Views.ToggleImageView();
            foreach(char c in layout.ToLower().ToCharArray()) 
            {
                if (c == 'p')
                {
                    orientation = new Views.PortOarView();
                }
                else if (c== 's')
                {
                    orientation = new Views.StarboardOarView();
                }
                singles.Children.Add(orientation);
            }
        }
        internal void PopulateGroups(StackLayout children, StackLayout groupings, int groupsize)
        {
            int count = 0;
            Views.PairGroupView pairgroup;
            var affectedsingles = new Views.ToggleImageView[groupsize];
            foreach (Views.ToggleImageView tiv in children.Children)
            {
                affectedsingles[count] = tiv;
                count = (count + 1) % groupsize;
                if(count == 0) {
                    pairgroup = new Views.PairGroupView(affectedsingles);
                    groupings.Children.Add(pairgroup);
                    affectedsingles = new Views.ToggleImageView[groupsize];
                }
                
            }
        }
    }
}
