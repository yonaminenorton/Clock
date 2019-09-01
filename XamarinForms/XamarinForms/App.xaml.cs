﻿using Xamarin.Forms;
using Xamarin.Essentials;
using SharedClock;

namespace XamarinForms
{
    public partial class App : Application
    {
        private Clock _clock;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();

            _clock = new Clock();
            PowerOnClock();

        }

        protected override void OnSleep()
        {
            base.OnSleep();

            //アプリがバックグラウンドのときは時計を終了
            _clock.PowerOff();

        }

        protected override void OnResume()
        {
            base.OnResume();

            PowerOnClock();
        }

        private void PowerOnClock()
        {
            if (_clock.IsRunning())
            {
                return;
            }

            _clock.PowerOn((string txt) => {
                //UIスレッドでコントロールを操作させる
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    var page = (MainPage)MainPage;
                    page.SetTimeLabelText(txt);
                });
            });
        }
    }
}
