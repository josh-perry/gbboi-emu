using System;

namespace gbboi_emu
{
    public interface IRegister
    {
    }

    public class Register8 : IRegister
    {
        public byte Value;
    }

    public class Register16 : IRegister
    {
        public Register8[] Registers;

        public ushort Value
        {
            get
            {
                return (ushort) ((Registers[0].Value << 8) | Registers[1].Value);
            }
            set
            {
                Registers[0].Value = (byte) (value >> 8);
                Registers[1].Value = (byte) (value & 0x00FF);
            }
        }
        public Register16(Register8 register, Register8 register2)
        {
            Registers = new[] {register, register2};
        }
    }
}
