using System.Net;

namespace UtileriasChat
{
    public class Red
    {
        public static string BROADCAST = "Broadcast";        
        public static IPAddress GetThisMachineIP()
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
            return IPAddress.Parse(localIP);
        }
    }
}
