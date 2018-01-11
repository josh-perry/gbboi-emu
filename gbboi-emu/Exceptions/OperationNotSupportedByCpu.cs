using System;

namespace gbboi_emu.Exceptions
{
    public class OperationNotSupportedByCpuException : Exception
    {
        public OperationNotSupportedByCpuException(ushort opcode) : base($"Opcode 0x{opcode.ToString("X4")} not supported!")
        {
        }
    }
}
