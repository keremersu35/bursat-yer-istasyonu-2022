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
        Communication comm;

        public googleMap(Form1 form, GMapControl gMap, Communication comm)
        {
            this.form = form;
            this.gMap = gMap;
            this.comm = comm;
    }
        
        public void gMapControl1_Load()
        {
            comm.getDataAsync();
            gMap.MapProvider = GMapProviders.GoogleMap;
            gMap.Position = new PointLatLng(double.Parse(comm.package.gps1latitude), double.Parse(comm.package.gps1longitude));
            gMap.MinZoom = 1;
            gMap.MaxZoom = 24;
            gMap.Zoom = 15;

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(double.Parse(comm.package.gps1latitude), double.Parse(comm.package.gps1longitude)), GMarkerGoogleType.red);
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(double.Parse(comm.package.gps2latitude), double.Parse(comm.package.gps2longitude)), GMarkerGoogleType.pink);
            
            markersOverlay.Markers.Add(marker);
            markersOverlay.Markers.Add(marker2);
            
            marker.ToolTipText = "Görev Yükü";
            marker2.ToolTipText = "Taşıyıcı";
            
            gMap.Overlays.Add(markersOverlay);
        }
    }
}
