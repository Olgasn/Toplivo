# Toplivo
Проект MS Visual Studio 2015 содержит простой пример MVC 5 ASP.NET приложения. Может быть полезен для выполнения соответствующей лабораторной работы и курсового проекта по дисциплине "Разработка приложений баз данных для информационных систем" для студентов специальности "Информационные системы и технологии".

Внутри проекта содержится T-SQL скрипт для создания базы данных toplivo СУБД MS SQL Server, к которой потом осуществляется обращение. Скрипт создает три таблицы и одно представление, а также генерирует наборы тестовых записей в этих таблицах:
Fuels (виды топлива) - 1000 штук; 
Tanks (список емкостей) - 100 штук; 
Operations (факты совершения операций прихода, расхода топлива) - 300000 штук.

Для работы с реляционной базой данных toplivo СУБД MS SQL Server использован ОRM фреймворк Entity Framework 6.1 в режиме Database First. Проект содержит модели, контроллеры и представления для выполнения всех операций над данными перечисленных таблиц.
Реализована возможность работы с изображениями емкостей. Графические файлы изображений хранятся в отдельной папке под уникальными именами. В базе данных хранятся ссылки на эти файлы.

Для отображения данных в табличном виде использован элемент WebGrid, в числе прочего, позволяющий сортировать данные по столбцам и разбивать на страницы.

Для демострации авторизованного доступа применен фильтр [Authorize] ко всем методам действий контроллера FuelsController, разрешающего их вызов только авторизованным пользователям. Учетные записи пользователей хранятся в отдельном файле базы данных users.mdf.

