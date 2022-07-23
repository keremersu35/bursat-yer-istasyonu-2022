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
     
        googleMap Gmap;
        CommandsButtons CommandsButtons;
        Graphs Graphs;

        public System.Windows.Forms.Timer myTimer2 = new System.Windows.Forms.Timer();
        
        FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        VideoCaptureDevice videoSource = null;

        
        public Form1()
        {
            InitializeComponent();

            Gmap = new googleMap(this, gMap);
            CommandsButtons = new CommandsButtons(this, dataTable);
            Graphs = new Graphs(this, sicaklikGrafik, yukseklikGrafik, yukseklikGrafik2, basincGrafik, basincGrafik2, inisHiziGrafik, gpsAltitudeGrafik, pilGerilimiGrafik);

            cpuThread = new Thread(new ThreadStart(Graphs.getPerformanceCounters));
            cpuThread.IsBackground = true;
            cpuThread.Start();

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += video_NewFrame;
            videoSource.Start();

            myTimer2.Tick += new EventHandler(TableUpdate);
            myTimer2.Interval = 1000;
            myTimer2.Start();

            Communication communication = new Communication();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CommandsButtons.Form1_Load();
        }

        public void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            anlikGoruntu.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            Gmap.gMapControl1_Load();
        }

        private void TableUpdate(object sender, EventArgs e)
        {
            CommandsButtons.TableUpdate();
        }

        private void secButton_Click(object sender, EventArgs e)
        {
            CommandsButtons.secButton_Click();
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

    }
}
