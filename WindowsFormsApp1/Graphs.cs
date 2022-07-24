using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    class Graphs
    {
        Form1 form;
        Communication comm;
        Chart sicaklikGrafik;
        Chart yukseklikGrafik;
        Chart yukseklikGrafik2;
        Chart basincGrafik;
        Chart basincGrafik2;
        Chart inisHiziGrafik;
        Chart gpsAltitudeGrafik;
        Chart pilGerilimiGrafik;

        private double[] cpuArray = new double[60];

        public Graphs(Form1 form, Communication comm, Chart sicaklikGrafik, Chart yukseklikGrafik, Chart yukseklikGrafik2, Chart basincGrafik, Chart basincGrafik2, Chart inisHiziGrafik, Chart gpsAltitudeGrafik, Chart pilGerilimiGrafik)
        {
            this.form = form;
            this.comm = comm;
            this.sicaklikGrafik = sicaklikGrafik;
            this.yukseklikGrafik = yukseklikGrafik;
            this.yukseklikGrafik2 = yukseklikGrafik2;
            this.basincGrafik = basincGrafik;
            this.basincGrafik2 = basincGrafik2;
            this.inisHiziGrafik = inisHiziGrafik;
            this.gpsAltitudeGrafik = gpsAltitudeGrafik;
            this.pilGerilimiGrafik = pilGerilimiGrafik;
        }

        public void UpdateCpuChart()
        {
            sicaklikGrafik.Series["Sıcaklık (°C)"].Points.Clear();
            yukseklikGrafik.Series["Yükseklik 1 (m)"].Points.Clear();
            pilGerilimiGrafik.Series["Pil Gerilimi (V)"].Points.Clear();
            inisHiziGrafik.Series["İniş Hızı (m/s)"].Points.Clear();
            basincGrafik.Series["Basınç 1 (Pa)"].Points.Clear();
            yukseklikGrafik2.Series["Yükseklik 2 (m)"].Points.Clear();
            basincGrafik2.Series["Basınç 2 (Pa)"].Points.Clear();
            gpsAltitudeGrafik.Series["GPS Altitude (m)"].Points.Clear();


            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                sicaklikGrafik.Series["Sıcaklık (°C)"].Points.AddY(double.Parse(comm.package.temperature));
                yukseklikGrafik.Series["Yükseklik 1 (m)"].Points.AddY(double.Parse(comm.package.altitude1));
                pilGerilimiGrafik.Series["Pil Gerilimi (V)"].Points.AddY(double.Parse(comm.package.voltage));
                inisHiziGrafik.Series["İniş Hızı (m/s)"].Points.AddY(double.Parse(comm.package.speed));
                basincGrafik.Series["Basınç 1 (Pa)"].Points.AddY(double.Parse(comm.package.pressure1));
                yukseklikGrafik2.Series["Yükseklik 2 (m)"].Points.AddY(double.Parse(comm.package.altitude2));
                basincGrafik2.Series["Basınç 2 (Pa)"].Points.AddY(double.Parse(comm.package.pressure2));
                gpsAltitudeGrafik.Series["GPS Altitude (m)"].Points.AddY(double.Parse(comm.package.gps1altitude));
            }
        }

        public void getPerformanceCounters()
        {
   
            while (true)
            {

                if (sicaklikGrafik.IsHandleCreated)
                {
                    form.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }

                Thread.Sleep(1000);
            }
        }

    }
}
