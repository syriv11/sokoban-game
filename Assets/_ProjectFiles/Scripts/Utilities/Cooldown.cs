using System.Threading.Tasks;

namespace Sokoban
{
    public class Cooldown
    {
        private float _cooldownSeconds = 0f;
        public bool IsEnabled { get; private set; }

        public Cooldown(float cooldownSeconds)
        {
            _cooldownSeconds = cooldownSeconds;
        }

        public async Task StartAsync()
        {
            //if (IsEnabled)
            //    return;

            IsEnabled = true;

            await Task.Delay((int)(_cooldownSeconds * 1000));

            IsEnabled = false;
        }
    }
}
