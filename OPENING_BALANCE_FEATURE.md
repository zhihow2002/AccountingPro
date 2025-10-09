# Opening Balance Sheet Feature

## Overview
This feature allows you to input opening balance sheet data and automatically create corresponding accounts in the Chart of Accounts with proper journal entries.

## Implementation Date
October 10, 2025

## Features

### 1. **Balance Sheet Categories**
Based on the standard balance sheet format, the system supports:

#### Fixed Assets
- Equipment
- Furniture & Fixtures
- Vehicles
- Other fixed assets

#### Current Assets
- Cash in Hand
- Cash at Bank
- Deposit - Rental
- Deposit - Electricity
- Deposit - Water
- Stock (Inventory)
- Accounts Receivable

#### Current Liabilities
- Creditor (Accounts Payable)
- Accruals
- Short-term Loans

#### Capital Account
- Owner's Capital
- Retained Earnings
- Profit/Loss for the year
- Less: Drawings

### 2. **Key Functionalities**

#### A. Account Templates
- Pre-defined chart of account codes and names
- Standardized account codes (e.g., 1100-1999 for Assets, 2000-2999 for Liabilities, 3000-3999 for Equity)
- Categorized by balance sheet sections

#### B. Dynamic Entry Management
- Add/remove line items in each category
- Select from predefined account templates
- Enter custom account names if needed
- Input amounts with currency formatting

#### C. Real-Time Calculations
- **Total Fixed Assets**: Sum of all fixed asset entries
- **Total Current Assets**: Sum of all current asset entries
- **Total Current Liabilities**: Sum of all liability entries
- **Net Current Assets/(Liabilities)**: Current Assets - Current Liabilities
- **Total Capital & Reserves**: Sum of capital accounts
- **Net Capital**: Capital & Reserves - Drawings
- **Balance Check**: Validates that Assets = Liabilities + Capital

#### D. Balance Sheet Validation
- Real-time balance checking
- Visual feedback (success/warning messages)
- Prevents submission if balance sheet doesn't balance
- Difference calculation and display

#### E. Journal Entry Creation
The system automatically creates:
- **Journal Entry** with reference "OPENING-BAL"
- **Debit entries** for all assets
- **Credit entries** for all liabilities and capital
- **Debit entry** for drawings (reduces equity)
- Updates account balances automatically

#### F. Integration with Chart of Accounts
- Automatically creates accounts if they don't exist
- Links entries to existing accounts if account code exists
- Updates account balances based on journal entries
- Maintains proper double-entry bookkeeping

### 3. **User Interface**

#### Layout
The page is organized into collapsible sections:
1. **Opening Balance Date** - Set the as-of date for opening balances
2. **Fixed Assets** - Blue header
3. **Current Assets** - Cyan header
4. **Current Liabilities** - Yellow header
5. **Capital Account** - Green header (includes drawings section)
6. **Balance Sheet Summary** - Shows total assets vs. total liabilities & capital
7. **Notes** - Optional notes field

#### Features
- Color-coded sections for easy identification
- Table format with Account Code, Account Name, Amount, and Action columns
- Add/Remove buttons for each section
- Dropdown selection for account templates
- Currency input with $ symbol
- Running totals for each section
- Balance validation indicator

### 4. **Accounting Treatment**

#### Journal Entry Example:
```
Date: 01/01/2024
Reference: OPENING-BAL
Description: Opening Balance Sheet as of 2024-01-01

Debit: Equipment             $10,000
Debit: Cash in Hand           $2,000
Debit: Cash at Bank          $15,000
Debit: Stock                  $5,000
Credit: Creditor                        $3,000
Credit: Owner's Capital                $30,000
Debit: Drawings               $1,000
```

**Net Effect**: 
- Total Debits: $33,000
- Total Credits: $33,000
- Balanced ✓

### 5. **Files Created/Modified**

#### New Files:
1. **BalanceSheetDtos.cs** (`Application/DTOs/`)
   - `BalanceSheetEntryDto` - Individual balance sheet line item
   - `OpeningBalanceSheetDto` - Complete balance sheet data
   - `BalanceSheetAccountTemplateDto` - Account template definition

2. **IBalanceSheetService.cs** (`Application/Services/`)
   - `GetBalanceSheetTemplatesAsync()` - Get predefined account templates
   - `CreateOpeningBalancesAsync()` - Create journal entries for opening balances
   - `GetOpeningBalancesAsync()` - Retrieve existing opening balances

3. **BalanceSheetService.cs** (`Infrastructure/Services/`)
   - Implementation of IBalanceSheetService
   - Account template generation
   - Journal entry creation logic
   - Account auto-creation
   - Balance calculation

4. **OpeningBalanceSheet.razor** (`Web/Components/Pages/`)
   - User interface for balance sheet data entry
   - Real-time validation and calculations
   - Dynamic row management
   - Form submission handling

#### Modified Files:
1. **Program.cs** - Registered `IBalanceSheetService`
2. **NavMenu.razor** - Added "Opening Balance" menu item under Accounting section

### 6. **Navigation**

Access the feature from:
- **Main Menu** → Accounting → Opening Balance
- **Direct URL**: `/accounting/opening-balance`

### 7. **Usage Workflow**

1. **Navigate** to Accounting → Opening Balance
2. **Set Date**: Choose the opening balance date (typically start of fiscal year)
3. **Add Fixed Assets**:
   - Click "Add Fixed Asset"
   - Select account from dropdown or enter custom
   - Enter amount
   - Repeat for each fixed asset

4. **Add Current Assets**:
   - Click "Add Current Asset"
   - Select account (Cash in Hand, Bank, Deposits, Stock, etc.)
   - Enter amounts
   
5. **Add Current Liabilities**:
   - Click "Add Current Liability"
   - Select account (Creditor, Accruals, etc.)
   - Enter amounts

6. **Add Capital Account**:
   - Click "Add Capital Account"
   - Select account (Owner's Capital, Retained Earnings, etc.)
   - Enter amounts
   - Enter Drawings amount if applicable

7. **Review Summary**:
   - Check "Balance Sheet Summary" section
   - Ensure green "Balance Sheet is balanced!" message appears
   - If red warning appears, adjust amounts to balance

8. **Add Notes** (optional):
   - Add any additional notes or comments

9. **Save**:
   - Click "Save Opening Balances"
   - System creates journal entry and accounts
   - Redirects to Chart of Accounts

### 8. **Account Code Structure**

| Range      | Category           | Examples                    |
|------------|--------------------|-----------------------------|
| 1100-1199  | Fixed Assets       | Equipment, Furniture        |
| 1200-1299  | Current Assets     | Cash, Bank, Deposits        |
| 2100-2199  | Current Liabilities| Creditor, Accruals          |
| 3000-3099  | Capital            | Owner's Capital             |
| 3100-3199  | Retained Earnings  | Accumulated Profits/Losses  |
| 3200-3299  | Drawings           | Owner's Withdrawals         |

### 9. **Database Impact**

When saving opening balances, the system:
1. Creates a `JournalEntry` record with reference "OPENING-BAL"
2. Creates `JournalEntryLine` records for each balance sheet item
3. Creates `Account` records if they don't exist
4. Updates `Account.Balance` for each account
5. All operations are wrapped in a database transaction

### 10. **Error Handling**

The system handles:
- Missing company selection
- Unbalanced balance sheet
- Database connection issues
- Invalid amounts
- Duplicate account codes

Error messages are displayed at the top of the page in red alert boxes.

### 11. **Future Enhancements**

Potential improvements:
- Import from Excel/CSV
- Balance sheet templates for different business types
- Comparative balance sheet view
- Export to PDF
- Multi-currency support
- Period-end adjustment journal entries
- Balance sheet reporting

### 12. **Technical Notes**

- Uses Entity Framework Core transactions for data integrity
- Implements double-entry bookkeeping automatically
- Supports decimal amounts with 2 decimal places
- Real-time UI updates using Blazor data binding
- Responsive design for mobile/tablet devices

## Testing Checklist

- [ ] Can access Opening Balance page
- [ ] Account templates load correctly
- [ ] Can add/remove items in each section
- [ ] Dropdown selections populate account details
- [ ] Amount calculations update in real-time
- [ ] Balance validation works correctly
- [ ] Can save balanced balance sheet
- [ ] Cannot save unbalanced balance sheet
- [ ] Journal entry is created with correct debits/credits
- [ ] Accounts are created in Chart of Accounts
- [ ] Account balances are updated correctly
- [ ] Can view created opening balance
- [ ] Error handling displays appropriate messages

## Support

For issues or questions, refer to the IMPLEMENTATION_STATUS.md file or contact the development team.
