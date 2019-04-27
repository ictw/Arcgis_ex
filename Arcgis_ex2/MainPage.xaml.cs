using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;

namespace Arcgis_ex2
{
    /// <summary>
    /// A map page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string str = "";
        public MainPage()
        {
            this.InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
        }

        /// <summary>
        /// Gets the view-model that provides mapping capabilities to the view
        /// </summary>
        public MapViewModel ViewModel { get; } = new MapViewModel();

        private void SearchBtn(object sender, RoutedEventArgs e)
        {

        }

        // Map initialization logic is contained in MapViewModel.cs
    }
}
// ==============================================================================================
//     ╲ ▁▂▂▂▁ ╱
//      ▄███████▄
//     ▄██ ███ ██▄        360-1801-A01
//    ▄██████████       OS: Android 7.1.1
// ▄█ ▄▄▄▄▄▄▄▄▄▄ █▄    Device: 1801-A01(QK1801)
// ██ ██████████ ██    ROM: V116
// ██ ██████████ ██    Baseband: sdm
// ██ ██████████ ██    Kernel: aarch64 Linux 4.4.21-perf
// ██ ██████████ ██    Uptime: 1h 9m
//    ███████████       CPU: AArch64 Processor rev 4 (aarch64)
//     ██████████        GPU: AArch64 Processor rev 4 (aarch64)
//      ██         ██         RAM: 2242MiB / 3740MiB
//      ██         ██
// ============================================================================================~ 
//                          ./+o+-       suofeiya @DESKTOP-EVQFG8U
//                 yyyyy- -yyyyyy+      OS: Ubuntu 18.04 bionic[Ubuntu on Windows 10]
//              ://+//////-yyyyyyo      Kernel: x86_64 Linux 4.4.0-17763-Microsoft
//          .++ .:/++++++/-.+sss/`      Uptime: 0m
//        .:++o:  /++++++++/:--:/-      Packages: 941
//       o:+o+:++.`..```.-/oo+++++/     Shell: zsh 5.4.2
//      .:+o:+o/.          `+sssoo+/    CPU: Intel Core i7-6500U @ 4x 2.601GHz
// .++/+:+oo+o:`             /sssooo.GPU:
///+++//+:`oo+o               /::--:.   RAM: 4791MiB / 8065MiB
//\+/+o+++`o++o               ++////.
// .++.o+++oo+:`             /dddhhh.
//      .+.o+oo:.          `oddhhhh+
//       \+.++o+o``-````.:ohdhhhhh+
//        `:o+++ `ohhhhhhhhyo++os:
//          .o:`.syhhhhhhh/.oo++o`
//              /osyyyyyyo++ooo+++/
//                  ````` +oo+++o\:
//                         `oo++.