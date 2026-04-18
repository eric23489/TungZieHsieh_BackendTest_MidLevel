# TungZieHsieh_BackendTest_MidLevel

後端工程師技術測試 — 謝東澤（TungZie Hsieh）

## 專案架構

```
TungZieHsieh_BackendTest_MiLevel/
├── Controllers/
│   └── MyOfficeAcpdController.cs   # API 端點
├── Models/
│   └── MyOfficeAcpd.cs             # Model + DTO
├── Repositories/
│   ├── IMyOfficeAcpdRepository.cs  # 介面
│   └── MyOfficeAcpdRepository.cs   # Dapper 呼叫 SP
├── Program.cs                       # DI 註冊、Swagger 設定
└── appsettings.json                 # 連線字串設定
TSQLScript/
├── TSQL_Myoffice_ACPD.sql          # 資料表建立腳本
├── NewSID_自訂一組固定欄位的代碼.sql  # 主鍵產生 SP
└── CRUD_StoredProcedures.sql       # CRUD SP
Myoffice_ACPD.bak                   # 資料庫備份檔（含測試資料）
```

## 技術使用

- .NET Core 8 Web API
- Dapper
- SQL Server（資料庫：Myoffice_ACPD）
- Swashbuckle（Swagger UI）

## API 端點

| Method | URL | 說明 | 回傳 |
|--------|-----|------|------|
| GET | /api/myofficeacpd | 查詢全部 | 200 |
| GET | /api/myofficeacpd/{id} | 查詢單筆 | 200 / 404 |
| POST | /api/myofficeacpd | 新增 | 201 |
| PUT | /api/myofficeacpd/{id} | 更新 | 204 / 404 |
| DELETE | /api/myofficeacpd/{id} | 刪除 | 204 / 404 |

## 執行步驟

### 方式 A：還原資料庫備份（建議）

1. 開啟 SSMS，還原 `Myoffice_ACPD.bak`：
   - 右鍵「資料庫」→「還原資料庫」
   - 選擇「裝置」→ 選取 `Myoffice_ACPD.bak`
   - 點「確定」完成還原（含測試資料與所有 SP）

2. 修改 `appsettings.json` 連線字串：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=你的SERVER名稱;Database=Myoffice_ACPD;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. 以 Visual Studio 2022 開啟方案，按 **F5** 啟動，瀏覽器自動開啟 Swagger UI。

---

### 方式 B：手動建立資料庫

1. 在 SSMS 建立資料庫 `Myoffice_ACPD`
2. 依序執行以下 SQL Script：
   1. `TSQLScript/TSQL_Myoffice_ACPD.sql` — 建立資料表
   2. `TSQLScript/NewSID_自訂一組固定欄位的代碼.sql` — 建立主鍵產生 SP
   3. `TSQLScript/CRUD_StoredProcedures.sql` — 建立 CRUD SP
3. 修改 `appsettings.json` 連線字串（同上）
4. 以 Visual Studio 2022 開啟方案，按 **F5** 啟動
