using gbboi_emu.Exceptions;

namespace gbboi_emu.Opcodes
{
    public class UnsupportedOpcode : IOpcode
    {
        public short Length { get; set; } = 0;
        public short Cycles { get; set; } = 0;

        public void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory)
        {
            throw new OperationNotSupportedByCpuException(instruction.Opcode);
        }
    }
}
