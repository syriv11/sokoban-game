using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sokoban
{
    public class NativeNotificationsController : MonoBehaviour
    {
        [SerializeField] private AndroidNotificationsController androidNotificationsController;

        [Space]

        [SerializeField] private string _title;
        [SerializeField] private string _test;
        [SerializeField] private int _fireTimeInSeconds;

        private void Start()
        {
            #if UNITY_ANDROID
            androidNotificationsController.RequestAuthorization();
            androidNotificationsController.RegisterNotificationChannel();
            #endif
        }

        //private void OnApplicationQuit()
        //{
        //    #if UNITY_ANDROID
        //    androidNotificationsController.SentNotification(_title, _test, _fireTimeInSeconds);
        //    #endif
        //}

        private void OnApplicationPause(bool pause)
        {
            #if UNITY_ANDROID
            androidNotificationsController.SentNotification(_title, _test, _fireTimeInSeconds);
            #endif
        }
    }
}
