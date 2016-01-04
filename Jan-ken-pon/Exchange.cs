using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jan_ken_pon
{
    static class Exchange
    {
       public static TcpListener server;
       public static TcpClient client;
       public static NetworkStream ns;
       public static BinaryReader read;
       public static BinaryWriter write;

       public static TcpListener serverChat;
       public static TcpClient clientChat;
       public static NetworkStream nsChat;
       public static BinaryReader readChat;
       public static BinaryWriter writeChat;
    }
}
