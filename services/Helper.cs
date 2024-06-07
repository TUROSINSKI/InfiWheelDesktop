using System.Windows;
using System.Windows.Media;

namespace InfiWheelDesktop.services
{
    internal class Helper
    {
        public static List<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            var result = new List<T>();
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        result.Add(child as T);
                    }
                    result.AddRange(FindVisualChildren<T>(child));
                }
            }
            return result;
        }
    }
}
