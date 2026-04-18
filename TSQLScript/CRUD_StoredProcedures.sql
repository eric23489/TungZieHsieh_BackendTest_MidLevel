USE Myoffice_ACPD;
GO

-- 查詢全部
CREATE OR ALTER PROCEDURE sp_GetAllACPD
AS
BEGIN
    SELECT * FROM MyOffice_ACPD ORDER BY ACPD_NowDateTime DESC;
END
GO

-- 查詢單筆
CREATE OR ALTER PROCEDURE sp_GetACPDById
    @ACPD_SID CHAR(20)
AS
BEGIN
    SELECT * FROM MyOffice_ACPD WHERE ACPD_SID = @ACPD_SID;
END
GO

-- 新增（呼叫 NEWSID 產生主鍵）
CREATE OR ALTER PROCEDURE sp_CreateACPD
    @ACPD_Cname    NVARCHAR(60),
    @ACPD_Ename    NVARCHAR(40),
    @ACPD_Sname    NVARCHAR(40),
    @ACPD_Email    NVARCHAR(60),
    @ACPD_Status   TINYINT,
    @ACPD_LoginID  NVARCHAR(30),
    @ACPD_LoginPWD NVARCHAR(60),
    @ACPD_Memo     NVARCHAR(600),
    @ACPD_NowID    NVARCHAR(20),
    @NewSID        CHAR(20) OUTPUT
AS
BEGIN
    EXEC NEWSID 'MyOffice_ACPD', @NewSID OUTPUT;

    INSERT INTO MyOffice_ACPD (
        ACPD_SID, ACPD_Cname, ACPD_Ename, ACPD_Sname,
        ACPD_Email, ACPD_Status, ACPD_LoginID, ACPD_LoginPWD,
        ACPD_Memo, ACPD_NowID, ACPD_UPDID
    )
    VALUES (
        @NewSID, @ACPD_Cname, @ACPD_Ename, @ACPD_Sname,
        @ACPD_Email, @ACPD_Status, @ACPD_LoginID, @ACPD_LoginPWD,
        @ACPD_Memo, @ACPD_NowID, @ACPD_NowID
    );
END
GO

-- 更新
CREATE OR ALTER PROCEDURE sp_UpdateACPD
    @ACPD_SID      CHAR(20),
    @ACPD_Cname    NVARCHAR(60),
    @ACPD_Ename    NVARCHAR(40),
    @ACPD_Sname    NVARCHAR(40),
    @ACPD_Email    NVARCHAR(60),
    @ACPD_Status   TINYINT,
    @ACPD_Stop     BIT,
    @ACPD_StopMemo NVARCHAR(60),
    @ACPD_LoginID  NVARCHAR(30),
    @ACPD_LoginPWD NVARCHAR(60),
    @ACPD_Memo     NVARCHAR(600),
    @ACPD_UPDID    NVARCHAR(20)
AS
BEGIN
    UPDATE MyOffice_ACPD SET
        ACPD_Cname       = @ACPD_Cname,
        ACPD_Ename       = @ACPD_Ename,
        ACPD_Sname       = @ACPD_Sname,
        ACPD_Email       = @ACPD_Email,
        ACPD_Status      = @ACPD_Status,
        ACPD_Stop        = @ACPD_Stop,
        ACPD_StopMemo    = @ACPD_StopMemo,
        ACPD_LoginID     = @ACPD_LoginID,
        ACPD_LoginPWD    = @ACPD_LoginPWD,
        ACPD_Memo        = @ACPD_Memo,
        ACPD_UPDDateTime = GETDATE(),
        ACPD_UPDID       = @ACPD_UPDID
    WHERE ACPD_SID = @ACPD_SID;
END
GO

-- 刪除
CREATE OR ALTER PROCEDURE sp_DeleteACPD
    @ACPD_SID CHAR(20)
AS
BEGIN
    DELETE FROM MyOffice_ACPD WHERE ACPD_SID = @ACPD_SID;
END
GO
