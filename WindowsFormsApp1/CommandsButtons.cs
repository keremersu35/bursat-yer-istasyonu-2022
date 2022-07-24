using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApp1
{
    class CommandsButtons
    {
        Form1 form;
        DataGridView dataTable;
        Communication comm;

        public CommandsButtons(Form1 form, DataGridView dataTable, Communication comm)
        {
            this.form = form;
            this.dataTable = dataTable;
            this.comm = comm;
        }

        public void secButton_Click()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            file.FilterIndex = 2;
            file.ShowDialog();
        }

        public void ayirButton_Click()
        {
            comm.writeDataAsync("release", 1);
        }

        public void baslatButton_Click()
        {
            comm.writeDataAsync("motors", 1);
        }

        public void durdurButton_Click()
        {
            comm.writeDataAsync("motors", 0);
        }

        public void sertKalibreButton_Click()
        {
            comm.writeDataAsync("calibrate", 1);
        }

        public void yumusakKalibreButton_Click()
        {
            comm.writeDataAsync("calibrate", 2);
        }

        public void Form1_Load()
        {
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.WindowState = FormWindowState.Maximized;
        }

        public void TableUpdate()
        {
            int rowNo = dataTable.Rows.Add();
            comm.getDataAsync();
            string iString = comm.package.day + "/" + comm.package.month + "/" + comm.package.year + "\n" + comm.package.hour + ":" + comm.package.minute.ToString() + ":" + comm.package.second;
            //DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            dataTable.Rows[rowNo].Cells[0].Value = comm.package.teamno;
            dataTable.Rows[rowNo].Cells[1].Value = comm.package.package_num;
            dataTable.Rows[rowNo].Cells[2].Value = iString;
            dataTable.Rows[rowNo].Cells[3].Value = comm.package.pressure1;
            dataTable.Rows[rowNo].Cells[4].Value = comm.package.pressure2; 
            dataTable.Rows[rowNo].Cells[5].Value = comm.package.altitude1;
            dataTable.Rows[rowNo].Cells[6].Value = comm.package.altitude2;
            dataTable.Rows[rowNo].Cells[7].Value = comm.package.altitudediff;
            dataTable.Rows[rowNo].Cells[8].Value = comm.package.speed;
            dataTable.Rows[rowNo].Cells[9].Value = comm.package.temperature;
            dataTable.Rows[rowNo].Cells[10].Value = comm.package.voltage;
            dataTable.Rows[rowNo].Cells[11].Value = comm.package.gps1latitude;
            dataTable.Rows[rowNo].Cells[12].Value = comm.package.gps1longitude;
            dataTable.Rows[rowNo].Cells[13].Value = comm.package.gps1altitude;
            dataTable.Rows[rowNo].Cells[14].Value = comm.package.gps2latitude;
            dataTable.Rows[rowNo].Cells[15].Value = comm.package.gps2longitude;
            dataTable.Rows[rowNo].Cells[16].Value = comm.package.gps2altitude;
            dataTable.Rows[rowNo].Cells[17].Value = comm.package.state;
            dataTable.Rows[rowNo].Cells[18].Value = comm.package.pitch;
            dataTable.Rows[rowNo].Cells[19].Value = comm.package.roll;
            dataTable.Rows[rowNo].Cells[20].Value = comm.package.yaw;
            dataTable.Rows[rowNo].Cells[21].Value = comm.package.turncount;
            dataTable.Rows[rowNo].Cells[22].Value = comm.package.isvideosent;

            dataTable.FirstDisplayedScrollingRowIndex = rowNo;
        }


    }
}
