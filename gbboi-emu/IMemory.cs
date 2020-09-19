namespace gbboi_emu
{
    public interface IMemory
    {
        byte[] Bytes { get; set; }

        void Init(int length);

        byte ReadByte(ushort address);

        ushort ReadWord(ushort address);

        void LoadMemoryBankFromFile(string filepath, int index);
    }
}