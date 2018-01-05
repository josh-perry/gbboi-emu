using System;

namespace gbboi_emu
{
    public interface IMemory
    {
        byte[] Bytes { get; set; }

        void Init(int length);

        byte GetByte(int index);
    }
}