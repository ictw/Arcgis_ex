using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Arcgis_ex1
{
    /// <summary>
    /// A map page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Esri.ArcGISRuntime.Symbology.Symbol mylineSymbol;
        private Esri.ArcGISRuntime.Symbology.Symbol mypointSymbol;
        private GraphicsOverlay mygraphicsOverlay;
        public MainPage()
        {
            this.InitializeComponent();
            //mylineSymbol = layoutGrid.Resources["LineSymbol"] as
            //    Esri.ArcGISRuntime.Symbology.Symbol;
            //mylineSymbol = layoutGrid.Resources["PointSymbol"] as
            //   Esri.ArcGISRuntime.Symbology.Symbol;

        }

        /// <summary>
        /// Gets the view-model that provides mapping capabilities to the view
        /// </summary>
        public MapViewModel ViewModel { get; } = new MapViewModel();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Esri.ArcGISRuntime.Geometry.Geometry newExtent =
                   await
                   MapView1.SketchEditor.StartAsync(SketchCreationMode.Circle, false);
            //Console.WriteLine(newExtent);
            await
            MapView1.SetViewpointGeometryAsync(newExtent, 15);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //复位
            await
                MapView1.SetViewpointAsync(MapView1.Map.InitialViewpoint);
            await
                MapView1.SetViewpointRotationAsync(0);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await
                MapView1.SetViewpointRotationAsync(MapView1.MapRotation + 10);

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            await
                MapView1.SetViewpointRotationAsync(MapView1.MapRotation - 10);

        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //缩放到指定的比例尺
            try
            {
                await
                MapView1.SetViewpointScaleAsync(double.Parse(TextBox1.Text));

            }
            catch (Exception)
            {

                TextBox1.Text = "";
                ShowMessageDialog("您的输入有误，请重新输入！", "ERROR");
            }

        }

        private void TextBox1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            TextBox1.Text = "";
        }

        private void CheckBox1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked == true)
            {
                MapView1.WrapAroundMode = WrapAroundMode.EnabledWhenSupported;
            }
            else
            {
                MapView1.WrapAroundMode = WrapAroundMode.Disabled;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Bookmark myBookmark1 = new Bookmark();
            myBookmark1.Viewpoint = MapView1.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
            MapView1.Map.Bookmarks.Clear();
            MapView1.Map.Bookmarks.Add(myBookmark1);
            ShowMessageDialog("\n你成功的添加了一个书签\n\n该视点为：", "添加书签");

        }
        private async void ShowMessageDialog(string text, string title)
        {
            var msgDialog = new Windows.UI.Popups.MessageDialog(text) { Title = title };
            msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("确定"));
            msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
            await msgDialog.ShowAsync();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Bookmark myBookmark1 = new Bookmark();
            myBookmark1 = MapView1.Map.Bookmarks[0];
            MapView1.SetViewpointAsync(myBookmark1.Viewpoint);
        }

        private void TextBox1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TextBox1.Text = "";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MapView1.LocationDisplay.IsEnabled = true;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var basemapNameID = "485f83a0dd0340d28bdc4843b7f232f1";
            ViewModel.LoadPortalBasemap(basemapNameID);
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string s = MapView1.SpatialReference.WkText.ToString();
            //弹出一个窗口哦~
            ContentDialog contentDialog1 = new ContentDialog()
            {
                Title = "坐标系单位",
                Content = s,
                PrimaryButtonText = "确定",
                //CloseButtonText = "取消"
            };
            await
                contentDialog1.ShowAsync();

        }
        private void Button_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Boolean b = true;
            jiesuo.IsEnabled = false;
            TextBox1.IsEnabled = b;
            GO.IsEnabled = b;
            CheckBox1.IsEnabled = b;
            拉框放大.IsEnabled = b;
            复位.IsEnabled = b;
            向左旋转.IsEnabled = b;
            向右旋转.IsEnabled = b;
            cun.IsEnabled = b;
            fangwen.IsEnabled = b;
            huoqu.IsEnabled = b;
            zuobiao.IsEnabled = b;

        }

        //鼠标跟随坐标显示
        private void MapView1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (MapView1.GetCurrentViewpoint(ViewpointType.BoundingGeometry) == null)
                return;
            Point screenPoint = e.GetPosition(MapView1);

            MapPoint mapPoint = MapView1.ScreenToLocation(screenPoint);

            if (MapView1.WrapAroundMode == WrapAroundMode.EnabledWhenSupported)
            {
                mapPoint = GeometryEngine.NormalizeCentralMeridian(mapPoint) as MapPoint;

                MapCoords.Text = string.Format
                    (" X ={0}{2},Y={1}{2}", Math.Round(mapPoint.X, 4), Math.Round(mapPoint.Y, 4), MapView1.SpatialReference.Unit.Name.ToString());
                Boarder1.Margin = new Thickness(screenPoint.X, screenPoint.Y, 0, 0);
            }
        }

        //private async void DistanceButton_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    try
        //    {
        //        txtResults.Visibility = Visibility.Collapsed;
        //        Esri.ArcGISRuntime.Geometry.Geometry line = await
        //            MapView1.SketchEditor.StartAsync(SketchCreationMode.Polyline, false);
        //        Graphic drawGraphic = new Graphic(line, mylineSymbol);
        //        mygraphicsOverlay = new GraphicsOverlay();
        //        MapView1.GraphicsOverlays.Add(mygraphicsOverlay);
        //        mygraphicsOverlay.Graphics.Add(drawGraphic);

        //        txtResults.Text = string.Format("距离：{0:000}", distance) + MapView1.SpatialReference.Unit.ToString();
        //        txtResults.Visibility = Visibility.Visible;
        //    }
        //    catch (Exception ex)
        //    {
        //        ContentDialog contentDialog = new ContentDialog()
        //        {
        //            Title = "距离量算",
        //            Content = "距离量算错误" + ex.Message,
        //            PrimaryButtonText = "OK"

        //        };
        //        ContentDialogResult result = await
        //            contentDialog.ShowAsync();

        //        txtResults.Visibility = Visibility.Collapsed;

        //    }
        //}
    }
}
