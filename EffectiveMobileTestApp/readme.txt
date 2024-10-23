Для хранения данных используется MsSQL, для поднятия БД в настройках appsetting.json следует вписать свой пароль от пользователя sa. \
После в консоли диспетчера пакетов nuget прописать команду update-database.
Если нет возможности использовать пользователя sa от SQL можно заменить на другю строку подключения так же в appsetting.json:
"DefaultConnection": "Server=localhost;Database=TestAppWebAPI;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;"

Так же для более быстрого заполнения данных был создан отдельный метод Create.