using System;
using System.Threading;
using System.Threading.Tasks;

namespace SharedClock
{
    /// <summary>
    /// 時計クラス
    /// ・現在日時を表示する
    /// </summary>
    public class Clock
    {
        private static readonly string DATE_TIME_FMT = "yyyy/MM/dd HH:mm:ss";

        private CancellationTokenSource _tokenSource;

        /// <summary>
        /// 時計起動
        /// ・リアルタイムで現在日時を表示する
        /// </summary>
        /// <param name="DisplayDateTime">日時表示用Delegete</param>
        public void PowerOn(Action<string> DisplayDateTime)
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

                    DisplayDateTime(now);
                }
            });
        }

        /// <summary>
        /// 時計終了
        /// </summary>
        public void PowerOff()
        {
            _tokenSource.Cancel();
        }

        /// <summary>
        /// 起動しているか
        /// </summary>
        /// <returns>true:起動中 /false:終了している</returns>
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
