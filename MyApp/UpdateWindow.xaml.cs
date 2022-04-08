using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SettingsUI.Helpers;
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
    public sealed partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            this.InitializeComponent();
            var m_AppWindow = GetAppWindowForCurrentWindow();
            m_AppWindow.Title = "MyApp Update";
        }

        public AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var ver = await UpdateHelper.CheckUpdateAsync("jpbandroid", "MyApp");
            if (ver.IsExistNewVersion)
            {
                txtReleaseUrl.Text = $"Release Url: {ver.HtmlUrl}";
                txtCreatedAt.Text = $"Created At: {ver.CreatedAt}";
                txtPublishedAt.Text = $"Published At {ver.PublishedAt}";
                txtIsPreRelease.Text = $"Is PreRelease: {ver.IsPreRelease}";
                txtTagName.Text = $"Tag Name: {ver.TagName}";
                txtChangelog.Text = $"Changelog: {ver.Changelog}";
                foreach (var item in ver.Assets)
                {
                    listView.Items.Add($"{item.Url}{Environment.NewLine}Size: {item.Size}");
                }
            }
        }
    }
}
