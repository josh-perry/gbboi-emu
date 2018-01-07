using System;

namespace gbboi_emu
{
    public class GameBoy
    {
        public ICpu Cpu;

        public IMemory Memory;

        public ICartridge Cartridge;

        public GameBoy(ICpu cpu, IMemory memory)
        {
            Cpu = cpu;
            Memory = memory;
        }

        public GameBoy(ICpu cpu, IMemory memory, ICartridge cartridge) : this(cpu, memory)
        {
            Cartridge = cartridge;
        }

        public void PowerUp()
        {
            InitializeMemory();
            InitializeRegisters();
            InitializeCartridge();
            
            Cpu.Registers.PC.Value = 0x0100;
        }

        private void InitializeCartridge()
        {
            if (Cartridge == null)
            {
                throw new NoCartridgeInsertedException();
            }
            
            Cartridge.Bytes.CopyTo(Memory.Bytes, 0);
        }

        public void InitializeRegisters()
        {
            Cpu.Registers.AF.Value = 0x01B0;
            Cpu.Registers.BC.Value = 0x0013;
            Cpu.Registers.DE.Value = 0x00D8;
            Cpu.Registers.HL.Value = 0x014D;
            Cpu.Registers.SP.Value = 0xFFFE;
        }

        public void InitializeMemory()
        {
            Memory.Init(0xFFFF + 1);
            
            Memory.Bytes[0xFF05] = 0x00; // TIMA
            Memory.Bytes[0xFF06] = 0x00; // TMA
            Memory.Bytes[0xFF07] = 0x00; // TAC
            Memory.Bytes[0xFF10] = 0x80; // NR10
            Memory.Bytes[0xFF11] = 0xBF; // NR11
            Memory.Bytes[0xFF12] = 0xF3; // NR12
            Memory.Bytes[0xFF14] = 0xBF; // NR14
            Memory.Bytes[0xFF16] = 0x3F; // NR21
            Memory.Bytes[0xFF17] = 0x00; // NR22
            Memory.Bytes[0xFF19] = 0xBF; // NR24
            Memory.Bytes[0xFF1A] = 0x7F; // NR30
            Memory.Bytes[0xFF1B] = 0xFF; // NR31
            Memory.Bytes[0xFF1C] = 0x9F; // NR32
            Memory.Bytes[0xFF1E] = 0xBF; // NR33
            Memory.Bytes[0xFF20] = 0xFF; // NR41
            Memory.Bytes[0xFF21] = 0x00; // NR42
            Memory.Bytes[0xFF22] = 0x00; // NR43
            Memory.Bytes[0xFF23] = 0xBF; // NR30
            Memory.Bytes[0xFF24] = 0x77; // NR50
            Memory.Bytes[0xFF25] = 0xF3; // NR51
            Memory.Bytes[0xFF26] = 0xF1; // NR52
            Memory.Bytes[0xFF40] = 0x91; // LCDC
            Memory.Bytes[0xFF42] = 0x00; // SCY
            Memory.Bytes[0xFF43] = 0x00; // SCX
            Memory.Bytes[0xFF45] = 0x00; // LYC
            Memory.Bytes[0xFF47] = 0xFC; // BGP
            Memory.Bytes[0xFF48] = 0xFF; // OBP0
            Memory.Bytes[0xFF49] = 0xFF; // OBP1
            Memory.Bytes[0xFF4A] = 0x00; // WY
            Memory.Bytes[0xFF4B] = 0x00; // WX
            Memory.Bytes[0xFFFF] = 0x00; // IE
        }
    }
}
