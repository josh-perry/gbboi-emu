using System;

namespace gbboi_emu
{
    public class OpCodeNotSupportedException : Exception
    {
        public OpCodeNotSupportedException(string message) : base(message)
        {
        }
    }
}