using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin
{
    // MessageAnnouncer: Handles message queueing, timed display, and property change notification for UI binding.
    public class MessageAnnouncer : INotifyPropertyChanged
    {
        private string _message = string.Empty;
        private readonly Queue<(string message, int delayMs)> _queue = new();
        private CancellationTokenSource? _cts;
        private bool _isRunning;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Message
        {
            get => _message;
            private set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event for data binding.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Queues a single message to be displayed for a specified duration.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="delayMs">The duration in milliseconds to display the message.</param>
        public void Enqueue(string message, int delayMs)
        {
            _queue.Enqueue((message, delayMs));

            if (!_isRunning)
                _ = ProcessQueueAsync();
        }
        /// <summary>
        /// Queues a range of messages, each displayed for the same specified duration.
        /// </summary>
        /// <param name="messages">The messages to display.</param>
        /// <param name="delayMs">The duration in milliseconds to display each message.</param>
        public void EnqueueRange(IEnumerable<string> messages, int delayMs)
        {
            foreach (var msg in messages)
                _queue.Enqueue((msg, delayMs));

            if (!_isRunning)
                _ = ProcessQueueAsync();
        }
        /// <summary>
        /// Continuously loops through a set of frames/messages while a condition is true.
        /// </summary>
        /// <param name="frames">The frames/messages to loop through.</param>
        /// <param name="delayMs">The duration in milliseconds to display each frame.</param>
        /// <param name="condition">A function that returns true to continue looping, or false to stop.</param>
        public void EnqueueLoop(IEnumerable<string> frames, int delayMs, Func<bool> condition)
        {
            Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(async () =>
            {
                var frameList = new List<string>(frames);
                int index = 0;

                while (condition() && !token.IsCancellationRequested)
                {
                    Message = frameList[index];
                    index = (index + 1) % frameList.Count;

                    try
                    {
                        await Task.Delay(delayMs, token);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }, token);
        }
        /// <summary>
        /// Cancels any ongoing message display and clears the message queue.
        /// </summary>
        public void Cancel()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
            _queue.Clear();
        }
        /// <summary>
        /// Processes the queued messages asynchronously, displaying each for its specified duration.
        /// </summary>
        private async Task ProcessQueueAsync()
        {
            _isRunning = true;
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            while (_queue.Count > 0 && !token.IsCancellationRequested)
            {
                var (msg, delay) = _queue.Dequeue();
                Message = msg;
                try
                {
                    await Task.Delay(delay, token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }
            _isRunning = false;
        }
    }
}

/*
Example usage
---------------------
Binding:
_announcer = new MessageAnnouncer();
label1.DataBindings.Add("Text", _announcer, "Message");

Trigger messages:
_announcer.Enqueue("Loading...", 1000);

Or stage mulitple messages:
_announcer.EnqueueRange(new[]
{
    "Initializing connection...",
    "Verifying device...",
    "Syncing data...",
    "Ready."
}, 1500);

Looping Messages:
if (IsLoading)
    _announcer.EnqueueLoop(new[] { "Loading.", "Loading..", "Loadinging..." }, 1000, () => IsLoading);
else
    _announcer.Cancel();
*/