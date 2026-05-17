using System.Text;
using RabbitizerSharp.Native;

namespace RabbitizerSharp;

public sealed class Instruction : IDisposable
{
    private RabbitizerInstruction _native;
    private bool _disposed;

    public uint Word => _native.Word;
    public uint Vram => _native.Vram;
    public RabbitizerInstrId UniqueId => _native.UniqueId;
    public RabbitizerInstrCategory Category => _native.Category;

    public bool IsNop => RabbitizerNative.RabbitizerInstruction_isNop(in _native);
    public bool IsImplemented => RabbitizerNative.RabbitizerInstruction_isImplemented(in _native);
    public bool IsValid => RabbitizerNative.RabbitizerInstruction_isValid(in _native);
    public bool IsReturn => RabbitizerNative.RabbitizerInstruction_isReturn(in _native);
    public bool IsFunctionCall => RabbitizerNative.RabbitizerInstruction_isFunctionCall(in _native);
    public bool IsUnconditionalBranch => RabbitizerNative.RabbitizerInstruction_isUnconditionalBranch(in _native);
    public bool IsJumptableJump => RabbitizerNative.RabbitizerInstruction_isJumptableJump(in _native);
    public bool IsLikelyHandwritten => RabbitizerNative.RabbitizerInstruction_isLikelyHandwritten(in _native);
    public bool HasDelaySlot => RabbitizerNative.RabbitizerInstruction_hasDelaySlot(in _native);
    public bool MustDisasmAsData => RabbitizerNative.RabbitizerInstruction_mustDisasmAsData(in _native);

    public int ProcessedImmediate => RabbitizerNative.RabbitizerInstruction_getProcessedImmediate(in _native);
    public int BranchOffset => RabbitizerNative.RabbitizerInstruction_getBranchOffset(in _native);
    public uint BranchVram => RabbitizerNative.RabbitizerInstruction_getBranchVramGeneric(in _native);

    public Instruction(uint word, uint vram = 0, RabbitizerInstrCategory category = RabbitizerInstrCategory.Cpu)
    {
        switch (category)
        {
            case RabbitizerInstrCategory.Rsp:
                RabbitizerNative.RabbitizerInstructionRsp_init(ref _native, word, vram);
                RabbitizerNative.RabbitizerInstructionRsp_processUniqueId(ref _native);
                break;
            case RabbitizerInstrCategory.R3000Gte:
                RabbitizerNative.RabbitizerInstructionR3000GTE_init(ref _native, word, vram);
                RabbitizerNative.RabbitizerInstructionR3000GTE_processUniqueId(ref _native);
                break;
            case RabbitizerInstrCategory.R4000Allegrex:
                RabbitizerNative.RabbitizerInstructionR4000Allegrex_init(ref _native, word, vram);
                RabbitizerNative.RabbitizerInstructionR4000Allegrex_processUniqueId(ref _native);
                break;
            case RabbitizerInstrCategory.R5900:
                RabbitizerNative.RabbitizerInstructionR5900_init(ref _native, word, vram);
                RabbitizerNative.RabbitizerInstructionR5900_processUniqueId(ref _native);
                break;
            default:
                RabbitizerNative.RabbitizerInstruction_init(ref _native, word, vram);
                RabbitizerNative.RabbitizerInstruction_processUniqueId(ref _native);
                break;
        }
    }

    public unsafe string Disassemble(string? immOverride = null, int extraLJust = 0)
    {
        byte[]? immBytes = immOverride != null ? Encoding.UTF8.GetBytes(immOverride) : null;
        nuint immLen = immBytes != null ? (nuint)immBytes.Length : 0;

        nuint bufSize = RabbitizerNative.RabbitizerInstruction_getSizeForBuffer(in _native, immLen, extraLJust);
        byte[] buf = new byte[bufSize + 1];

        nuint written;
        fixed (byte* pBuf = buf)
        fixed (byte* pImm = immBytes)
        {
            written = RabbitizerNative.RabbitizerInstruction_disassemble(in _native, pBuf, pImm, immLen, extraLJust);
        }

        return Encoding.UTF8.GetString(buf, 0, (int)written);
    }

    public override string ToString() => Disassemble();

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        switch (_native.Category)
        {
            case RabbitizerInstrCategory.Rsp:
                RabbitizerNative.RabbitizerInstructionRsp_destroy(ref _native);
                break;
            case RabbitizerInstrCategory.R3000Gte:
                RabbitizerNative.RabbitizerInstructionR3000GTE_destroy(ref _native);
                break;
            case RabbitizerInstrCategory.R4000Allegrex:
                RabbitizerNative.RabbitizerInstructionR4000Allegrex_destroy(ref _native);
                break;
            case RabbitizerInstrCategory.R5900:
                RabbitizerNative.RabbitizerInstructionR5900_destroy(ref _native);
                break;
            default:
                RabbitizerNative.RabbitizerInstruction_destroy(ref _native);
                break;
        }
    }
}
