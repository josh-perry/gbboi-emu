using System;
using System.IO;

namespace gbboi_emu
{
    public interface IMmu
    {
        bool BiosMapped { get; set; }

        byte ReadByte(ushort address);

        ushort ReadWord(ushort address);

        void WriteByte(ushort address, byte value);

        void WriteWord(ushort address, ushort value);

        void Initialize(ICartridge cartridge);
    }

    public class Mmu : IMmu
    {
        public IMemory Bios;

        public IMemory Rom;

        public IMemory ZeroPage;

        public IMemory MemoryMappedIo;

        public bool BiosMapped { get; set; }

        public Mmu()
        {
            Bios = new Memory();
            Bios.Init(256);

            Rom = new Memory();
            Rom.Init(0x800000);

            ZeroPage = new Memory();
            ZeroPage.Init(0x7F + 1);

            MemoryMappedIo = new Memory();
            MemoryMappedIo.Init(0x7F + 1);

            BiosMapped = true;
        }

        public byte ReadByte(ushort address)
        {
            switch (address & 0xF000)
            {
                // BIOS (256b)/ROM0
                case 0x0000:
                    if (BiosMapped)
                    {
                        if (address < 0x0100)
                            return Bios.ReadByte(address);
                        //else if (Z80._r.pc == 0x0100)
                        //    MMU._inbios = 0;
                    }

                    return Rom.ReadByte(address);

                case 0x1000:
                case 0x2000:
                case 0x3000:
                    return Bios.ReadByte(address);

                // ROM1 (unbanked) (16k)
                case 0x4000:
                case 0x5000:
                case 0x6000:
                case 0x7000:
                    return Rom.ReadByte(address);

                // Graphics: VRAM (8k)
                case 0x8000:
                case 0x9000:
                //return GPU._vram[addr & 0x1FFF];

                // External RAM (8k)
                case 0xA000:
                case 0xB000:
                //return MMU._eram[addr & 0x1FFF];

                // Working RAM (8k)
                case 0xC000:
                case 0xD000:
                //return MMU._wram[addr & 0x1FFF];

                // Working RAM shadow
                case 0xE000:
                    //return MMU._wram[addr & 0x1FFF];
                    return 0xFF;

                // Working RAM shadow, I/O, Zero-page RAM
                case 0xF000:
                    switch (address & 0x0F00)
                    {
                        // Working RAM shadow
                        case 0x000:
                        case 0x100:
                        case 0x200:
                        case 0x300:
                        case 0x400:
                        case 0x500:
                        case 0x600:
                        case 0x700:
                        case 0x800:
                        case 0x900:
                        case 0xA00:
                        case 0xB00:
                        case 0xC00:
                        case 0xD00:
                            //return MMU._wram[addr & 0x1FFF];

                        // Graphics: object attribute memory
                        // OAM is 160 bytes, remaining bytes read as 0
                        case 0xE00:
                            //if (address < 0xFEA0)
                            //return GPU._oam[address & 0xFF];
                            //else
                            //return 0;
                            return 0xFF;

                        // Zero-page
                        case 0xF00:
                            if (address >= 0xFF80)
                            {
                                return ZeroPage.ReadByte((ushort)(address & 0x7F));
                            }
                            else
                            {
                                return MemoryMappedIo.ReadByte((ushort)(address & 0x7F));
                            }
                        default:
                            return 0xFF;
                    }

                default:
                    return 0xFF;
            }
        }

        public ushort ReadWord(ushort address)
        {
            return (ushort)(ReadByte((ushort)(address + 1)) << 8 | ReadByte(address));
        }

        public void WriteWord(ushort address, ushort value)
        {
            throw new NotImplementedException();
        }

        public void WriteByte(ushort address, byte value)
        {
            switch (address & 0xF000)
            {
                // BIOS (256b)/ROM0
                case 0x0000:
                    if (BiosMapped)
                    {
                        if (address < 0x0100)
                            Bios.WriteByte(address, value);
                        //else if (Z80._r.pc == 0x0100)
                        //    MMU._inbios = 0;
                    }

                    Rom.WriteByte(address, value);
                    return;

                case 0x1000:
                case 0x2000:
                case 0x3000:
                    Rom.WriteByte(address, value);
                    return;

                // ROM1 (unbanked) (16k)
                case 0x4000:
                case 0x5000:
                case 0x6000:
                case 0x7000:
                    Rom.WriteByte(address, value);
                    return;

                // Graphics: VRAM (8k)
                case 0x8000:
                case 0x9000:
                //return GPU._vram[addr & 0x1FFF];

                // External RAM (8k)
                case 0xA000:
                case 0xB000:
                //return MMU._eram[addr & 0x1FFF];

                // Working RAM (8k)
                case 0xC000:
                case 0xD000:
                //return MMU._wram[addr & 0x1FFF];

                // Working RAM shadow
                case 0xE000:
                    //return MMU._wram[addr & 0x1FFF];
                    return;

                // Working RAM shadow, I/O, Zero-page RAM
                case 0xF000:
                    switch (address & 0x0F00)
                    {
                        // Working RAM shadow
                        case 0x000:
                        case 0x100:
                        case 0x200:
                        case 0x300:
                        case 0x400:
                        case 0x500:
                        case 0x600:
                        case 0x700:
                        case 0x800:
                        case 0x900:
                        case 0xA00:
                        case 0xB00:
                        case 0xC00:
                        case 0xD00:
                            //return MMU._wram[addr & 0x1FFF];

                        // Graphics: object attribute memory
                        // OAM is 160 bytes, remaining bytes read as 0
                        case 0xE00:
                            //if (address < 0xFEA0)
                            //return GPU._oam[address & 0xFF];
                            //else
                            //return 0;
                            return;

                        // Zero-page
                        case 0xF00:
                            if (address >= 0xFF80)
                            {
                                ZeroPage.WriteByte((ushort)(address & 0x7F), value);
                                return;
                            }
                            else
                            {
                                MemoryMappedIo.WriteByte((ushort)(address & 0x7F), value);
                            }

                            return;
                        default:
                            return;
                    }
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