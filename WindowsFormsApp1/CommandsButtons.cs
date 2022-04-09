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

        public CommandsButtons(Form1 form, DataGridView dataTable)
        {
            this.form = form;
            this.dataTable = dataTable;
        }

        public void secButton_Click()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            file.FilterIndex = 2;
            file.ShowDialog();
        }

        public void Form1_Load()
        {
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.WindowState = FormWindowState.Maximized;

        }

        public void TableUpdate()
        {
            int rowNo = dataTable.Rows.Add();

            dataTable.Rows[rowNo].Cells[0].Value = 319705;
            dataTable.Rows[rowNo].Cells[1].Value = rowNo;
            dataTable.Rows[rowNo].Cells[2].Value = DateTime.Now.ToString("HH:mm:ss");
            dataTable.Rows[rowNo].Cells[3].Value = 1;
            dataTable.Rows[rowNo].Cells[4].Value = 1;
            dataTable.Rows[rowNo].Cells[5].Value = 12;
            dataTable.Rows[rowNo].Cells[6].Value = 11.5;
            dataTable.Rows[rowNo].Cells[7].Value = 0.5;
            dataTable.Rows[rowNo].Cells[8].Value = 65;
            dataTable.Rows[rowNo].Cells[9].Value = 23;
            dataTable.Rows[rowNo].Cells[10].Value = 5.2;
            dataTable.Rows[rowNo].Cells[11].Value = 45.2312;
            dataTable.Rows[rowNo].Cells[12].Value = 18.343;
            dataTable.Rows[rowNo].Cells[13].Value = 2.412;
            dataTable.Rows[rowNo].Cells[14].Value = 45.2312;
            dataTable.Rows[rowNo].Cells[15].Value = 18.343;
            dataTable.Rows[rowNo].Cells[16].Value = 2.412;
            dataTable.Rows[rowNo].Cells[17].Value = 0;
            dataTable.Rows[rowNo].Cells[18].Value = 10.25;
            dataTable.Rows[rowNo].Cells[19].Value = 15.93;
            dataTable.Rows[rowNo].Cells[20].Value = 347.16;
            dataTable.Rows[rowNo].Cells[21].Value = 0;
            dataTable.Rows[rowNo].Cells[22].Value = "Aktarılmadı";

            dataTable.FirstDisplayedScrollingRowIndex = rowNo;
        }


    }
}
