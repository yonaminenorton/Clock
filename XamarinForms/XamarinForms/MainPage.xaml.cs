using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinForms
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SetTimeLabelText(string txt)
        {
            TimeLabel.Text = txt;
        }
    }

}
