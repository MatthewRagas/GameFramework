using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameFramework
{
    class Timer
    {
        private Stopwatch _stopwatch = new Stopwatch();

        private long _currentTime = 0;
        private long _beforeTime = 0;

        private float _deltaTime = 0.005f;

        public Timer()
        {
            _stopwatch.Start();
        }
        public void Restart()
        {
            _stopwatch.Restart();
        }

        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }

        public float GetDeltaTime()
        {
            _beforeTime = _currentTime;
            _currentTime = _stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _beforeTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
