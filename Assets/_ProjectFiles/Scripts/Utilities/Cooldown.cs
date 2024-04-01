using System.Threading;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Cooldown
    {
        private float _cooldownSeconds = 0f;
        public bool IsEnabled { get; private set; }

        private CancellationTokenSource _cancellationTokenSource;

        public Cooldown(float cooldownSeconds)
        {
            _cooldownSeconds = cooldownSeconds;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task StartAsync()
        {
            if (IsEnabled)
                return;

            IsEnabled = true;

            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            await Task.Delay((int)(_cooldownSeconds * 1000), _cancellationTokenSource.Token);

            IsEnabled = false;
        }

        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
            IsEnabled = false;
        }
    }
}
