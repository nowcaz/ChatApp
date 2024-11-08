using System;
using System.IO;
using System.Text;

namespace ChatApp.Net.IO
{
    class PacketBuilder
    {
        private MemoryStream _ms;

        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgBytes = Encoding.UTF8.GetBytes(msg);
            var msgLength = msgBytes.Length;
            _ms.Write(BitConverter.GetBytes(msgLength), 0, sizeof(int)); 
            _ms.Write(msgBytes, 0, msgLength); 
        }

        public byte[] GetPacketBytes()
        {
            var packetBytes = _ms.ToArray();
            _ms.SetLength(0); 
            return packetBytes;
        }
    }
}