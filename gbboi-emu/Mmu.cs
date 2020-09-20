using System.IO;

namespace gbboi_emu
{
    public interface IMmu
    {
        bool BiosMapped { get; set; }

        byte ReadByte(ushort address);

        ushort ReadWord(ushort address);

        void WriteByte(ushort address, byte value);

        void Initialize(ICartridge cartridge);
    }

    public class Mmu : IMmu
    {
        public IMemory Bios;

        public IMemory Rom;

        public bool BiosMapped { get; set; }

        public Mmu()
        {
            Bios = new Memory();
            Bios.Init(256);

            Rom = new Memory();
            Rom.Init(32*1024);

            BiosMapped = true;
        }

        public byte ReadByte(ushort address)
        {
            switch(address & 0xF000)
            {
                case 0x0000:
                    if(BiosMapped)
                    {
                        if (address < 0x0100)
                        {
                            return Bios.ReadByte(address);
                        }
                    }

                    return Rom.ReadByte(address);
                case 0x1000:
                case 0x2000:
                case 0x3000:
                    return Rom.ReadByte(address);
                default:
                    return 0xFF;
            }
        }

        public ushort ReadWord(ushort address)
        {
            return (ushort)(ReadByte((ushort)(address + 1)) << 8 | ReadByte(address));
        }

        public void WriteByte(ushort address, byte value)
        {
            switch(address & 0xF000)
            {
                case 0x0000:
                    if(BiosMapped)
                    {
                        if (address < 0x0100)
                        {
                            Bios.WriteByte(address, value);
                        }
                    }

                    Rom.WriteByte(address, value);
                    return;
                case 0x1000:
                case 0x2000:
                case 0x3000:
                    Rom.WriteByte(address, value);
                    return;
                default:
                    return;
            }
        }

        public void Initialize(ICartridge cartridge)
        {
            InitializeBootloader();
            InitializeCartridge(cartridge);
            InitializeMemory();
        }
        
        private void InitializeBootloader()
        {
            var bytes = File.ReadAllBytes(@"TestData/BIOS.gb");
            bytes.CopyTo(Bios.Bytes, 0);
        }

        private void InitializeCartridge(ICartridge cartridge)
        {
            cartridge.Bytes.CopyTo(Rom.Bytes, 0);
        }

        public void InitializeMemory()
        {
            //Memory.Init(0xFFFF + 1);
            //Memory.Bytes[0xFF05] = 0x00; // TIMA
            //Memory.Bytes[0xFF06] = 0x00; // TMA
            //Memory.Bytes[0xFF07] = 0x00; // TAC
            //Memory.Bytes[0xFF10] = 0x80; // NR10
            //Memory.Bytes[0xFF11] = 0xBF; // NR11
            //Memory.Bytes[0xFF12] = 0xF3; // NR12
            //Memory.Bytes[0xFF14] = 0xBF; // NR14
            //Memory.Bytes[0xFF16] = 0x3F; // NR21
            //Memory.Bytes[0xFF17] = 0x00; // NR22
            //Memory.Bytes[0xFF19] = 0xBF; // NR24
            //Memory.Bytes[0xFF1A] = 0x7F; // NR30
            //Memory.Bytes[0xFF1B] = 0xFF; // NR31
            //Memory.Bytes[0xFF1C] = 0x9F; // NR32
            //Memory.Bytes[0xFF1E] = 0xBF; // NR33
            //Memory.Bytes[0xFF20] = 0xFF; // NR41
            //Memory.Bytes[0xFF21] = 0x00; // NR42
            //Memory.Bytes[0xFF22] = 0x00; // NR43
            //Memory.Bytes[0xFF23] = 0xBF; // NR30
            //Memory.Bytes[0xFF24] = 0x77; // NR50
            //Memory.Bytes[0xFF25] = 0xF3; // NR51
            //Memory.Bytes[0xFF26] = 0xF1; // NR52
            //Memory.Bytes[0xFF40] = 0x91; // LCDC
            //Memory.Bytes[0xFF42] = 0x00; // SCY
            //Memory.Bytes[0xFF43] = 0x00; // SCX
            //Memory.Bytes[0xFF45] = 0x00; // LYC
            //Memory.Bytes[0xFF47] = 0xFC; // BGP
            //Memory.Bytes[0xFF48] = 0xFF; // OBP0
            //Memory.Bytes[0xFF49] = 0xFF; // OBP1
            //Memory.Bytes[0xFF4A] = 0x00; // WY
            //Memory.Bytes[0xFF4B] = 0x00; // WX
            //Memory.Bytes[0xFFFF] = 0x00; // IE
        }
    }
}