using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using System;

public class LocalNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        var notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Disturb the User",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        var notification = new AndroidNotification();
        notification.Title = "Hey, Come Back!!!";
        notification.Text = "You´r Energy is Full!!";
        notification.SmallIcon = "icon_reminders";
        notification.LargeIcon = "icon_reminder";
        notification.FireTime = DateTime.Now.AddSeconds(30);

        var id = AndroidNotificationCenter.SendNotification(notification, "reminder_notif_ch");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "reminder_notif_ch");
        }

    }

}
