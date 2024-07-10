using System.Windows;
using System.Windows.Media;

namespace Project_Automait.Classes
{
    public static class NotificationManager
    {
        private static readonly List<NotificationWindow> notifications = [];

        public enum NotificationType
        {
            Success,
            Info,
            Warning,
            Error,
            Neutral
        }

        public static readonly Dictionary<NotificationType, SolidColorBrush> notificationColors = new()
        {
            { NotificationType.Success, new SolidColorBrush(Color.FromArgb(0xFF, 0x06, 0xD2 , 0x82))},
            { NotificationType.Info, new SolidColorBrush(Color.FromArgb(0xFF, 0x06, 0x83 , 0xD2))},
            { NotificationType.Warning, new SolidColorBrush(Color.FromArgb(0xFF, 0xD2, 0x76 , 0x06))},
            { NotificationType.Error, new SolidColorBrush(Color.FromArgb(0xFF, 0xD2, 0x06 , 0x06))},
            { NotificationType.Neutral, new SolidColorBrush(Color.FromArgb(0xFF, 0x40, 0x40 , 0x40))},
        };


        public static void AddNotification(NotificationWindow notification)
        {
            notifications.Add(notification);
            UpdateNotifications();
        }

        public static void RemoveNotification(NotificationWindow notification)
        {
            notifications.Remove(notification);
            UpdateNotifications();
        }

        private static void UpdateNotifications()
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                notifications[i].Dispatcher.Invoke(() =>
                {
                    notifications[i].Top = SystemParameters.WorkArea.Height - (notifications[i].Height - 5) * (i + 1);
                });
            }
        }
    }
}
