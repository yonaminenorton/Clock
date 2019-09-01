﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharedClock
{
    public class Clock
    {
        private static readonly string DATE_TIME_FMT = "yyyy/MM/dd HH:mm:ss";

        private CancellationTokenSource _tokenSource;

        public void PowerOn(Action<string> DisplayTime)
        {
            _tokenSource = new CancellationTokenSource();

            Task.Run(() =>
            {
                string prev = string.Empty;

                CancellationToken token = _tokenSource.Token;

                while (!token.IsCancellationRequested)
                {
                    string now = DateTime.Now.ToString(DATE_TIME_FMT);

                    if (now.Equals(prev))
                    {
                        continue;
                    }

                    prev = now;

                    DisplayTime(now);
                }
            });
        }

        public void PowerOff()
        {
            _tokenSource.Cancel();
        }

        public bool IsRunning()
        {
            if (_tokenSource == null)
            {
                return false;
            }

            CancellationToken token = _tokenSource.Token;
            return !token.IsCancellationRequested;
        }

    }
}
