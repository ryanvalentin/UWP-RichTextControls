using System;
using Windows.UI.Xaml;

namespace RichTextControls.ExampleApp
{
    public class Debouncer
    {
        private DispatcherTimer _timer;

        public Debouncer(TimeSpan timeSpan)
        {
            _timer = new DispatcherTimer()
            {
                Interval = timeSpan
            };
            _timer.Tick += Timer_Tick;
        }

        public event RoutedEventHandler Action;

        private void Timer_Tick(object sender, object e)
        {
            _timer.Stop();
            Action?.Invoke(this, new RoutedEventArgs());
        }

        public void Hit()
        {
            _timer.Stop();
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
