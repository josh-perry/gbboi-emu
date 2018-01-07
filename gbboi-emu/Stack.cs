﻿namespace gbboi_emu
{
    public class Stack
    {
        public void Call(ushort address, Registers registers, IMemory memory)
        {
            // Decrement the SP
            // TODO: Stop skipping the first 2 bytes of the stack
            registers.SP.Value -= 2;

            // Add current PC to the stack
            memory.Bytes[registers.SP.Value] = registers.PC.Registers[0].Value;
            memory.Bytes[registers.SP.Value + 1] = registers.PC.Registers[1].Value;

            // Set SP to nn
            registers.PC.Value = (ushort) (address - 2);
        }
    }
}