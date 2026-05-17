using System.Runtime.InteropServices;

namespace RabbitizerSharp;

public static unsafe class RabbitizerConfig
{
    // byte offs
    // regNames: 0 to 15  (16 bytes: 1 bool + 3 pad + 4 + 4 + 4 bools)
    // pseudos: 16 to 24  (9 bytes: 9 bools)
    // toolchainTweaks: 25 to 28 (4 bytes +4 bools)
    //   [0] treatJAsUnconditionalBranch
    //   [1] sn64DivFix
    //   [2] gnuMode
    //   [3] r5900ProdgSnAsInvertedRegs
    // misc: 32to39  (8 bytes: 4 + 4 bools, after 3-byte padding for int align)

    private const int GnuModeOffset = 25 + 2;

    private static readonly byte* _cfg;

    static RabbitizerConfig()
    {
        IntPtr lib = NativeLibrary.Load("rabbitizer", typeof(RabbitizerConfig).Assembly, null);
        _cfg = (byte*)(void*)NativeLibrary.GetExport(lib, "RabbitizerConfig_Cfg");
    }

    public static bool GnuMode
    {
        get => _cfg[GnuModeOffset] != 0;
        set => _cfg[GnuModeOffset] = (byte)(value ? 1 : 0);
    }
}
