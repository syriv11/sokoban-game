using Unity.Notifications.Android;
using UnityEngine;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

namespace Sokoban
{
    public class AndroidNotificationsController : MonoBehaviour
    {
#if UNITY_ANDROID
        public void RequestAuthorization()
        {
            if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
            {
                Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
            }
        }

        public void RegisterNotificationChannel()
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = "default_channel",
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications"
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }

        public void SentNotification(string title, string text, int fireTimeInSeconds)
        {
            var notification = new AndroidNotification();

            notification.Title = title;
            notification.Text = text;
            notification.FireTime = System.DateTime.Now.AddSeconds(fireTimeInSeconds);

            AndroidNotificationCenter.SendNotification(notification, "default_channel");
        }
    }
#endif
}
