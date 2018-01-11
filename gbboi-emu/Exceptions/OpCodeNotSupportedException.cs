using System;

namespace gbboi_emu.Exceptions
{
    public class OpCodeNotSupportedException : Exception
    {
        public OpCodeNotSupportedException(string message) : base(message)
        {
        }
    }
}