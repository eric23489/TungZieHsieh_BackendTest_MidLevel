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

### 1. 建立資料庫

在 SSMS 依序執行：

1. `TSQLScript/TSQL_Myoffice_ACPD.sql` — 建立資料表
2. `TSQLScript/NewSID_自訂一組固定欄位的代碼.sql` — 建立主鍵 SP
3. `TSQLScript/CRUD_StoredProcedures.sql` — 建立 CRUD SP

### 2. 設定連線字串

修改 `appsettings.json`：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=Myoffice_ACPD;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. 啟動專案

以 Visual Studio 2022 開啟，按 **F5** 即可啟動，瀏覽器自動開啟 Swagger UI。
