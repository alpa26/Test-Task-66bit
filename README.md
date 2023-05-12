# Test-Task-66bit
База данных: PostgreSQL  
Подключение к существующей пустой базе данных происходит через appsettings.json c помощью строк:  
 ' "ConnectionStrings": {  
    "PostgresConnection": "Server=localhost;Port=5432;Database=<Database>;User Id=<user>;Password=<password>;"  
  },'  
Затем в Консоли диспетчера пакетов создаем  миграции с помощью команды `Add-Migration <MigrationName>`  
И применяем миграции  с помощью команды `Update-Database`  
  

  
Платформа .NET 6.0  
  
![image](https://github.com/panovalex777/Test-Task-66bit/assets/90685778/cd0d6927-4791-4f83-ad88-0fd7bdfda604)

![image](https://github.com/panovalex777/Test-Task-66bit/assets/90685778/c9db9940-338b-4f84-8882-8aaeb91604ce)
