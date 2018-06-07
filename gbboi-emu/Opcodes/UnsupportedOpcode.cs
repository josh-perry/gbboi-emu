﻿using gbboi_emu.Exceptions;

namespace gbboi_emu.Opcodes
{
    public class UnsupportedOpcode : IOpcode
    {
        public string Mnemonic { get; set; } = "UnsupportedOpcode";

        public ushort Length { get; set; } = 0;

        public short Cycles { get; set; } = 0;

        public bool IncrementProgramCounter { get; set; } = false;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new OperationNotSupportedByCpuException(instruction.Opcode);
        }
    }
}