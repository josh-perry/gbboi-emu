using System.IO;
using gbboi_emu.Exceptions;

namespace gbboi_emu
{
    public class GameBoy
    {
        public ICpu Cpu;

        public IMmu Mmu;

        public ICartridge Cartridge;

        public GameBoy(ICpu cpu, IMmu mmu)
        {
            Cpu = cpu;
            Mmu = mmu;
        }

        public GameBoy(ICpu cpu, IMmu mmu, ICartridge cartridge) : this(cpu, mmu)
        {
            Cartridge = cartridge;
            Mmu = mmu;
        }

        public void PowerUp()
        {
            Mmu.Initialize(Cartridge);
            InitializeRegisters();
            
            Cpu.Registers.PC.Value = 0x0100;
        }

        public void InitializeRegisters()
        {
            Cpu.Registers.AF.Value = 0x01B0;
            Cpu.Registers.BC.Value = 0x0013;
            Cpu.Registers.DE.Value = 0x00D8;
            Cpu.Registers.HL.Value = 0x014D;
            Cpu.Registers.SP.Value = 0xFFFE;
        }
    }
}
