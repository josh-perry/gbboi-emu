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

        public byte[] Value
        {
            get
            {
                return new[] { Registers[0].Value, Registers[1].Value };
            }
            set
            {
                if (value.Length != 2)
                    throw new Exception("Expected 2 bytes!");

                Registers[0].Value = value[0];
                Registers[1].Value = value[1];
            }
        }

        public Register16(Register8 register, Register8 register2)
        {
            Registers = new[] {register, register2};
        }
    }
}
