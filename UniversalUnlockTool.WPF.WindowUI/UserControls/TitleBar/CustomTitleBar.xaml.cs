using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversalUnlockTool.WPF.WindowUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomTitleBar.xaml
    /// </summary>
    public partial class CustomTitleBar : UserControl
    {
        Window ParentWindow;

        public CustomTitleBar() { InitializeComponent(); ParentWindow = new(); }

        public static Window? FindParentWindow(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            //CHeck if this is the end of the tree
            if (parent == null) return null;

            if (parent is Window parentWindow)
            {
                return parentWindow;
            }
            else
            {
                //use recursion until it reaches a Window
                return FindParentWindow(parent);
            }
        }

        private void Border_MouseDonw_Trigger(object sender, RoutedEventArgs e) => ParentWindow.DragMove();
        private void Minimize_CustomTitleBarClick(object sender, RoutedEventArgs e) => ParentWindow.WindowState = WindowState.Minimized;
        private void Close_CustomTitleBarClick(object sender, RoutedEventArgs e) => ParentWindow.Close();


        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(CustomTitleBar), new PropertyMetadata(default(string)));

        public bool CanMinimize
        {
            get => (bool)GetValue(CanMinimizeProperty);
            set => SetValue(CanMinimizeProperty, value);
        }

        public static readonly DependencyProperty CanMinimizeProperty =
            DependencyProperty.Register("CanMinimize", typeof(bool), typeof(CustomTitleBar), new PropertyMetadata(true));

        public int DefaultHeight
        {
            get => (int)GetValue(DefaultHeightProperty);
            set => SetValue(DefaultHeightProperty, value);
        }

        public static readonly DependencyProperty DefaultHeightProperty =
            DependencyProperty.Register("DefaultHeight", typeof(int), typeof(CustomTitleBar), new PropertyMetadata(400));

        public int DefaultWidth
        {
            get => (int)GetValue(DefaultWidthtProperty);
            set => SetValue(DefaultWidthtProperty, value);
        }

        public static readonly DependencyProperty DefaultWidthtProperty =
            DependencyProperty.Register("DefaultWidth", typeof(int), typeof(CustomTitleBar), new PropertyMetadata(600));


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ParentWindow = Window.GetWindow(this);
            if (!CanMinimize)
            {
                Minimize_CustomTitleBarButton.Visibility = Visibility.Collapsed;
            }
        }

        private void RestoreSize_CustomTitleBarClick(object sender, RoutedEventArgs e)
        {
            ParentWindow.Width = DefaultWidth;
            ParentWindow.Height = DefaultHeight;
        }
    }
}
