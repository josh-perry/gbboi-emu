using System;

namespace gbboi_emu
{
    public interface ICartridge
    {
        string Name { get; set; }

        byte[] Bytes { get; set; }
    }
}