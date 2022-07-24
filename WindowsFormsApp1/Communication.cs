using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Communication
    {
        IFirebaseClient client;
        public Package package;
        FirebaseResponse response;

        public void initialize()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://bursat-99909-default-rtdb.firebaseio.com/",
                AuthSecret = "PJYq71y5YF5OPOUDLK9dAVjCQWox4tFqQGTkblvf"
            };

            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                Console.WriteLine("Bağlantı hatasi.");
        }

        public async Task getDataAsync()
        {
            response = await client.GetAsync("veriler");
            String packageString = response.ResultAs<String>();
            String[] packageArray = packageString.Split(',');
            package = new Package(packageArray[0], packageArray[1], packageArray[2], packageArray[3], packageArray[4], packageArray[5], packageArray[6], packageArray[7], packageArray[8], packageArray[9],
                packageArray[10], packageArray[11], packageArray[12], packageArray[13], packageArray[14], packageArray[15], packageArray[16], packageArray[17], packageArray[18], packageArray[19], packageArray[20], packageArray[21],
                packageArray[22], packageArray[23], packageArray[24], packageArray[25], packageArray[26], packageArray[27]);
        }

        public async Task writeDataAsync(string adress,int command)
        {
            response = await client.SetAsync<int>(adress, command);
        }

    }
}
