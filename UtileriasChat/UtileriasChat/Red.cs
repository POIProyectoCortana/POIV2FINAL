using System.Net;

namespace UtileriasChat
{
    public class Red
    {
        public static Contacto Broadcast= new Contacto("Broadcast",EstadoCliente.CONECTADO);
        public static string GetThisMachineIP()
        {
            IPHostEntry Host;
            string localIP = "";
            Host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in Host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
