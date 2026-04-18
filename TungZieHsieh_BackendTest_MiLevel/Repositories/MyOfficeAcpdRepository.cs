using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TungZieHsieh_BackendTest_MiLevel.Models;

namespace TungZieHsieh_BackendTest_MiLevel.Repositories;

public class MyOfficeAcpdRepository : IMyOfficeAcpdRepository
{
    private readonly string _connectionString;

    public MyOfficeAcpdRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")!;
    }

    private SqlConnection CreateConnection() => new(_connectionString);

    public async Task<IEnumerable<MyOfficeAcpd>> GetAllAsync()
    {
        using var conn = CreateConnection();
        return await conn.QueryAsync<MyOfficeAcpd>(
            "sp_GetAllACPD",
            commandType: CommandType.StoredProcedure);
    }

    public async Task<MyOfficeAcpd?> GetByIdAsync(string sid)
    {
        using var conn = CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<MyOfficeAcpd>(
            "sp_GetACPDById",
            new { ACPD_SID = sid },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<string> CreateAsync(AcpdCreateDto dto)
    {
        using var conn = CreateConnection();
        var p = new DynamicParameters();
        p.Add("@ACPD_Cname",    dto.ACPD_Cname);
        p.Add("@ACPD_Ename",    dto.ACPD_Ename);
        p.Add("@ACPD_Sname",    dto.ACPD_Sname);
        p.Add("@ACPD_Email",    dto.ACPD_Email);
        p.Add("@ACPD_Status",   dto.ACPD_Status);
        p.Add("@ACPD_LoginID",  dto.ACPD_LoginID);
        p.Add("@ACPD_LoginPWD", dto.ACPD_LoginPWD);
        p.Add("@ACPD_Memo",     dto.ACPD_Memo);
        p.Add("@ACPD_NowID",    dto.ACPD_NowID);
        p.Add("@NewSID", dbType: DbType.AnsiStringFixedLength, size: 20, direction: ParameterDirection.Output);

        await conn.ExecuteAsync("sp_CreateACPD", p, commandType: CommandType.StoredProcedure);
        return p.Get<string>("@NewSID");
    }

    public async Task<bool> UpdateAsync(string sid, AcpdUpdateDto dto)
    {
        using var conn = CreateConnection();
        var rows = await conn.ExecuteAsync(
            "sp_UpdateACPD",
            new
            {
                ACPD_SID      = sid,
                dto.ACPD_Cname,
                dto.ACPD_Ename,
                dto.ACPD_Sname,
                dto.ACPD_Email,
                dto.ACPD_Status,
                dto.ACPD_Stop,
                dto.ACPD_StopMemo,
                dto.ACPD_LoginID,
                dto.ACPD_LoginPWD,
                dto.ACPD_Memo,
                dto.ACPD_UPDID
            },
            commandType: CommandType.StoredProcedure);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(string sid)
    {
        using var conn = CreateConnection();
        var rows = await conn.ExecuteAsync(
            "sp_DeleteACPD",
            new { ACPD_SID = sid },
            commandType: CommandType.StoredProcedure);
        return rows > 0;
    }
}
