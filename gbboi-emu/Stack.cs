using System;

namespace gbboi_emu
{
    public class Stack
    {
        public void Call(ushort address, Registers registers, IMmu mmu)
        {
            registers.SP.Value -= 2;

            // Add current PC to the stack
            mmu.WriteByte(registers.SP.Value, registers.PC.Registers[0].Value);
            mmu.WriteByte((ushort)(registers.SP.Value + 1), registers.PC.Registers[1].Value);

            // Set SP to nn
            registers.PC.Value = address;
        }

        public void Push(ushort value, Registers registers, IMmu mmu)
        {
            registers.SP.Value -= 2;

            Push((byte)(value >> 8), registers, mmu);
            Push((byte)(value & 0x00FF), registers, mmu);
        }

        public void Push(byte value, Registers registers, IMmu mmu)
        {
            mmu.WriteByte(registers.SP.Value, value);
            mmu.WriteByte((ushort)(registers.SP.Value + 1), value);
        }

        public void Return(Registers registers, IMmu mmu)
        {
            // Decrement stack pointer
            registers.SP.Value -= 2;

            // Set program counter to current stack location
            registers.PC.Registers[0].Value = mmu.ReadByte(registers.SP.Value);
            registers.PC.Registers[1].Value = mmu.ReadByte((ushort)(registers.SP.Value + 1));
        }
    }
}
