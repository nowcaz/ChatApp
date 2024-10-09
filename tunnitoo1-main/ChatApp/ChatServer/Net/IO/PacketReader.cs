using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatServer.Net.IO
{
    class PacketReader : BinaryReader   
    {

        public PacketReader(NetworkStream ns) : base(ns) 
        { 
            _ns = ns;
        }

        public string ReadMessage()
        {
            byte[] msgBuffer;
            var lenght = ReadInt32();
            msgBuffer = new byte[lenght];
            _ns.Read(msgBuffer, 0, lenght);

            var msg = Encoding.ASCII.GetString(msgBuffer);
            return msg;
        }
    }
}
