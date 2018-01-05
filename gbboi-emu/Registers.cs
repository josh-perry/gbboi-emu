namespace gbboi_emu
{
    public interface IRegisters
    {
    }

    public class Registers : IRegisters
    {
        public FlagRegister8 F;

        public Register8 A;
        public Register8 B;
        public Register8 C;
        public Register8 D;
        public Register8 E;
        public Register8 H;
        public Register8 L;

        public Register16 AF;
        public Register16 BC;
        public Register16 DE;
        public Register16 HL;

        /// <summary>
        /// Stack pointer
        /// </summary>
        public Register16 SP;

        /// <summary>
        /// Program counter
        /// </summary>
        public Register16 PC;

        public Registers()
        {
            // 8-bit registers
            A = new Register8();
            F = new FlagRegister8();
            B = new Register8();
            C = new Register8();
            D = new Register8();
            E = new Register8();
            H = new Register8();
            L = new Register8();

            // Paired 8-bit into 16-bit registers
            AF = new Register16(A, F);
            BC = new Register16(B, C);
            DE = new Register16(D, E);
            HL = new Register16(H, L);

            // 16-bit registers
            SP = new Register16(new Register8(), new Register8());
            PC = new Register16(new Register8(), new Register8());
        }
    }
}