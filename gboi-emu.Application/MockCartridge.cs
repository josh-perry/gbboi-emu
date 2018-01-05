using gbboi_emu;

namespace gboi_emu.Application
{
    public class MockCartridge : ICartridge
    {
        public string Name { get; set; }
        public byte[] Bytes { get; set; }

        public MockCartridge()
        {
            Name = "Mock cart";
            Bytes = new byte[32 * 1024];
        }
    }
}
