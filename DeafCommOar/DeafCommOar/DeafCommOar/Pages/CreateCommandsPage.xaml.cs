using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeafCommOar.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateCommandsPage : ContentPage
	{
        private List<CoxswainCommand> commands;
        
		public CreateCommandsPage ()
		{
            commands = new List<CoxswainCommand>();
            InitializeComponent();
            var command = new CoxswainCommand();
            sl_commands.Children.Add(command.GetCommandView());
        }

        public void NewCommandPrompt(object s, EventArgs e)
        {
            var command = new CoxswainCommand();
            commands.Add(command);
            sl_commands.Children.Add(command.GetCommandView());
        }

        public void GoBack(object s, EventArgs e)
        {
           foreach(CoxswainCommand cc in commands)
            {
                if (!App.COXSWAIN_COMMANDS.Keys.Contains(cc.BulbCode))
                {
                    App.COXSWAIN_COMMANDS.Add(cc.BulbCode, cc.Command);
                }
            }
            App.Current.MainPage.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            sl_commands.Children.Clear();
            
            try
            {
                var cmd = new CoxswainCommand();
                var curr = App.COXSWAIN_COMMANDS.GetEnumerator();
                while (false && curr.MoveNext())
                {
                    cmd = new CoxswainCommand();
                    commands.Add(cmd);
                    sl_commands.Children.Add(cmd.GetCommandView(curr.Current.Key, curr.Current.Value));
                }
            }
            catch (Exception e) { };
        }
    }

    public class CoxswainCommand
    {
        Views.BulbCommandsView _bulbs;
        Entry _command;
        public string Command
        {
            set { _command.Text = value; }
            get { return _command.Text;  }
        }
        public long BulbCode
        {
            set { _bulbs.CommandValue = value; }
            get { return _bulbs.CommandValue; }
        }
        public CoxswainCommand()
        {
            _bulbs = new Views.BulbCommandsView();        
            _command = new Entry { Placeholder = "Command", HorizontalOptions = LayoutOptions.EndAndExpand };
        }

        public StackLayout GetCommandView(long commandcode=0, string command = "")
        {
            //_command.Text = command;
            //_bulbs.CommandValue = commandcode;

            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions=LayoutOptions.Start,
                Children =
                {
                    _bulbs,
                    _command
                }
            };
        }
    }
}