using System.Runtime.InteropServices;

namespace RabbitizerSharp.Native;

internal static unsafe partial class RabbitizerNative
{
    private const string LibName = "rabbitizer";

    [DllImport(LibName)]
    internal static extern RabbitizerAbi RabbitizerAbi_fromStr([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_init(ref RabbitizerInstruction self, uint word, uint vram);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_destroy(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Normal(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Special(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Regimm(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor0_BC0(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor0_Tlb(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor0(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1_BC1(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1_FpuS(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1_FpuD(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1_FpuW(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1_FpuL(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor1(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId_Coprocessor2(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_processUniqueId(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern uint RabbitizerInstruction_getRaw(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern int RabbitizerInstruction_getProcessedImmediate(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern uint RabbitizerInstruction_getInstrIndexAsVram(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern int RabbitizerInstruction_getBranchOffset(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern int RabbitizerInstruction_getBranchOffsetGeneric(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern uint RabbitizerInstruction_getBranchVramGeneric(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern sbyte RabbitizerInstruction_getDestinationGpr(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_outputsToGprZero(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstruction_blankOut(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isImplemented(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isLikelyHandwritten(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isNop(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isUnconditionalBranch(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isFunctionCall(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isReturn(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isJumptableJump(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_hasDelaySlot(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_sameOpcode(in RabbitizerInstruction self, in RabbitizerInstruction other);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_sameOpcodeButDifferentArguments(in RabbitizerInstruction self, in RabbitizerInstruction other);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_hasOperand(in RabbitizerInstruction self, RabbitizerOperandType operand);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_hasOperandAlias(in RabbitizerInstruction self, RabbitizerOperandType operand);

    [DllImport(LibName)]
    internal static extern uint RabbitizerInstruction_getValidBits(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_isValid(in RabbitizerInstruction self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstruction_mustDisasmAsData(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerOperandType_getBufferSize(RabbitizerOperandType operand, in RabbitizerInstruction instr, nuint immOverrideLength);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerOperandType_disassemble(RabbitizerOperandType operand, in RabbitizerInstruction instr, byte* dst, byte* immOverride, nuint immOverrideLength);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_getSizeForBufferOperandsDisasm(in RabbitizerInstruction self, nuint immOverrideLength);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_disassembleOperands(in RabbitizerInstruction self, byte* dst, byte* immOverride, nuint immOverrideLength);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_getSizeForBufferInstrDisasm(in RabbitizerInstruction self, nuint immOverrideLength, int extraLJust);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_disassembleInstruction(in RabbitizerInstruction self, byte* dst, byte* immOverride, nuint immOverrideLength, int extraLJust);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_getSizeForBufferDataDisasm(in RabbitizerInstruction self, int extraLJust);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_disassembleAsData(in RabbitizerInstruction self, byte* dst, int extraLJust);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_getSizeForBuffer(in RabbitizerInstruction self, nuint immOverrideLength, int extraLJust);

    [DllImport(LibName)]
    internal static extern nuint RabbitizerInstruction_disassemble(in RabbitizerInstruction self, byte* dst, byte* immOverride, nuint immOverrideLength, int extraLJust);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_hasSpecificOperand(in RabbitizerInstrDescriptor self, RabbitizerOperandType operand);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_hasOperandAlias(in RabbitizerInstrDescriptor self, RabbitizerOperandType operand);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isUnknownType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isJType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isIType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isRType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isRegimmType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    internal static extern RabbitizerInstrSuffix RabbitizerInstrDescriptor_instrSuffix(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isBranch(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isBranchLikely(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isJump(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isJumpWithAddress(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isTrap(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isFloat(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isDouble(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isUnsigned(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesRs(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesRt(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesRd(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsRs(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsRt(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsRd(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsHI(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsLO(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesHI(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesLO(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesFs(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesFt(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_modifiesFd(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsFs(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsFt(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_readsFd(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_notEmittedByCompilers(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_canBeHi(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_canBeLo(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_doesLink(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_doesDereference(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_doesLoad(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_doesStore(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_maybeIsMove(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_isPseudo(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    internal static extern RabbitizerAccessType RabbitizerInstrDescriptor_getAccessType(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerInstrDescriptor_doesUnsignedMemoryAccess(in RabbitizerInstrDescriptor self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_init(ref RabbitizerTrackedRegisterState self, int registerNum);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_destroy(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_clear(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_clearHi(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_clearGp(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_clearLo(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_clearBranch(ref RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_copyState(ref RabbitizerTrackedRegisterState self, in RabbitizerTrackedRegisterState other);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_setHi(ref RabbitizerTrackedRegisterState self, uint value, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_setGpLoad(ref RabbitizerTrackedRegisterState self, uint value, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_setLo(ref RabbitizerTrackedRegisterState self, uint value, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_setBranching(ref RabbitizerTrackedRegisterState self, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_deref(ref RabbitizerTrackedRegisterState self, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerTrackedRegisterState_dereferenceState(ref RabbitizerTrackedRegisterState self, in RabbitizerTrackedRegisterState other, int offset);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerTrackedRegisterState_hasAnyValue(in RabbitizerTrackedRegisterState self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerTrackedRegisterState_wasSetInCurrentOffset(in RabbitizerTrackedRegisterState self, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerLoPairingInfo_Init(ref RabbitizerLoPairingInfo self);

    [DllImport(LibName)]
    internal static extern void RabbitizerJrRegData_init(ref RabbitizerJrRegData self);

    [DllImport(LibName)]
    internal static extern void RabbitizerJrRegData_copy(ref RabbitizerJrRegData self, in RabbitizerJrRegData other);

    [DllImport(LibName)]
    internal static extern void RabbitizerJrRegData_initFromRegisterState(ref RabbitizerJrRegData self, in RabbitizerTrackedRegisterState state);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_init(ref RabbitizerRegistersTracker self, RabbitizerRegistersTracker* other);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_destroy(ref RabbitizerRegistersTracker self);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerRegistersTracker_moveRegisters(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_overwriteRegisters(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_unsetRegistersAfterFuncCall(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, in RabbitizerInstruction prevInstr);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerRegistersTracker_getAddressIfCanSetType(in RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset, out uint dstAddress);

    [DllImport(LibName)]
    internal static extern RabbitizerJrRegData RabbitizerRegistersTracker_getJrRegData(in RabbitizerRegistersTracker self, in RabbitizerInstruction instr);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_processLui(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset, RabbitizerInstruction* prevInstr);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_processGpLoad(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerRegistersTracker_getLuiOffsetForConstant(in RabbitizerRegistersTracker self, in RabbitizerInstruction instr, out int dstOffset);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_processConstant(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, uint value, int offset);

    [DllImport(LibName)]
    internal static extern RabbitizerLoPairingInfo RabbitizerRegistersTracker_preprocessLoAndGetInfo(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_processLo(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, uint value, int offset);

    [DllImport(LibName)]
    internal static extern void RabbitizerRegistersTracker_processBranch(ref RabbitizerRegistersTracker self, in RabbitizerInstruction instr, int instrOffset);

    [DllImport(LibName)]
    [return: MarshalAs(UnmanagedType.U1)]
    internal static extern bool RabbitizerRegistersTracker_hasLoButNoHi(in RabbitizerRegistersTracker self, in RabbitizerInstruction instr);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionRsp_init(ref RabbitizerInstruction self, uint word, uint vram);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionRsp_destroy(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionRsp_processUniqueId(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern ushort RabbitizerInstructionRsp_GetOffsetVector(in RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR3000GTE_init(ref RabbitizerInstruction self, uint word, uint vram);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR3000GTE_destroy(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR3000GTE_processUniqueId(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR4000Allegrex_init(ref RabbitizerInstruction self, uint word, uint vram);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR4000Allegrex_destroy(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR4000Allegrex_processUniqueId(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR5900_init(ref RabbitizerInstruction self, uint word, uint vram);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR5900_destroy(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern void RabbitizerInstructionR5900_processUniqueId(ref RabbitizerInstruction self);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameGpr(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameCop0(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameCop1(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameCop2(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameRspGpr(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameRspCop0(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameRspCop2(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameR5900VF(byte regValue);

    [DllImport(LibName)]
    internal static extern IntPtr RabbitizerRegister_getNameR5900VI(byte regValue);
}
