using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUITest2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var m_AppWindow = GetAppWindowForCurrentWindow();
            m_AppWindow.Title = "MyApp";
        }

        public AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            var description = new System.Text.StringBuilder();
            var process = System.Diagnostics.Process.GetCurrentProcess();
            foreach (System.Diagnostics.ProcessModule module in process.Modules)
            {
                description.AppendLine(module.FileName);
            }

            cdTextBlock.Text = description.ToString();
            await contentDialog.ShowAsync();
        }

        private void update(object sender, RoutedEventArgs e)
        {
            UpdateWindow window = new UpdateWindow();
            window.Activate();
        }

        private void CheckBoxclick(object sender, RoutedEventArgs e)
        {
            CheckboxWindow window = new CheckboxWindow();
            window.Activate();
        }

        private void radiobuttonclick(object sender, RoutedEventArgs e)
        {
            RadioButtonWindow window = new RadioButtonWindow();
            window.Activate();
        }

        private void buttonclick(object sender, RoutedEventArgs e)
        {
            ButtonWindow window = new ButtonWindow();
            window.Activate();
        }

        private void about(object sender, RoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.Activate();
        }

        private void tabbuttonclick(object sender, RoutedEventArgs e)
        {
            TabWindow window = new TabWindow();
            window.Activate();
        }
    }
}
