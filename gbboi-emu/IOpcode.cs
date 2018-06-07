namespace gbboi_emu
{
    public interface IOpcode
    {
        short Length { get; set; }

        short Cycles { get; set; }

        void Execute(Stack stack, Registers registers, Instruction instruction, IMemory memory);
    }
}
