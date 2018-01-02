using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DeafCommOar.Views
{
    public class BulbView : Image
    {
        bool _isblinking;
        Models.BulbModel _bulb;
        int _stage;
        public int Stage
        {
            get { return _stage; }
        }
        public BulbView()
        {
            _bulb = new Models.BulbModel();
            _stage = 0;
            _isblinking = false;
            this.Source = "bulb_template.png";            
            var tapped = new TapGestureRecognizer();
            tapped.Tapped += StageChanged;
            this.GestureRecognizers.Add(tapped);
        }

        private async void StageChanged(object sender, EventArgs eventArgs)
        {
            switch (++_stage) {
                case 1:
                    Opacity = .7;
                    break;

                case 2:
                    _isblinking = true;
                    while (_isblinking)
                    {
                        try
                        {
                            await this.FadeTo(.7, 250, Easing.Linear);
                            await this.FadeTo(.2, 250, Easing.Linear);
                        }
                        catch (Exception e) { }
                    }
                    
                    break;
                default:
                    Opacity = .2;
                    _stage = 0;
                    _isblinking = false;
                    break;
            }
        }
        public void reset()
        {
            _stage = 0;
            _isblinking = false;
            Opacity = .2;
        }
    }
}