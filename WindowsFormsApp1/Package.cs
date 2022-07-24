using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Package
    {
        public string teamno;
        public string package_num;
        public string hour;
        public string minute;
        public string second;
        public string day;
        public string month;
        public string year;
        public string pressure1;
        public string pressure2;
        public string altitude1;
        public string altitude2;
        public string altitudediff;
        public string speed;
        public string temperature;
        public string voltage;
        public string gps1latitude;
        public string gps1longitude;
        public string gps1altitude;
        public string gps2latitude;
        public string gps2longitude;
        public string gps2altitude;
        public string state;
        public string pitch;
        public string roll;
        public string yaw;
        public string turncount;
        public string isvideosent;

        public Package(string teamno, string package_num, string hour, string minute, string second, string day, string month, string year, string pressure1, string pressure2, string altitude1, string altitude2,
        string altitudediff, string speed, string temperature, string voltage, string gps1latitude, string gps1longitude, string gps1altitude, string gps2latitude, string gps2longitude, string gps2altitude,
        string state, string pitch, string roll, string yaw, string turncount, string isvideosent)
        {
            this.teamno = teamno;
            this.package_num = package_num;
            this.hour = hour;
            this.minute = minute;
            this.second = minute;
            this.day = day;
            this.month = month;
            this.year = year;
            this.pressure1 = pressure1;
            this.pressure2 = pressure2;
            this.altitude1 = altitude1;
            this.altitude2 = altitude2;
            this.altitudediff = altitudediff;
            this.speed = speed;
            this.temperature = temperature;
            this.voltage = voltage;
            this.gps1latitude = gps1latitude;
            this.gps1longitude = gps1longitude;
            this.gps1altitude = gps1altitude;
            this.gps2latitude = gps2latitude;
            this.gps2longitude = gps2longitude;
            this.gps2altitude = gps2altitude;
            this.state = state;
            this.pitch = pitch;
            this.roll = roll;
            this.yaw = yaw;
            this.turncount = turncount;
            this.isvideosent = isvideosent;
        }
    }
}
