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

    public class FlagRegister8 : Register8
    {
        private enum FlagBits
        {
            Zero = 7,
            Subtract = 6,
            HalfCarry = 5,
            Carry = 4
        }

        public bool CarryFlag
        {
            get
            {
                return ((Value >> (int)FlagBits.Carry) & 1) != 0;
            }
            set
            {
                Value |= 1 << (int)FlagBits.Carry;
            }
        }

        public bool ZeroFlag
        {
            get
            {
                return ((Value >> (int)FlagBits.Zero) & 1) != 0;
            }
            set
            {
                Value |= 1 << (int)FlagBits.Zero;
            }
        }

        public bool SubtractFlag
        {
            get
            {
                return ((Value >> (int)FlagBits.Subtract) & 1) != 0;
            }
            set
            {
                Value |= 1 << (int)FlagBits.Subtract;
            }
        }

        public bool HalfCarryFlag
        {
            get
            {
                return ((Value >> (int)FlagBits.HalfCarry) & 1) != 0;
            }
            set
            {
                Value |= 1 << (int)FlagBits.HalfCarry;
            }
        }
    }
}
