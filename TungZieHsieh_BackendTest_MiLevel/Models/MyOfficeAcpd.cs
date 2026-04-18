using System.ComponentModel.DataAnnotations;

namespace TungZieHsieh_BackendTest_MiLevel.Models;

public class MyOfficeAcpd
{
    public string ACPD_SID { get; set; } = string.Empty;
    public string? ACPD_Cname { get; set; }
    public string? ACPD_Ename { get; set; }
    public string? ACPD_Sname { get; set; }
    public string? ACPD_Email { get; set; }
    public byte ACPD_Status { get; set; }
    public bool ACPD_Stop { get; set; }
    public string? ACPD_StopMemo { get; set; }
    public string? ACPD_LoginID { get; set; }
    public string? ACPD_LoginPWD { get; set; }
    public string? ACPD_Memo { get; set; }
    public DateTime? ACPD_NowDateTime { get; set; }
    public string? ACPD_NowID { get; set; }
    public DateTime? ACPD_UPDDateTime { get; set; }
    public string? ACPD_UPDID { get; set; }
}

public class AcpdCreateDto
{
    /// <example>謝東澤</example>
    [StringLength(60)] public string? ACPD_Cname { get; set; }

    /// <example>TungZie Hsieh</example>
    [StringLength(40)] public string? ACPD_Ename { get; set; }

    /// <example>東澤</example>
    [StringLength(40)] public string? ACPD_Sname { get; set; }

    /// <example>eric23489@gmail.com</example>
    [StringLength(60), EmailAddress] public string? ACPD_Email { get; set; }

    /// <example>1</example>
    public byte ACPD_Status { get; set; } = 0;

    /// <example>tungzie</example>
    [StringLength(30)] public string? ACPD_LoginID { get; set; }

    /// <example>Test1234</example>
    [StringLength(60)] public string? ACPD_LoginPWD { get; set; }

    /// <example>系統管理員</example>
    [StringLength(600)] public string? ACPD_Memo { get; set; }

    /// <example>SYSTEM</example>
    [StringLength(20)] public string? ACPD_NowID { get; set; }
}

public class AcpdUpdateDto
{
    /// <example>謝東澤（更新）</example>
    [StringLength(60)] public string? ACPD_Cname { get; set; }

    /// <example>TungZie Hsieh</example>
    [StringLength(40)] public string? ACPD_Ename { get; set; }

    /// <example>東澤</example>
    [StringLength(40)] public string? ACPD_Sname { get; set; }

    /// <example>eric23489@gmail.com</example>
    [StringLength(60), EmailAddress] public string? ACPD_Email { get; set; }

    /// <example>1</example>
    public byte ACPD_Status { get; set; }

    /// <example>false</example>
    public bool ACPD_Stop { get; set; }

    /// <example></example>
    [StringLength(60)] public string? ACPD_StopMemo { get; set; }

    /// <example>tungzie</example>
    [StringLength(30)] public string? ACPD_LoginID { get; set; }

    /// <example>NewPass1234</example>
    [StringLength(60)] public string? ACPD_LoginPWD { get; set; }

    /// <example>更新備註</example>
    [StringLength(600)] public string? ACPD_Memo { get; set; }

    /// <example>SYSTEM</example>
    [StringLength(20)] public string? ACPD_UPDID { get; set; }
}
