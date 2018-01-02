using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DeafCommOar.Models
{
    public class BulbModel : INotifyPropertyChanged
    {
        int _currstage= 0;
        public int Stage
        {
            get { return _currstage; }
            set { _currstage = value % 3; }
        }
        Color _bulbcolor;
        public Color BulbColor
        {

            get { return _bulbcolor; }
            set { _bulbcolor = value; }
        }
        public BulbModel()
        {
            _currstage = 0;
        }

        internal object changeState()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
