# BankAppliaction

Clone application from Github: https://github.com/vAdamski/BankAppliaction.git

## Configure application before first run
1. Change database connection string:

a. In project folder open configuration file Bank.Api -> appsettings.json

b. "ConnectionStrings": {"BankDatabase": "---=== Here paste your MSSQL connection string ===---"}

2. Update your database and seed data (Package Manager Console or CLI)

a. Package Manager Console

I. Update-Database
        
b. CLI

I. Open CLI in projectFolder -> BankApplication.Persistance
       
II. dotnet ef database update

3. Start application

## Initial database:

CashMachine:

CashMachineId = 1

Banknote:

200 -> 5

100 -> 5

50 -> 5

20  -> 5

10 -> 5

User account:

AccountBalance: 7654.00

AccountNumber: 3019075149919263436240

## Endpoint

Patch: /api/cashMachine

Example Value

{

  "cashMachineNumber": 1,
  
  "accountNumber": "3019075149919263436240",
  
  "amountOfCashout": 1580
  
}

Output [200,200,200,200,200,100,100,100,100,100,50,20,10]
