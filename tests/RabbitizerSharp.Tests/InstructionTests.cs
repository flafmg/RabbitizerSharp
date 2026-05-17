using RabbitizerSharp;
using RabbitizerSharp.Native;

namespace RabbitizerSharp.Tests;

public class InstructionTests
{
    private static string Disasm(uint word, string? imm = null, RabbitizerInstrCategory category = RabbitizerInstrCategory.Cpu)
    {
        RabbitizerConfig.GnuMode = true;
        using var instr = new Instruction(word, 0, category);
        return instr.Disassemble(imm, 0);
    }

    //tests bassed on the original c tests
    
    //plain_disassembly.c
    [Fact] public void Cpu_lui_t0_0x8001() => Assert.Equal("lui         $t0, 0x8001", Disasm(0x3C088001));
    [Fact] public void Cpu_addiu_t0_t0_0xE60() => Assert.Equal("addiu       $t0, $t0, 0xE60", Disasm(0x25080E60));
    [Fact] public void Cpu_lui_t1_0x2() => Assert.Equal("lui         $t1, 0x2", Disasm(0x3C090002));
    [Fact] public void Cpu_addiu_t1_t1_neg() => Assert.Equal("addiu       $t1, $t1, -0x7220", Disasm(0x25298DE0));
    [Fact] public void Cpu_sw_zero_0x0_t0() => Assert.Equal("sw          $zero, 0x0($t0)", Disasm(0xAD000000));
    [Fact] public void Cpu_sw_zero_0x4_t0() => Assert.Equal("sw          $zero, 0x4($t0)", Disasm(0xAD000004));
    [Fact] public void Cpu_addi_t0_t0_8() => Assert.Equal("addi        $t0, $t0, 0x8", Disasm(0x21080008));
    [Fact] public void Cpu_addi_t1_t1_neg8() => Assert.Equal("addi        $t1, $t1, -0x8", Disasm(0x2129FFF8));
    [Fact] public void Cpu_bnez_t1() => Assert.Equal("bnez        $t1, . + 4 + (-0x5 << 2)", Disasm(0x1520FFFB));
    [Fact] public void Cpu_nop() => Assert.Equal("nop", Disasm(0x00000000));
    [Fact] public void Cpu_jr_t2() => Assert.Equal("jr          $t2", Disasm(0x01400008));
    [Fact] public void Cpu_lui_at_0x8001() => Assert.Equal("lui         $at, 0x8001", Disasm(0x3C018001));
    [Fact] public void Cpu_jr_ra() => Assert.Equal("jr          $ra", Disasm(0x03E00008));
    [Fact] public void Cpu_sw_a0_neg_0x1E70() => Assert.Equal("sw          $a0, -0x1E70($at)", Disasm(0xAC24E190));
    [Fact] public void Cpu_lui_at_hi_sym() => Assert.Equal("lui         $at, %hi(D_8000E190)", Disasm(0x3C018001, "%hi(D_8000E190)"));
    [Fact] public void Cpu_sw_a0_lo_sym() => Assert.Equal("sw          $a0, %lo(D_8000E190)($at)", Disasm(0xAC24E190, "%lo(D_8000E190)"));
    [Fact] public void Cpu_jal_func() => Assert.Equal("jal         func_80007C90", Disasm(0x0C001F24));
    [Fact] public void Cpu_jal_named_func() => Assert.Equal("jal         some_func", Disasm(0x0C001F24, "some_func"));
    [Fact] public void Cpu_lw_t9_gp_neg() => Assert.Equal("lw          $t9, -0x7FA4($gp)", Disasm(0x8F99805C));
    [Fact] public void Cpu_lw_t9_call16() => Assert.Equal("lw          $t9, %call16(strcmp)($gp)", Disasm(0x8F99805C, "%call16(strcmp)"));
    [Fact] public void Cpu_lw_a1_got() => Assert.Equal("lw          $a1, %got(STR_10007C90)($gp)", Disasm(0x8F858028, "%got(STR_10007C90)"));
    [Fact] public void Cpu_sub_t2_v0_v1() => Assert.Equal("sub         $t2, $v0, $v1", Disasm(0x00435022));
    [Fact] public void Cpu_neg_t2_v0() => Assert.Equal("neg         $t2, $v0", Disasm(0x00025022));
    [Fact] public void Cpu_subu_v1_a3_a0() => Assert.Equal("subu        $v1, $a3, $a0", Disasm(0x00E41823));
    [Fact] public void Cpu_negu_v1_a0() => Assert.Equal("negu        $v1, $a0", Disasm(0x00041823));
    [Fact] public void Cpu_rfe() => Assert.Equal("rfe", Disasm(0x42000010));

    //r3000gte_disasm.c
    [Fact] public void Gte_rtps() => Assert.Equal("rtps", Disasm(0x4A180001, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_rtpt() => Assert.Equal("rtpt", Disasm(0x4A280030, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_dpcl() => Assert.Equal("dpcl", Disasm(0x4A680029, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_dpcs() => Assert.Equal("dpcs", Disasm(0x4A780010, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_dpct() => Assert.Equal("dpct", Disasm(0x4AF8002A, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_intpl() => Assert.Equal("intpl", Disasm(0x4A980011, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_ncs() => Assert.Equal("ncs", Disasm(0x4AC8041E, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_nct() => Assert.Equal("nct", Disasm(0x4AD80420, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_ncds() => Assert.Equal("ncds", Disasm(0x4AE80413, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_ncdt() => Assert.Equal("ncdt", Disasm(0x4AF80416, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_nccs() => Assert.Equal("nccs", Disasm(0x4B08041B, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_ncct() => Assert.Equal("ncct", Disasm(0x4B18043F, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_cdp() => Assert.Equal("cdp", Disasm(0x4B280414, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_cc() => Assert.Equal("cc", Disasm(0x4B38041C, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_nclip() => Assert.Equal("nclip", Disasm(0x4B400006, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_avsz3() => Assert.Equal("avsz3", Disasm(0x4B58002D, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_avsz4() => Assert.Equal("avsz4", Disasm(0x4B68002E, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_mvmva_0_0_0_0_0() => Assert.Equal("mvmva       0, 0, 0, 0, 0", Disasm(0x4A400012, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_sqr_0() => Assert.Equal("sqr         0", Disasm(0x4AA00428, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_op_0() => Assert.Equal("op          0", Disasm(0x4B70000C, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_gpf_0() => Assert.Equal("gpf         0", Disasm(0x4B90003D, category: RabbitizerInstrCategory.R3000Gte));
    [Fact] public void Gte_gpl_0() => Assert.Equal("gpl         0", Disasm(0x4BA0003E, category: RabbitizerInstrCategory.R3000Gte));

    //r5900_disasm.c
    [Fact] public void R5900_vcallms_0() => Assert.Equal("vcallms     0x0", Disasm(0x4A000038, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vcallms_800() => Assert.Equal("vcallms     0x800", Disasm(0x4A004038, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vcallms_FFF8() => Assert.Equal("vcallms     0xFFF8", Disasm(0x4A07FFF8, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmfhl_lw() => Assert.Equal("pmfhl.lw    $v0", Disasm(0x70001030, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmfhl_uw() => Assert.Equal("pmfhl.uw    $v0", Disasm(0x70001070, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmfhl_slw() => Assert.Equal("pmfhl.slw   $v0", Disasm(0x700010B0, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmfhl_lh() => Assert.Equal("pmfhl.lh    $v0", Disasm(0x700010F0, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmfhl_sh() => Assert.Equal("pmfhl.sh    $v0", Disasm(0x70001130, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_pmthl_lw() => Assert.Equal("pmthl.lw    $zero", Disasm(0x70000031, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vilwr_x() => Assert.Equal("vilwr.x     $vi2, ($vi1)", Disasm(0x4B020BFE, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vilwr_y() => Assert.Equal("vilwr.y     $vi2, ($vi1)", Disasm(0x4A820BFE, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vilwr_z() => Assert.Equal("vilwr.z     $vi2, ($vi1)", Disasm(0x4A420BFE, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_vilwr_w() => Assert.Equal("vilwr.w     $vi2, ($vi1)", Disasm(0x4A220BFE, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_viaddi() => Assert.Equal("viaddi      $vi3, $vi0, -0x2", Disasm(0x4A0307B2, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_cfc2_ni() => Assert.Equal("cfc2.ni     $s0, $vi1", Disasm(0x48500800, category: RabbitizerInstrCategory.R5900));
    [Fact] public void R5900_cfc2_i() => Assert.Equal("cfc2.i      $s0, $vi1", Disasm(0x48500801, category: RabbitizerInstrCategory.R5900));

    //Smoke tests
    [Fact]
    public void Constructor_DoesNotThrow()
    {
        using var instr = new Instruction(0x00000000);
        Assert.NotNull(instr);
    }

    [Fact]
    public void Disassemble_ReturnsNonEmpty()
    {
        using var instr = new Instruction(0x00000000);
        Assert.False(string.IsNullOrEmpty(instr.Disassemble()));
    }

    [Fact]
    public void IsNop_TrueForZeroWord()
    {
        using var instr = new Instruction(0x00000000);
        Assert.True(instr.IsNop);
    }

    [Fact]
    public void IsReturn_TrueForJrRa()
    {
        using var instr = new Instruction(0x03E00008);
        Assert.True(instr.IsReturn);
    }

    [Fact]
    public void IsFunctionCall_TrueForJal()
    {
        using var instr = new Instruction(0x0C001F24);
        Assert.True(instr.IsFunctionCall);
    }
}
