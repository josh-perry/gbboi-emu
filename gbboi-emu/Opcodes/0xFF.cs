namespace gbboi_emu
{
    public partial class Opcodes
    {
        /// <summary>
        /// RST 38
        /// Call routine at address 0038h
        /// </summary>
        public void _0xFF(Stack stack, Registers registers, IMemory memory)
        {
            stack.Call(0x0038, registers, memory);
        }
    }
}
