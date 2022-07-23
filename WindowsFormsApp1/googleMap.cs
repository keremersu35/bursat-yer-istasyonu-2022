using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp1
{
    class googleMap
    {
        Form1 form;
        GMapControl gMap;

        public googleMap(Form1 form,GMapControl gMap)
        {
            this.form = form;
            this.gMap = gMap;
        }
        
        public void gMapControl1_Load()
        {
            gMap.MapProvider = GMapProviders.GoogleMap;
            gMap.Position = new PointLatLng(40.187343622987534, 29.12989315397961);
            gMap.MinZoom = 1;
            gMap.MaxZoom = 24;
            gMap.Zoom = 15;

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(40.187343622987534, 29.12989315397961), GMarkerGoogleType.red);
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(40.187190314637085, 29.13101166174355), GMarkerGoogleType.pink);
            
            markersOverlay.Markers.Add(marker);
            markersOverlay.Markers.Add(marker2);
            
            marker.ToolTipText = "Görev Yükü";
            marker2.ToolTipText = "Taşıyıcı";
            
            gMap.Overlays.Add(markersOverlay);
        }
    }
}
