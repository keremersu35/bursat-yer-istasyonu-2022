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
using AForge.Video;
using AForge.Video.DirectShow;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Thread cpuThread;
        private double[] cpuArray = new double[60];
        
        FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        VideoCaptureDevice videoSource = null;
        public Form1()
        {
            InitializeComponent();
            cpuThread = new Thread(new ThreadStart(this.getPerformanceCounters));
            cpuThread.IsBackground = true;
            cpuThread.Start();
            
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += video_NewFrame;
            videoSource.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            anlikGoruntu.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void getPerformanceCounters()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);

                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);

                if (sicaklikGrafik.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(1000);
            }
        }

        private void UpdateCpuChart()
        {
            sicaklikGrafik.Series["Series1"].Points.Clear();
            yukseklikGrafik.Series["Series1"].Points.Clear();
            pilGerilimiGrafik.Series["Series1"].Points.Clear();
            inisHiziGrafik.Series["Series1"].Points.Clear();
            basincGrafik.Series["Series1"].Points.Clear();
            gpsAltitudeGrafik.Series["Series1"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                sicaklikGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
                yukseklikGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
                pilGerilimiGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
                inisHiziGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
                basincGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
                gpsAltitudeGrafik.Series["Series1"].Points.AddY(cpuArray[i]);
            }
        }

        private void kalibreEtButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                videoSource.SignalToStop();
                videoSource = null;
                if (!(videoSource == null))
                {
                    videoSource.Stop();
                    videoSource = null;
                }
            }
            catch { }
            Application.Exit();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMapProviders.GoogleMap;
            gMap.Position = new PointLatLng(40.187343622987534, 29.12989315397961);
            gMap.MinZoom = 1;
            gMap.MaxZoom = 24;
            gMap.Zoom = 15;

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(40.187343622987534, 29.12989315397961), GMarkerGoogleType.red);
            markersOverlay.Markers.Add(marker);
            marker.ToolTipText = "Uydu";
            gMap.Overlays.Add(markersOverlay);
        }
    }
}
