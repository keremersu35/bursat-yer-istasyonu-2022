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
        Package package;
        FirebaseResponse response;

        public void initialize()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://bursat-607d3-default-rtdb.firebaseio.com/",
                AuthSecret = "mXbJ8WIreFNSaEDSHYryfUkvwBVViK04Me9cjwT5"
            };

            client = new FireSharp.FirebaseClient(config);

            if (client == null)
                Console.WriteLine("Bağlantı hatasi.");
        }

        public async Task getDataAsync()
        {
            response = await client.GetAsync("veri");
            package = response.ResultAs<Package>();
        }

        public async Task writeDataAsync(string adress,int command)
        {
            response = await client.SetAsync<int>(adress, command);
        }

    }
}
