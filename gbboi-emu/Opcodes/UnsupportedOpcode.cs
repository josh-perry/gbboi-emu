using gbboi_emu.Exceptions;

namespace gbboi_emu
{
    public partial class OpExecutor
    {
        public void UnsupportedOpcode(Stack s, Registers r, Instruction i, IMemory m)
        {
            throw new OperationNotSupportedByCpuException(i.Opcode);
        }
    }
}
