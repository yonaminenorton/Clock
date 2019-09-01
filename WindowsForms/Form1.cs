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
            PowerOnClock();

        }

        private void PowerOnClock()
        {
            if (_clock.IsRunning())
            {
                return;
            }

            _clock.PowerOn((string txt) => {
                Action act = () => TimeLabel.Text = txt;
                Invoke(act);

            });
        }
    }
}
