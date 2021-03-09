using System.Runtime.InteropServices;

namespace Les3Ex1
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public int i;

        [FieldOffset(0)]
        public float f;
    }
}
