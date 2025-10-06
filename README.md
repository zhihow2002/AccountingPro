# AccountingPro - Comprehensive Accounting System

A full-featured accounting system built with C# .NET 8, implementing Clean Architecture principles and double-entry bookkeeping.

## 🏗️ Architecture

- **Clean Architecture** with CQRS pattern using MediatR
- **Domain-Driven Design** principles
- **Entity Framework Core** with SQL Server
- **ASP.NET Core 8** Web API
- **Blazor Server** for web UI
- **AutoMapper** for object mapping
- **FluentValidation** for input validation
- **xUnit** for testing

## 📋 Features

### Core Accounting Features
- ✅ **Double-Entry Bookkeeping** - All transactions must balance
- ✅ **Chart of Accounts** - Hierarchical account structure
- ✅ **Journal Entries** - Create, approve, and reverse entries
- ✅ **General Ledger** - Complete transaction history
- ✅ **Financial Reports** - Balance Sheet, Income Statement
- ✅ **Multi-Company Support** - Separate books for multiple entities
- ✅ **Fiscal Year Management** - Period-based accounting
- ✅ **Audit Trails** - Complete change tracking

### Business Rules
- Debits must equal credits in every journal entry
- Account codes must be unique within a company
- Cannot delete accounts with existing transactions
- Journal entries require approval workflow
- Period-end closing restrictions

## 🚀 Project Structure

```
AccountingPro/
├── src/
│   ├── AccountingPro.Core/           # Domain layer (entities, enums)
│   ├── AccountingPro.Application/    # Application layer (DTOs, CQRS)
│   ├── AccountingPro.Infrastructure/ # Data access & external services
│   ├── AccountingPro.Api/           # Web API
│   └── AccountingPro.Web/           # Blazor Server UI
├── tests/
│   ├── AccountingPro.UnitTests/     # Unit tests
│   └── AccountingPro.IntegrationTests/ # Integration tests
├── sql/
│   └── schema.sql                   # Database schema
└── docs/                            # Documentation
```

## 🛠️ Prerequisites

- **.NET 8 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (LocalDB, Express, or full version)
- **Visual Studio 2022** or **VS Code** (recommended)

### SQL Server Options:
1. **SQL Server LocalDB** (easiest for development)
2. **SQL Server Express** (free, more features)
3. **Docker** (if you prefer containers)

## ⚡ Quick Start

### 1. Clone and Setup
```bash
git clone <your-repo-url>
cd AccountingPro
dotnet restore
```

### 2. Database Setup
The application uses SQL Server LocalDB by default. The database will be created automatically on first run.

**Connection String** (in `appsettings.json`):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AccountingProDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Run the API
```bash
cd src/AccountingPro.Api
dotnet run
```
The API will be available at: `https://localhost:7000` and `http://localhost:5000`

### 4. Run the Web UI
```bash
cd src/AccountingPro.Web
dotnet run
```
The Blazor app will be available at: `https://localhost:7001` and `http://localhost:5001`

### 5. Explore the API
Visit `https://localhost:7000/swagger` to explore the API documentation.

## 📊 Sample Data

The system includes seed data:
- **Sample Company Ltd.** - Demo company
- **Chart of Accounts** - Standard accounting structure:
  - Assets (Cash, Accounts Receivable, Inventory)
  - Liabilities (Accounts Payable, Bank Loan)
  - Equity (Owner's Equity)
  - Revenue (Sales Revenue)
  - Expenses (COGS, Rent, Utilities)

## 🔗 API Endpoints

### Journal Entries
- `GET /api/journalentries` - List journal entries
- `GET /api/journalentries/{id}` - Get specific entry
- `POST /api/journalentries` - Create new entry
- `POST /api/journalentries/{id}/approve` - Approve entry

### Accounts
- `GET /api/accounts` - List chart of accounts

### Reports
- `GET /api/reports/balance-sheet` - Balance Sheet report
- `GET /api/reports/income-statement` - Income Statement report

## 💼 Sample API Usage

### Create a Journal Entry
```json
POST /api/journalentries
{
  "entryDate": "2024-10-06",
  "description": "Sale of goods to customer",
  "reference": "INV-001",
  "companyId": 1,
  "lines": [
    {
      "accountId": 1,
      "description": "Cash received",
      "debitAmount": 1000,
      "creditAmount": 0
    },
    {
      "accountId": 7,
      "description": "Sales revenue",
      "debitAmount": 0,
      "creditAmount": 1000
    }
  ]
}
```

### Get Balance Sheet
```
GET /api/reports/balance-sheet?companyId=1&asOfDate=2024-10-06
```

## 🧪 Testing

### Run Unit Tests
```bash
cd tests/AccountingPro.UnitTests
dotnet test
```

### Run Integration Tests
```bash
cd tests/AccountingPro.IntegrationTests
dotnet test
```

### Run All Tests
```bash
dotnet test
```

## 🗄️ Database Schema

Key entities and relationships:

```sql
-- Core entities
Company (1) ──→ (∞) Account
Company (1) ──→ (∞) JournalEntry
Company (1) ──→ (∞) FiscalYear

-- Hierarchical accounts
Account (1) ──→ (∞) Account (parent-child)

-- Journal entry lines
JournalEntry (1) ──→ (∞) JournalEntryLine
Account (1) ──→ (∞) JournalEntryLine

-- Fiscal periods
FiscalYear (1) ──→ (∞) AccountingPeriod
```

## 🔧 Configuration

### Environment Variables
- `ConnectionStrings__DefaultConnection` - Database connection string
- `ASPNETCORE_ENVIRONMENT` - Environment (Development/Production)

### Application Settings
- **API**: `src/AccountingPro.Api/appsettings.json`
- **Web**: `src/AccountingPro.Web/appsettings.json`

## 🚢 Deployment

### Docker Support (Optional)
```dockerfile
# Add to src/AccountingPro.Api/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountingPro.Api.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

- **Issues**: [GitHub Issues](https://github.com/your-username/AccountingPro/issues)
- **Discussions**: [GitHub Discussions](https://github.com/your-username/AccountingPro/discussions)

## 🎯 Roadmap

- [ ] Advanced reporting (Cash Flow Statement, Trial Balance)
- [ ] Multi-currency support
- [ ] Tax calculation and reporting
- [ ] Budget management
- [ ] Accounts payable/receivable aging
- [ ] Bank reconciliation
- [ ] Asset management
- [ ] User roles and permissions
- [ ] REST API documentation with OpenAPI
- [ ] Mobile app support

---

## 📞 Getting Help

If you encounter issues:

1. **Check the logs** in the console output
2. **Verify SQL Server** is running and accessible
3. **Check connection strings** in appsettings.json
4. **Run database migrations** if needed
5. **Clear browser cache** for UI issues

**Built with ❤️ using .NET 8 and Clean Architecture principles**