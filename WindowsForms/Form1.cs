using System;
using System.Windows.Forms;
using SharedClock;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        private Clock _clock;

        public Form1()
        {
            InitializeComponent();

            _clock = new Clock();
            StartClock();

        }

        private void StartClock()
        {
            if (_clock.IsRunning())
            {
                return;
            }

            _clock.Start((string txt) => {
                Action act = () => TimeLabel.Text = txt;
                this.Invoke(act);

            });
        }
    }
}
