using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.Portal;

namespace Arcgis_ex1
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {

        }

        //private Map _map = new Map(Basemap.CreateStreetsVector());
        private Map _map = new Map();

        public /*async*/ void LoadPortalBasemap(string webmapID)
        {


            var itemID = "http://www.arcgisonline.cn/arcgis/home/item.html?id=" + webmapID;

            Map webMap = new Map(new Uri(itemID));

            Map = webMap;
            //ArcGISPortal agsOnline =
            //    await
            //    ArcGISPortal.CreateAsync(new Uri("https://www.arcgis.com/sharing/rest"));
            //ArcGISPortal agsOnline =
            //    await
            //    ArcGISPortal.CreateAsync();
            //PortalItem myPortalItem =
            //    await
            //    PortalItem.CreateAsync(agsOnline, itemID);
            //_map.Basemap = new Basemap(myPortalItem);

        }

        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Raises the <see cref="MapViewModel.PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
