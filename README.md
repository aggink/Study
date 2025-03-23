# 📑 Оглавление
- [📌 Правила](#правила)
  - [📑 Формат заголовка PR](#формат-заголовка-pr)
  - [📝 Комментарии к PR](#комментарии-к-pr)
  - [📂 Правила наименования веток](#правила-наименования-веток)
  - [🌿 Ветвление и объединение изменений (Git Flow)](#ветвление-и-объединение-изменений)
- [📌 Лабораторная работа 1](#лабораторная-работа-1)
  - [📝 Задание 1: Реализация логики рациональных чисел](#задание-1-реализация-логики-рациональных-чисел)
  - [📝 Задание 2: Форматы даты и времени](#задание-2-форматы-даты-и-времени)
  - [📝 Задание 3: Реализация простейшего дерева (граф без циклов)](#задание-3-реализация-простейшего-дерева-граф-без-циклов)
  - [🔑 Дополнительные указания](#лаба-1-дополнительные-указания)
- [📌 Лабораторной работы 1: описание](#описание-лабораторной-работы-1)
  - [📁 Структура проекта](#описание-лаб-1-структура-проекта)
  - [📝 Задачи студентов](#описание-лаб-1-задачи-студентов)
- [📌 Лабораторная работа 2](#лабораторная-работа-2)
  - [📝 Задание: Реализация методов для выполнения запросов к серверам](#лаба-2-задание)
  - [🔑 Дополнительные указания](#лаба-2-доп-указания)
- [📌 Лабораторной работы 2: описание](#описание-лабораторной-работы-2)
  - [📁 Структура проекта](#описание-лаб-2-структура-проекта)
  - [📝 Задачи студентов](#описание-лаб-2-задачи-студентов)
- [📌 Лабораторная работа 3](#лабораторная-работа-3)
  - [📝 Задание 1: Разработать API, реализующее CRUD](#лаба-3-задание-1)
  - [📝 Задание 2: Рефакторинг кода](#лаба-3-задание-2)
  - [🔑 Условия успешной сдачи](#лаба-3-условия-сдачи)
- [📢 Важное сообщение](#важное-сообщение)

---

<h1 id="правила">📌 Правила</h1>

При создании PR в нашем проекте необходимо соблюдать установленный формат именования. Это помогает команде быстро понимать суть изменений и их влияние на кодовую базу.

---

<h2 id="формат-заголовка-pr">📑 Формат заголовка PR</h2>
Название PR должно начинаться с **типа изменения** в квадратных скобках. В некоторых случаях могут использоваться **дополнительные флаги**, также заключенные в квадратные скобки и разделенные пробелами.  

### Типы изменений и их использование  

- **🔹 `[Feature]`** – Используется при добавлении новой функциональности, которая **не нарушает** обратную совместимость.  
  ✅ Пример: `[Feature] Реализация нового механизма авторизации`  

- **🔹 `[Fix]`** – Указывается при исправлении ошибок или багов, **не изменяя** совместимость API.  
  ✅ Пример: `[Fix] Исправление логики расчета скидки`  

- **🔹 `[Private]`** – Применяется для **внутренних изменений**, таких как рефакторинг, улучшение структуры кода, не влияющих на поведение системы.  
  ✅ Пример: `[Private] Оптимизация работы с базой данных`  

- **🔹 `[BREAK]`** – Дополнительный флаг, указывающий, что изменения **ломают обратную совместимость**. Используется **вместе** с основным типом.  
  ✅ Пример: `[Feature] [BREAK] Обновлен формат JSON-ответов API`  

- **🔹 `[CI]`** – Указывает, что PR касается **инфраструктурных изменений**, связанных с CI/CD процессами, настройками сборки и деплоя.  
  ✅ Пример: `[Private] [CI] Настроен автоматический деплой в тестовое окружение`  

- **🔹 `[CherryPick]`** – Используется, если PR **является переносом** (cherry-pick) изменений из другой ветки.  
  ✅ Пример: `[Fix] [CherryPick] Исправлена ошибка расчета налога из ветки release-1.2`  

---

<h2 id="комментарии-к-pr">📝 Комментарии к PR</h2>

При создании PR необходимо добавить подробное описание, содержащее:  

1️⃣ **Введение**  
- 🔹 Здесь кратко укажите, почему был создан этот PR, какова его цель и какие проблемы решаются.  

2️⃣ **Краткое объяснение сути изменений**  
- 🔹 Описание самих изменений, что было сделано и зачем. Опишите, как эти изменения улучшат проект или решат конкретную задачу.  

3️⃣ **Как протестировано**  
- 🔹 Важно указать, как именно был протестирован функционал. Укажите использованные методы тестирования, окружение или шаги, которые были выполнены для проверки.  

4️⃣ **Дополнительную информацию о влиянии изменений**  
- 🔹 Укажите, как изменения могут повлиять на другие части системы, особенно если они затрагивают API, безопасность или важные модули проекта.  

---

<h2 id="правила-наименования-веток">📂 Правила наименования веток</h2>

Ветки в репозитории должны соответствовать следующему паттерну:  
`tasks/{имя группы}/{порядковый номер}/{название ветки}`

### Примеры наименования веток:

- **`tasks/tech/1/add-oauth-authentication`**  
- Тип изменений: новая функциональность, добавлен OAuth-аутентификатор.

- **`tasks/assistant/2/fix-discount-calculation`**  
- Тип изменений: исправление ошибки в расчете скидки.

- **`tasks/tech/5/ci-setup`**  
- Тип изменений: настройка CI/CD для нового репозитория.

---

<h2 id="ветвление-и-объединение-изменений">🌿 Ветвление и объединение изменений (Git Flow)</h2>

При работе с репозиторием важно соблюдать **чистоту основных веткок** и правильно объединять изменения.  

### 🔹 Структура базовых веток в проекте:
- **`master-base`** – ветка, содержащая шаблоны заданий, описание лабораторных, не предусмотрена для изменения студентами.  
- **`master`** – основная ветка курса, в нее будут нацелены все студенческие изменения.

### 🔹 Основные правила Pull Request'ов:
- Каждый Pull Request должен содержать только логически связанные изменения, относящиеся к решению конкретной задачи.  
- Перед объединением (merge) необходимо выполнить squash (объединение коммитов), чтобы не засорять историю основной ветки.  
- Исключение – если Pull Request обновляет основную ветку с важными изменениями, тогда применяется обычный merge, но это касается обычно при синхронизации основных веток. Например, ветки **master** c веткой **master-base**.  

### 🔹 Какой merge использовать?  
- ✅ **Squash and Merge** – для объединения всех коммитов Pull Request'а в один, чтобы история была чистой.  
- ✅ **Merge with all commits** – только для синхронизации базовых веток.  

---

🚀 Следование этим правилам поможет сделать код-ревью быстрее и понятнее для всей команды 🚀

---

<h1 id="лабораторная-работа-1">📌 Лабораторная работа 1</h1>

<h2 id="задание-1-реализация-логики-рациональных-чисел">📝 Задание 1: Реализация логики рациональных чисел</h2>

### Описание задачи:
Необходимо создать класс, который будет реализовывать логику рациональных чисел. Рациональное число – это число, которое представлено двумя натуральными числами и записано в виде дроби.

### Требования:
1. **Два целочисленных свойства только для чтения**:
   - `Numerator` — числитель.
   - `Denominator` — знаменатель.
   
2. **Конструктор** с двумя целочисленными параметрами для инициализации числителя и знаменателя.

3. Метод **ToString**:
   - Должен возвращать строку в формате дроби, например: «2/3», «5/2» и т.д.

4. **Перегрузка операторов**:
   - Операторы арифметических операций:
     - `+`, `-`, `*`, `/`
   - Оператор унарного минуса: `-`
   
5. **Перегрузка операторов сравнения**:
   - `==`, `!=`, `<`, `<=`, `>`, `>=`

6. Написание **unit-тестов** для проверки функциональности класса.

### Дополнительные требования:
- Корректная работа с **Denominator = 0**.
- Числитель и знаменатель должны **автоматически сокращаться**. Например, дробь «5/10» должна быть представлена как «1/2».
- При получении **целой дроби** необходимо выводить только число, без знаменателя.
- Корректная работа с **отрицательными числами** в числителе и знаменателе.
- Корректная работа с арифметическими операциями и знаком дроби.

---

<h2 id="задание-2-форматы-даты-и-времени">📝 Задание 2: Форматы даты и времени</h2>

### Описание задачи:
Необходимо реализовать классы для вывода текущей даты и времени в двух форматах:
1. **Европейский стиль**.
2. **Американский стиль**.

### Требования:
1. Реализовать **декораторы**, которые добавляют в строки даты и времени произвольные символы (по вариантам).
   
2. В результате программист должен иметь возможность изменять только файл `Program.cs` и применять декораторы в **произвольных количествах** и **произвольном порядке**.

3. Использовать **CultureInfo** для задания формата даты и времени.

4. Использовать **StringBuilder** для формирования результирующих строк.

5. Написание **unit-тестов** для проверки корректности работы классов и декораторов.

---

<h2 id="задание-3-реализация-простейшего-дерева-граф-без-циклов">📝 Задание 3: Реализация простейшего дерева (граф без циклов)</h2>

### Описание задачи:
Необходимо реализовать класс, представляющий **дерево**. Дерево должно быть графом без циклов, где каждый узел может иметь несколько потомков, а каждый потомок может также иметь свои потомков.

### Требования:
1. У **узла дерева** должно быть как минимум два свойства:
   - Список или массив с **потомками** узла.
   - Значение узла (например, число или строка).

2. У узла должна быть реализована функция, которая будет выводить на экран все значения его **потомков**, а также потомков вложенных в эти узлы.

3. Конфигурация дерева должна определяться в файле **`Program.cs`**.

4. Написание **unit-тестов** для проверки корректности структуры дерева и его работы.

---

<h2 id="лаба-1-дополнительные-указания">🔑 Дополнительные указания:</h2>

- Во всех заданиях необходимо обязательно **написать unit-тесты** для проверки функциональности классов и методов.
- Используйте правильные классы и методы для обработки ошибок, например, проверку на ноль для знаменателя в рациональных числах.
- Для работы с датой и временем используйте встроенные возможности .NET для работы с культурами и форматами.
- При реализации дерева учтите возможность рекурсивного обхода и работы с вложенными структурами данных.

--- 

<h1 id="описание-лабораторной-работы-1">📌 Лабораторной работы 1: описание</h1>

<h2 id="описание-лаб-1-структура-проекта">📁 Структура проекта</h2>

Проект организован так, чтобы код был логически разделен на смысловые блоки, обеспечивая удобство работы и расширяемость.  

### 🔹 Основные компоненты:  
- **`Study.Lab1`** – основной исполняемый проект, содержащий точку входа (`Program.cs`).  
- **`Study.Lab1.Logic`** – проект, содержащий реализацию логики задач. Здесь студенты создают свою папку с никнеймом, в которой размещают свои решения.  
- **`Study.Lab1.Logic.Interfaces`** – проект, содержащий интерфейсы для всех сервисов, обеспечивающий четкое разделение логики и контрактов.  
  - Структура папок в этом проекте зеркально повторяет структуру `Study.Lab1.Logic`, чтобы каждому классу соответствовал свой интерфейс.  
- **`Study.Lab1.Logic.UnitTests`** – проект с тестами, позволяющий проверить корректность работы реализованных решений.  

---

<h2 id="описание-лаб-1-задачи-студентов">📝 Задачи студентов</h2>

В рамках лабораторной работы каждый студент выполняет три задания, создавая свою реализацию по аналогии с представленными примерами.  

### 🔧 **Алгоритм выполнения**  

### 1️⃣ Добавление кейса в `GetRunLabService`  
В файле `Program.cs` в методе `GetRunLabService` необходимо добавить новый `case` с параметрами:  
- **Название группы** – название группы.  
- **Порядковый номер** – порядковый номер в списке группы.  

Этот кейс должен возвращать экземпляр созданного вами сервиса, реализующего интерфейс `IRunService`.  

### 🔹 Пример кода:
```csharp
private static IRunService GetRunLabService(string group, int number)
{
    switch (group, number)
    {
        case ("group_name", 1):
            return new NicknameService();
        default:
            throw new NotSupportedException();
    }
}
```

### 2️⃣ Создание собственной папки  

В проекте **`Study.Lab1.Logic`** создайте папку с вашим никнеймом.  
- Внутри этой папки создайте отдельные подпапки для каждого задания (`Task1`, `Task2`, `Task3`).  
- В каждой подпапке будут храниться классы, реализующие решения конкретных задач.  

### 🔹 Пример структуры:  
```plaintext
Study.Lab1.Logic
├── Nickname
│   ├── Task1
│   │   ├── Solution1.cs
│   ├── Task2
│   │   ├── Solution2.cs
│   ├── Task3
│   │   ├── Solution3.cs
```

### 3️⃣ Создание интерфейса в `Study.Lab1.Logic.Interfaces`  

В проекте **`Study.Lab1.Logic.Interfaces`** создайте папку с вашим никнеймом.  
- В этой папке создайте подпапки для каждого задания (`Task1`, `Task2`, `Task3`).  
- Внутри подпапок разместите интерфейсы, описывающие функциональность соответствующих классов.  
- Эти интерфейсы обеспечат единый контракт для ваших решений, что упростит их использование и тестирование.  

### 🔹 Пример структуры:  
```plaintext
Study.Lab1.Logic.Interfaces
├── Nickname
│   ├── Task1
│   │   ├── ISolution1.cs
│   ├── Task2
│   │   ├── ISolution2.cs
│   ├── Task3
│   │   ├── ISolution3.cs
```

### 4️⃣ Реализация сервиса  

В вашей папке **`Study.Lab1.Logic`** создайте класс **`NicknameService`**, который реализует интерфейс `IRunService`.  
- Этот класс должен включать методы для выполнения всех трех заданий (`RunTask1`, `RunTask2`, `RunTask3`).  
- Внутри этих методов создавайте экземпляры классов решений, а затем вызывайте их методы.  
- **Важно!** В классах решения не используйте `Console.WriteLine()`, кроме класса сервиса **`NicknameService`**, где **`Nickname`** = ваш **GitHub-никнейм**.

### 🔹 Пример структуры:
```plaintext
Study.Lab1.Logic
├── Nickname
│   ├── Task1
│   │   ├── Solution1.cs
│   ├── Task2
│   │   ├── Solution2.cs
│   ├── Task3
│   │   ├── Solution3.cs
│   ├── NicknameService.cs
```

### 5️⃣ Добавление сервиса в `GetRunLabService`  

После создания сервиса его необходимо зарегистрировать в методе `GetRunLabService` в файле **`Program.cs`**.  
Этот метод используется для выбора и запуска нужного сервиса в зависимости от переданных параметров.  

### 🔹 Инструкции:  
1. Откройте файл **`Program.cs`**.  
2. Найдите метод **`GetRunLabService`**.  
3. Добавьте новый `case`, где:  
   - **Название группы** – название группы.  
   - **Порядковый номер** – порядковый номер в списке группы.  
   - `return new NicknameService();` — создаёт экземпляр вашего сервиса.  
4. Если группа и номер не соответствуют вашему сервису, программа выдаст исключение `NotSupportedException()`.  

### 🔹 Пример кода:
```csharp
private static IRunService GetRunLabService(string group, int number)
{
    switch (group, number)
    {
        case ("group_name", 1):
            return new NicknameService();
        default:
            throw new NotSupportedException();
    }
}
```

### 6️⃣ Реализация классов решений  

Теперь необходимо создать и реализовать классы, которые будут выполнять конкретные задания. Эти классы необходимо разместить в подпапках `Task1`, `Task2`, `Task3` внутри вашей папки с никнеймом. Каждая папка должна содержать отдельные классы, решающие задачи, поставленные в лабораторной работе.  

### 🔹 Структура проекта:
В папке с вашим никнеймом должны быть созданы следующие каталоги и классы (наименование классов на усмотрение разработчика):

```plaintext
Study.Lab1.Logic
├── Nickname
│   ├── Task1
│   │   ├── Solution1.cs
│   ├── Task2
│   │   ├── Solution2.cs
│   ├── Task3
│   │   ├── Solution3.cs
```

### 7️⃣ Написание юнит-тестов

После того как логика для выполнения задач будет реализована, следующим шагом будет создание юнит-тестов для проверки корректности вашего кода. Эти тесты помогут убедиться, что ваше решение работает как ожидается, и будет полезным для проверки функционала, особенно если в будущем будут вноситься изменения.

Юнит-тесты создаются в проекте **`Study.Lab1.Logic.UnitTests`**, который уже существует в вашем проекте. Для каждого задания, реализованного в вашем сервисе, необходимо создать отдельные тесты.

### 🔹 Структура тестов:
1. В проекте **`Study.Lab1.Logic.UnitTests`** создайте папку с вашим никнеймом.
2. Внутри папки с вашим никнеймом создайте подпапки для каждого задания — `Task1`, `Task2`, `Task3`.
3. В каждой подпапке создайте тестовый класс с именем, совпадающим с именем класса решения, только с добавлением суффикса `Tests`.

```plaintext
Study.Lab1.Logic.UnitTests
├── Nickname
│   ├── Task1
│   │   ├── Solution1Tests.cs
│   ├── Task2
│   │   ├── Solution2Tests.cs
│   ├── Task3
│   │   ├── Solution3Tests.cs
```

### 8️⃣ Финальная проверка

После того как все классы решений и юнит-тесты будут готовы, необходимо провести финальную проверку, чтобы убедиться, что весь проект работает корректно и соответствует требованиям.

### 🔹 Шаги для финальной проверки:

1. **Скомпилируйте проект**:
   Убедитесь, что проект компилируется без ошибок. Для этого можно использовать функцию `Build Solution` в вашей IDE или команду `dotnet build` в терминале.

2. **Запустите все юнит-тесты**:
   Убедитесь, что все тесты проходят успешно. Используйте тестовый фреймворк (например, NUnit или xUnit) и запустите все тесты для вашего проекта. Вы должны увидеть, что все тесты проходят без ошибок.

3. **Проверьте правильность работы программы**:
   Убедитесь, что программа корректно выполняет все задания. Для этого можно запустить программу и проверить, что она выводит правильные результаты в консоль для каждого задания.

4. **Проверьте, что вывод в консоль используется только в сервисе**:
   Все логические классы (включая классы, реализующие форматирование дат, времени и другие задачи) не должны использовать вывод в консоль. Вывод в консоль должен использоваться только в основном сервисе (например, `AssistantService`), который является точкой входа программы.

5. **Убедитесь в корректности выполнения каждого задания**:
   Проверьте, что для каждого задания:
   - Выполнены все требования.
   - Программа работает корректно при разных входных данных.
   - Все юнит-тесты проходят успешно.

6. **Проверьте соответствие заданиям**:
   Убедитесь, что вы правильно реализовали все задачи, которые должны быть выполнены в рамках лабораторной работы. Программа должна четко выполнять все поставленные задачи в соответствии с требованиями.

### 🔹 Пример успешного выполнения:

Если все проверки пройдены успешно, и ваши тесты проходят без ошибок, можно считать лабораторную работу завершенной. Ваш проект будет готов к сдаче, если:

- Все тесты проходят успешно.
- Программа выполняет все задания корректно.
- Логика для каждого задания реализована правильно.

🚀 **Поздравляем с успешным выполнением лабораторной работы!** 🎉

---

<h1 id="лабораторная-работа-2">📌 Лабораторная работа 2</h1>

<h2 id="лаба-2-задание">📝 Задание: Реализация методов для выполнения запросов к серверам</h2>

### Описание задачи:
Необходимо разработать **два метода**, которые выполняют три запроса к разным серверам и обрабатывают их результаты.

> **💡Комментарий:** Оценка будет зависеть от сложности реализации поставленной задачи. Чем более сложное и функциональное решение будет предложено, тем выше будет оценка. 🎯

### Требования к реализации:

1. **Метод 1** – выполнение запросов **без использования асинхронного программирования**.
2. **Метод 2** – выполнение запросов **с использованием асинхронного программирования**.

### Функциональные требования:

- Оба метода должны выполнять **три запроса** к разным серверам.
- В случае получения **негативного ответа от сервера**, программа должна завершать выполнение и выводить понятный текст ошибки.
- Ответы от серверов должны выводиться в **формате JSON**.
- По завершении всех запросов приложение должно выводить **общее время работы**.

<h2 id="лаба-2-доп-указания">📝 Дополнительные указания</h2>

- **Обработка ошибок**: корректная обработка возможных ошибок при сетевых запросах.
- **Форматирование вывода**: JSON-ответы должны быть читаемыми и структурированными.
- **Производительность**: во втором методе следует использовать механизмы асинхронного программирования для минимизации времени ожидания.
- **Unit-тесты**: необходимо написать тесты для проверки корректности работы обоих методов, включая обработку ошибок и формат вывода.

---

<h1 id="описание-лабораторной-работы-2">📌 Лабораторной работы 2: описание</h1>

<h2 id="описание-лаб-2-структура-проекта">📁 Структура проекта</h2>

Проект организован так, чтобы код был логически разделен на смысловые блоки, обеспечивая удобство работы и расширяемость.  

### 🔹 Основные компоненты:  
- **`Study.Lab2`** – основной исполняемый проект, содержащий точку входа (`Program.cs`).  
- **`Study.Lab2.Logic`** – проект, содержащий реализацию логики задач. Здесь студенты создают свою папку с никнеймом, в которой размещают свои решения.  
- **`Study.Lab2.Logic.Interfaces`** – проект, содержащий интерфейсы для всех сервисов, обеспечивающий четкое разделение логики и контрактов.  
  - Структура папок в этом проекте зеркально повторяет структуру `Study.Lab2.Logic`, чтобы каждому классу соответствовал свой интерфейс.  
- **`Study.Lab2.Logic.UnitTests`** – проект с тестами, позволяющий проверить корректность работы реализованных решений.  

---

<h2 id="описание-лаб-2-задачи-студентов">📝 Задачи студентов</h2>

В рамках лабораторной работы каждый студент разрабатывает **два метода**, которые выполняют три запроса к разным серверам и обрабатывают их результаты.

### 🔧 **Алгоритм выполнения**  

### 1️⃣ Добавление кейса в `GetRunLabService`  
В файле `Program.cs` в методе `GetRunLabService` необходимо добавить новый `case` с параметрами:  
- **Название группы** – название группы.  
- **Порядковый номер** – порядковый номер в списке группы.  

Этот кейс должен возвращать экземпляр созданного вами сервиса, реализующего интерфейс `IRunService`.  

### 🔹 Пример кода:
```csharp
private static IRunService GetRunLabService(string group, int number)
{
    switch (group, number)
    {
        case ("group_name", 1):
            return new NicknameService();
        default:
            throw new NotSupportedException();
    }
}
```

### 2️⃣ Создание собственной папки  

В проекте **`Study.Lab2.Logic`** создайте папку с вашим никнеймом.  
- Внутри этой папки будут храниться классы для решения поставленной задачи.

### 🔹 Пример структуры:  
```plaintext
Study.Lab2.Logic
├── Nickname
```

### 3️⃣ Создание интерфейса в `Study.Lab2.Logic.Interfaces`  

В проекте **`Study.Lab2.Logic.Interfaces`** создайте папку с вашим никнеймом.  
- Внутри папки разместите интерфейсы, описывающие функциональность соответствующих классов.  
- Эти интерфейсы обеспечат единый контракт для ваших решений, что упростит их использование и тестирование.  

### 🔹 Пример структуры:  
```plaintext
Study.Lab1.Logic.Interfaces
├── Nickname
```

## 4️⃣ Реализация сервиса  

В вашей папке **`Study.Lab2.Logic`** создайте класс **`NicknameService`**, который реализует интерфейс `IRunService`.
- Этот класс должен включать методы для синхронного (`RunTask`) и асинхронного (`RunTaskAsync`) выполнения HTTP-запросов.  
- Внутри этих методов используйте используйте разработанные вами сервисы для выполнения HTTP-запросов и обработки результатов.  
- **Важно!** В классах решения не используйте `Console.WriteLine()`, кроме класса сервиса **`NicknameService`**, где **`Nickname`** = ваш **GitHub-никнейм**.

### 🔹 Пример структуры проекта:
```plaintext
Study.Lab1.Logic
├── Nickname
│   ├── NicknameService.cs
```

### 5️⃣ Добавление сервиса в `GetRunLabService`  

После создания сервиса его необходимо зарегистрировать в методе `GetRunLabService` в файле **`Program.cs`**.  
Этот метод используется для выбора и запуска нужного сервиса в зависимости от переданных параметров.  

### 🔹 Инструкции:  
1. Откройте файл **`Program.cs`**.  
2. Найдите метод **`GetRunLabService`**.  
3. Добавьте новый `case`, где:  
   - **Название группы** – название группы.  
   - **Порядковый номер** – порядковый номер в списке группы.  
   - `return new NicknameService();` — создаёт экземпляр вашего сервиса.  
4. Если группа и номер не соответствуют вашему сервису, программа выдаст исключение `NotSupportedException()`.  

### 🔹 Пример кода:
```csharp
private static IRunService GetRunLabService(string group, int number)
{
    switch (group, number)
    {
        case ("group_name", 1):
            return new NicknameService();
        default:
            throw new NotSupportedException();
    }
}
```

### 6️⃣ Реализация классов решений  

В данной лабораторной работе будет реализовано несколько классов, каждый из которых будет отвечать за конкретную область задачи. Это пример разделения ответственности, где каждый класс решает одну задачу, что упрощает поддержку, тестирование и расширение проекта. 

*Данный набор сервисов и методов является* **примерным** *и не обязательным для выполнения задания. Студенты могут изменять, расширять и адаптировать его под свои нужды, добавлять новые сервисы или изменять наименования методов, чтобы лучше соответствовать требованиям задания.*

### 🔹 Описание сервисов

**Примечание:** Данный набор сервисов и методов является примерным. Студенты могут адаптировать его и расширять, изменять имена методов и классов в зависимости от потребностей проекта.

1. **Сервис отправки HTTP-запросов**  
   Этот сервис отвечает за отправку запросов к серверу. Он может включать методы для синхронной и асинхронной отправки запросов и обработки ошибок. Основная задача — обеспечить базовую логику взаимодействия с внешними API, как для синхронных, так и для асинхронных операций.

   **Методы могут включать:**
   - Синхронный метод для получения данных с удаленного сервера.
   - Асинхронный метод для того же, но с использованием `async/await` для улучшения производительности.

   **Задачи:**
   - Отправка запросов по HTTP.
   - Обработка статусов ответа (например, успешный или неуспешный ответ).
   - Генерация исключений при ошибках.

2. **Сервис обработки полученных данных**  
   Этот сервис отвечает за обработку данных, полученных от сервера. После получения ответа от API, сервис должен обработать его, например, преобразовать в нужный формат или проверить на наличие ошибок.

   **Методы могут включать:**
   - Метод для преобразования (например, парсинга) ответа в нужный формат (например, JSON).
   - Метод для проверки корректности полученных данных.

   **Задачи:**
   - Преобразование данных в требуемый формат (например, JSON).
   - Проверка данных на наличие ошибок или их соответствие определенным условиям.

3. **Сервис взаимодействия с сервером**  
   Этот сервис инкапсулирует логику взаимодействия с конкретными серверными API. Он использует сервисы для отправки запросов и обработки данных, управляет логикой работы с различными API и агрегирует результаты.

   **Методы могут включать:**
   - Метод для получения данных с серверов.
   - Метод для отправки данных на сервер (например, отправка данных в формате JSON).
   - Метод обработки полученных данных.

   **Задачи:**
   - Управление взаимодействием с внешними сервисами.
   - Использование других сервисов для отправки запросов и обработки данных.

```plaintext
Study.Lab2.Logic
├── Assistant
│   ├── AssistantService.cs        # Основной сервис для выполнения задач
│   ├── RequestService.cs          # Сервис отправки HTTP-запросов
│   ├── ResponseProcessor.cs       # Сервис обработки полученных данных
│   ├── ServerRequestService.cs    # Сервис для работы с конкретными серверами

Study.Lab2.Logic.Interfaces
├── Assistant
│   ├── IRunService.cs             # Интерфейс для выполнения задачи
│   ├── IRequestService.cs         # Интерфейс для отправки запросов
│   ├── IResponseProcessor.cs      # Интерфейс для обработки данных
│   ├── IServerRequestService.cs   # Интерфейс для взаимодействия с сервером
```

### 7️⃣ Написание юнит-тестов

После того как логика для выполнения задач будет реализована, следующим шагом будет создание юнит-тестов для проверки корректности вашего кода. Эти тесты помогут убедиться, что ваше решение работает как ожидается, и будет полезным для проверки функционала, особенно если в будущем будут вноситься изменения.

Юнит-тесты создаются в проекте **`Study.Lab2.Logic.UnitTests`**, который уже существует в вашем проекте. Для каждого задания, реализованного в вашем сервисе, необходимо создать отдельные тесты.

### 🔹 Структура тестов:
1. В проекте **`Study.Lab2.Logic.UnitTests`** создайте папку с вашим никнеймом.
2. Структура папок и наименование классов в тестах должны повторять структуру в проекте **`Study.Lab2.Logic`**. В именах классов тестов должен быть суффикс `Tests`.

### 8️⃣ Финальная проверка

После того как все классы решений и юнит-тесты будут готовы, необходимо провести финальную проверку, чтобы убедиться, что весь проект работает корректно и соответствует требованиям.

### 🔹 Шаги для финальной проверки:

1. **Скомпилируйте проект**:
   Убедитесь, что проект компилируется без ошибок. Для этого можно использовать функцию `Build Solution` в вашей IDE или команду `dotnet build` в терминале.

2. **Запустите все юнит-тесты**:
   Убедитесь, что все тесты проходят успешно. Используйте тестовый фреймворк (например, NUnit или xUnit) и запустите все тесты для вашего проекта. Вы должны увидеть, что все тесты проходят без ошибок.

3. **Проверьте правильность работы программы**:
   Убедитесь, что программа корректно выполняет все задания. Для этого можно запустить программу и проверить, что она выводит правильные результаты в консоль для каждого задания.

4. **Проверьте, что вывод в консоль используется только в сервисе**:
   Все логические классы (включая классы, реализующие форматирование дат, времени и другие задачи) не должны использовать вывод в консоль. Вывод в консоль должен использоваться только в основном сервисе (например, `AssistantService`), который является точкой входа программы.

5. **Убедитесь в корректности выполнения каждого задания**:
   Проверьте, что для каждого задания:
   - Выполнены все требования.
   - Программа работает корректно при разных входных данных.
   - Все юнит-тесты проходят успешно.

6. **Проверьте соответствие заданиям**:
   Убедитесь, что вы правильно реализовали все задачи, которые должны быть выполнены в рамках лабораторной работы. Программа должна четко выполнять все поставленные задачи в соответствии с требованиями.

### 🔹 Пример успешного выполнения:

Если все проверки пройдены успешно, и ваши тесты проходят без ошибок, можно считать лабораторную работу завершенной. Ваш проект будет готов к сдаче, если:

- Все тесты проходят успешно.
- Программа выполняет все задания корректно.
- Логика для каждого задания реализована правильно.

🚀 **Поздравляем с успешным выполнением лабораторной работы!** 🎉

---

<h1 id="лабораторная-работа-3">📌 Лабораторная работа 3</h1>

<h2 id="лаба-3-задание-1">📝 Задание 1: Разработать API, реализующее CRUD</h2>

### Описание задачи:
Разработать API, реализующее CRUD (создание, чтение, обновление, удаление) операции с базой данных, содержащей минимум **три таблицы**.  

### Требования:
1. Создать базу данных с тремя таблицами.  
2. Реализовать API с CRUD-операциями для каждой таблицы.  
3. **Требования к структуре БД:**  
   - **Оценка 3** – таблицы без связей или со связями "один к одному".  
   - **Оценка 4** – таблицы имеют связи, включая хотя бы одну "один ко многим".  
   - **Оценка 5** – таблицы имеют связи "один ко многим" и хотя бы одну "многие ко многим".  

<h2 id="лаба-3-задание-2">📝 Задание 2: Рефакторинг кода</h2>

### Описание задачи:
Провести рефакторинг кода другого разработчика.

### Требования:
1. Запросить у преподавателя задачу на рефакторинг.  
2. Провести рефакторинг кода другого разработчика, применяя современные подходы к построению веб-приложений.  
3. Улучшить читаемость, архитектуру и производительность API.  

<h2 id="лаба-3-условия-сдачи">📝 Условия успешной сдачи</h2>
 
Для успешного выполнения лабораторной работы необходимо выполнить **две задачи**:  
1. Реализовать API с CRUD-методами.  
2. Провести рефакторинг кода другого разработчика.  

✅ **Итог:** студент сначала разрабатывает API с CRUD-методами, а затем улучшает код другого разработчика.

---

<h1 id="важное-сообщение">📢 Важное сообщение</h1>

❗ **Каждое задание в лабораторной работе должно быть выполнено в отдельном pull request**. Это необходимо для того, чтобы облегчить процесс проверки и следить за прогрессом выполнения каждого задания.

### Инструкция:
1. **Создайте новый pull request** для каждого задания.
2. Убедитесь, что pull request включает только решение одного задания (например, **Задание 1**).
3. В комментарии к pull request укажите, какое задание вы выполняете и что было сделано.
4. После выполнения pull request, создайте новый для следующего задания.

Таким образом, ваши задания будут легче проверяться, и процесс будет более структурированным.
