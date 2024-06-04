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

namespace UniversalUnlockTool.WindowsUI
{
    /// <summary>
    /// Логика взаимодействия для TopBar.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        Window ParentWindow;

        public TopBar() { InitializeComponent(); ParentWindow = new(); }

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
        private void Minimize_TopBar_Click(object sender, RoutedEventArgs e) => ParentWindow.WindowState = WindowState.Minimized;
        private void Close_TopBar_Click(object sender, RoutedEventArgs e) => ParentWindow.Close();


        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(TopBar), new PropertyMetadata(default(string)));

        public bool CanMinimize
        {
            get => (bool)GetValue(CanMinimizeProperty);
            set => SetValue(CanMinimizeProperty, value);
        }

        public static readonly DependencyProperty CanMinimizeProperty =
            DependencyProperty.Register("CanMinimize", typeof(bool), typeof(TopBar), new PropertyMetadata(true));


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ParentWindow = Window.GetWindow(this);
            if(!CanMinimize)
            {
                Minimize_TopBar.Visibility = Visibility.Collapsed;
            }
        }
    }
}
