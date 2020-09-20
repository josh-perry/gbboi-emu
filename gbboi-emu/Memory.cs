using System;
using System.IO;

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
        public byte ReadByte(ushort address)
        {
            return Bytes[address];
        }

        /// <summary>
        /// Get a word byte from memory at index.
        /// </summary>
        /// <param name="index">The index to read the word from</param>
        /// <returns></returns>
        public ushort ReadWord(ushort address)
        {
            return (ushort)(ReadByte((ushort)(address + 1)) << 8 | ReadByte(address));
        }

        /// <summary>
        /// Write byte to address.
        /// </summary>
        /// <param name="index">The index to write the byte to</param>
        /// <returns></returns>
        public void WriteByte(ushort address, byte value)
        {
            Bytes[address] = value;
        }

        /// <summary>
        /// Copies data from a file into memory at index
        /// </summary>
        /// <param name="filepath">The path to load data from</param>
        /// <param name="index">The index to insert this data into in memory</param>
        public void LoadMemoryBankFromFile(string filepath, int index)
        {
            var data = File.ReadAllBytes(filepath);

            data.CopyTo(Bytes, index);
        }
    }
}