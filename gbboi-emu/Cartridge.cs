using System;
using System.IO;
using System.Linq;
using System.Text;

namespace gbboi_emu
{
    public class Cartridge : ICartridge
    {
        public string Name
        {
            get
            {
                var nameSegment = new ArraySegment<byte>(Bytes, 0x134, 16);

                return Encoding.ASCII.GetString(nameSegment.ToArray());
            }
            set {}
        }

        public byte[] Bytes { get; set; }

        public void LoadFromFile(string filepath)
        {
            Bytes = File.ReadAllBytes(filepath);
        }
    }
}
