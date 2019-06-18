using Sacho_NetworkAdapter;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinLib.Network;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = NetWorkAdapter.GetAcceptableIPv4NetList();
            //Console.ReadKey();


            ConcurrentDictionary<Guid, MyNetworkInterface> NetworkInterfaces = WinLib.Network.MyNetworkInterface.GetAll(null);
            foreach (MyNetworkInterface nic in NetworkInterfaces.Values)
            {
                Console.WriteLine(nic.Name);
                for (int i = 0; i < nic.IPv4Address.Count; i++)
                    ConsoleStrs (new string[] { i == 0 ? "Address IP & Mask" : "", nic.IPv4Address[i].Address, nic.IPv4Address[i].Subnet });
                for (int i = 0; i < nic.IPv4Gateway.Count; i++)
                    ConsoleStrs(new string[] { i == 0 ? "Gateway IP & Metric" : "", nic.IPv4Gateway[i].Address, nic.IPv4Gateway[i].GatewayMetric.ToString() });
                for (int i = 0; i < nic.IPv4DnsServer.Count; i++)
                    ConsoleStrs(new string[] { i == 0 ? "DNS Server" : "", nic.IPv4DnsServer[i] });
                ConsoleStrs(new string[] { "DHCP Enabled", nic.DhcpEnabledString });
                if (nic.DhcpServer != null && nic.DhcpServer != "255.255.255.255")
                    ConsoleStrs(new string[] { "DHCP Server", nic.DhcpServer });
                ConsoleStrs(new string[] { "NetBIOS over TCP/IP", nic.NetbiosEnabledString });
                ConsoleStrs(new string[] { "MTU", nic.IPv4Mtu.ToString() });
     
            }
            Console.ReadKey();
        }


        static void ConsoleStrs(string[] str)
        {
            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");
        }
    }
}
