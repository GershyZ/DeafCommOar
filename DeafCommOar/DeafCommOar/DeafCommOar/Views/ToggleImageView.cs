using DeafCommOar.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeafCommOar.Views
{
    public class ToggleImageView : Image
    {
        private int _stage;
        public int Stage
        {
            get { return _stage; }
        }
        private String[] _toggles;
        public String[] Toggles
        {
            get { return _toggles; }
            set
            {
                _toggles = value;
                _stage = 0;
                Source = _toggles[_stage];                
            }
        }        

        public ToggleImageView()
        {
            _stage = 0;
            var tapped = new TapGestureRecognizer();
            tapped.Tapped += StageChanged;
            this.GestureRecognizers.Add(tapped);
        }

        public void StageChanged(object sender, EventArgs e)
        {
            _stage = (_stage + 1) % 2;
            this.Source = Toggles[_stage];
            updateChildren();
        }
        public void reset()
        {
            _stage = 0;
            this.Source = Toggles[_stage];
        }
        protected virtual void updateChildren() { }
    }

    public class PortOarView : ToggleImageView
    {
        public PortOarView()
        {
            Toggles = new string[] { "port_idle.png", "port_clicked.png" };            
        }
    }

   public class StarboardOarView : ToggleImageView
    {
        public StarboardOarView()
        {
            Toggles = new string[] { "starboard_idle.png", "starboard_clicked.png" };
        }
    }

    class ConfigurationOarView : ToggleImageView
    {
        public ConfigurationOarView()
        {
            Toggles = new string[] { "port_idle.png", "starboard_idle.png" };
        }
        public char Orientation
        {
            get
            {
                return Toggles[Stage].ToCharArray()[0];
            }
        }
    }

    class PairGroupView : ToggleImageView
    {
        ToggleImageView[] singles;
        public PairGroupView(ToggleImageView[] oars)
        {
            Toggles = new string[] { "pair_idle.png", "pair_clicked.png" };
            singles = oars;
        }
        protected override void updateChildren()
        {
            foreach(ToggleImageView s in singles)
            {
                while(s.Stage != this.Stage)
                {
                    s.StageChanged(this, null); 
                }
            }
        }
    }
}