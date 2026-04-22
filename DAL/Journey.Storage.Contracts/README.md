# Journey.Storage.Contracts

📦 Библиотека контрактов для слоя хранения данных приложения **Journey**.

## 📖 Описание

`Journey.Storage.Contracts` содержит интерфейсы и абстракции, определяющие работу со слоем хранения данных (repository layer).

Пакет задаёт **контракты доступа к данным**, не привязываясь к конкретной реализации (в памяти, база данных и т.д.).

---

## 🧩 Содержимое

В библиотеку входят:

* интерфейсы репозиториев (например, `IToursRepository`)
* базовые контракты для работы с данными
* абстракции для CRUD-операций

---

## 🎯 Назначение

Основная цель пакета — разделение ответственности между слоями:

* 📁 **Contracts** → только интерфейсы
* ⚙️ **Services / Storage** → реализация логики
* 🖥 **UI (WinForms)** → использование

Это позволяет:

* легко менять способ хранения данных
* тестировать бизнес-логику независимо от хранилища
* снизить связанность кода

---

## 🚀 Установка

Через NuGet:

```bash
dotnet add package Journey.Storage.Contracts
```

или через Visual Studio:

* Manage NuGet Packages
* Найти **Journey.Storage.Contracts**
* Установить

---

## 🧪 Пример использования

```csharp
using Journey.Storage.Contracts;
using Journey.Models;

public class ToursService
{
    private readonly IToursRepository repository;

    public ToursService(IToursRepository repository)
    {
        this.repository = repository;
    }

    public IEnumerable<Tour> GetTours()
    {
        return repository.GetTours();
    }
}
```

---

## 🔌 Расширяемость

Вы можете реализовать собственное хранилище, например:

* InMemory (в памяти)
* SQL Server
* SQLite
* API / внешние сервисы

Достаточно реализовать интерфейсы из данного пакета.

---

## 👤 Автор

SuiQRim

---

## 📄 Лицензия

Используется в учебных целях.
