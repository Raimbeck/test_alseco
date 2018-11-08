# test_alseco
Для запуска проекта локально:
1. Скачайте zip.
2. Visual Studio Code/Visual Studio: в директории test_alseco-master/API откройте API.csproj.
3. В appsettings.json поменяйте секцию "ConnectionStrings" => "Local" под свои параметры.
4. Visual Studio: запустите проект, включены автоматические миграции, таблицы с данными должны создаться автоматически.
   Visual Studio Code: в dotnet cli наберите команду dotnet run/dotnet watch run, включены автоматические миграции, таблицы с данными должны создаться автоматически.
5. По адресу https://localhost:{port}/swagger подключен swagger для тестирования api.
6. Клиент angular производит http запросы на адрес https://localhost:5001, если проект запущен через Visual Studio порт будет другим. В этом случае необходимо либо поменять порт в Visual Studio на 5001, либо в SPA/src/app/services/employee.service.ts поменять порт url на тот что использует Visual Studio.
7. Для запуска самого клиента необходимо набрать команды npm install, потом ng serve.
