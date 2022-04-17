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
        Chart sicaklikGrafik;
        Chart yukseklikGrafik;
        Chart yukseklikGrafik2;
        Chart basincGrafik;
        Chart basincGrafik2;
        Chart inisHiziGrafik;
        Chart gpsAltitudeGrafik;
        Chart pilGerilimiGrafik;

        private double[] cpuArray = new double[60];

        public Graphs(Form1 form, Chart sicaklikGrafik, Chart yukseklikGrafik, Chart yukseklikGrafik2, Chart basincGrafik, Chart basincGrafik2, Chart inisHiziGrafik, Chart gpsAltitudeGrafik, Chart pilGerilimiGrafik)
        {
            this.form = form;
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
                sicaklikGrafik.Series["Sıcaklık (°C)"].Points.AddY(cpuArray[i]);
                yukseklikGrafik.Series["Yükseklik 1 (m)"].Points.AddY(cpuArray[i]);
                pilGerilimiGrafik.Series["Pil Gerilimi (V)"].Points.AddY(cpuArray[i]);
                inisHiziGrafik.Series["İniş Hızı (m/s)"].Points.AddY(cpuArray[i]);
                basincGrafik.Series["Basınç 1 (Pa)"].Points.AddY(cpuArray[i]);
                yukseklikGrafik2.Series["Yükseklik 2 (m)"].Points.AddY(cpuArray[i]);
                basincGrafik2.Series["Basınç 2 (Pa)"].Points.AddY(cpuArray[i]);
                gpsAltitudeGrafik.Series["GPS Altitude (m)"].Points.AddY(cpuArray[i]);
            }
        }

        public void getPerformanceCounters()
        {
            var cpuPerfCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (true)
            {
                cpuArray[cpuArray.Length - 1] = Math.Round(cpuPerfCounter.NextValue(), 0);

                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);

                if (sicaklikGrafik.IsHandleCreated)
                {
                    form.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }

                Thread.Sleep(1000);
            }
        }

    }
}
