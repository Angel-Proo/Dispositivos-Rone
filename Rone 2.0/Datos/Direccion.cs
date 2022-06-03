using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Rone_2._0.Datos
{
    public class Direccion
    {
        public string Nueva_Direccion { get; set; }
        public Dictionary<int, string> IPs = new Dictionary<int, string>();

        public string ObtenerIP()
        {
            string Ip = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            int i = 0;
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    //Console.WriteLine(ip.ToString() + Ip.GetType().Name);
                    
                    Ip = ip.ToString();
                    IPs.Add(i, Ip);
                    i += 1;
                }
            }
            return Ip;
        }
        public string IP_Seleccionada(string direccion)
        {
            return Nueva_Direccion = direccion;
        }
    }
}
