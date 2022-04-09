//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WindowsFormsApp1
//{
//    class Gyro
//    {
//        Form1 form;
//        public Gyro(Form1 form)
//        {
//            this.form = form;
//        }

//        protected override void OnPaint(PaintEventArgs paintEvnt)
//        {
//            // Calling the base class OnPaint
//            form.OnPaint(paintEvnt);


//            // Clipping mask for Attitude Indicator
//            paintEvnt.Graphics.Clip = new Region(new Rectangle(0, 0, 300, 300));
//            paintEvnt.Graphics.FillRegion(Brushes.Black, paintEvnt.Graphics.Clip);


//            // Make sure lines are drawn smoothly
//            paintEvnt.Graphics.SmoothingMode = SmoothingMode.HighQuality;

//            // Create the graphics object
//            Graphics gfx = paintEvnt.Graphics;

//            // Adjust and draw horizon image
//            RotateAndTranslate(paintEvnt, mybitmap1, RollAngle, 0, ptBoule, (double)(4 * PitchAngle), ptRotation, 1);

//            RotateAndTranslate2(paintEvnt, mybitmap3, YawAngle, RollAngle, 0, ptHeading, (double)(4 * PitchAngle), ptRotation, 1);



//            // Draw a mask
//            //Pen maskPen = new Pen(this.BackColor, 220); // width of mask
//            //gfx.DrawRectangle(maskPen, -100, -100, 500, 500); // size of mask

//            gfx.DrawImage(mybitmap2, 0, 0); // Draw bezel image
//            gfx.DrawImage(mybitmap4, 75, 125); // Draw wings image

//            //myPen = new Pen(System.Drawing.Color.Green, 3);
//            //gfx.DrawLine(myPen, 200, 20, 20, 210); // Draw a line

//            // The sliders are updated from the Pitch, Roll & Yaw values (calculated first from serial data)
//            //slider1.Value = Convert.ToInt16(PitchAngle); //Update sliders
//            //slider2.Value = Convert.ToInt16((-1.0 * RollAngle / Math.PI) * 180);  //with values from
//            //slider3.Value = Convert.ToInt16((YawAngle / Math.PI) * 180);   //serial data (if available)           

//            // Update text boxes with angles (if we have any)

//            if (port.IsOpen == false) // Use slider values if port is closed
//            {
//                textBox1.Text = Convert.ToString(slider1.Value);
//                textBox2.Text = Convert.ToString(slider2.Value);
//                textBox3.Text = Convert.ToString(slider3.Value);
//            }

//            if (ArduinoData != null && port.IsOpen == true) // Use Arduino data if port is open
//            {
//                textBox1.Text = ArduinoData[0];
//                textBox2.Text = ArduinoData[1];
//                textBox3.Text = ArduinoData[2];
//            }

//        }

//        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
//        {

//            if (port.IsOpen == true)
//            {
//                RxString = port.ReadLine();
//                ArduinoData = RxString.Split(',', '\n', '\r');

//                if (ArduinoData.Count() == 4) //ensures we have all data, plus line end ("\n" or "\r")
//                {
//                    PitchAngle = Convert.ToDouble(ArduinoData[0]);
//                    RollAngle = -1.0 * Convert.ToDouble(ArduinoData[1]) * Math.PI / 180;
//                    YawAngle = -1.0 * Convert.ToDouble(ArduinoData[2]) * Math.PI / 180;
//                    if (YawAngle < -Math.PI) YawAngle = YawAngle + Math.PI;
//                    Invalidate();
//                }
//            }
//        }
//    }
//}
