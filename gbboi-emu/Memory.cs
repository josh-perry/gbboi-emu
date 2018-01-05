namespace gbboi_emu
{
    /// <summary>
    /// A generic bank of memory.
    /// </summary>
    public class Memory : IMemory
    {
        /// <summary>
        /// The actual memory. Raw array of bytes.
        /// </summary>
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Constructor. Initializes bytes to all zero.
        /// </summary>
        public void Init(int length)
        {
            Bytes = new byte[length];
        }

        /// <summary>
        /// Get a single byte from memory at index.
        /// </summary>
        /// <param name="index">The index to read the byte from</param>
        /// <returns></returns>
        public byte GetByte(int index)
        {
            return Bytes[index];
        }
    }
}