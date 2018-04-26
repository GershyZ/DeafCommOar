using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeafCommOar.ViewModels
{
    class PickRolePageVM : INotifyPropertyChanged
    {
        public List<String> Roles { get; internal set; }

        public PickRolePageVM()
        {
            Roles = new List<string> { "Pick Your Role", "Coxswain", "Rower" };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal string getRole(int selectedIndex)
        {
            if(selectedIndex < Roles.Count)
            {
                return Roles[selectedIndex];
            }
            else
            {
                return "";           
            }
        }
    }
}
