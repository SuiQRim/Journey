# Journey.Services.Contracts

📦 Библиотека контрактов для слоя бизнес-логики приложения **Journey**.

## 📖 Описание

`Journey.Services.Contracts` содержит интерфейсы сервисов, определяющих бизнес-логику приложения.

Пакет задаёт **контракты для работы с данными и вычислениями**, не привязываясь к конкретной реализации.
Реализация сервисов может находиться в отдельном проекте (например, `Journey.Services`).

---

## 🧩 Содержимое

В библиотеку входят:

* интерфейсы сервисов (например, `ITourService`)
* контракты для бизнес-операций
* абстракции для вычислений и обработки данных

---

## 🎯 Назначение

Пакет реализует слой **бизнес-контрактов** и используется для:

* разделения интерфейсов и реализации
* упрощения тестирования
* снижения связанности между слоями

### Архитектура:

* 📁 **Models** → сущности
* 📁 **Storage.Contracts** → доступ к данным
* 📁 **Services.Contracts** → бизнес-логика (контракты)
* ⚙️ **Services** → реализация
* 🖥 **UI (WinForms)** → использование

---

## 🚀 Установка

Через NuGet:

```bash id="k2s9qd"
dotnet add package Journey.Services.Contracts
```

или через Visual Studio:

* Manage NuGet Packages
* Найти **Journey.Services.Contracts**
* Установить

---

## 🧪 Пример использования

```csharp id="wq3v8l"
using Journey.Services.Contracts;
using Journey.Models;

public class TourController
{
    private readonly ITourService tourService;

    public TourController(ITourService tourService)
    {
        this.tourService = tourService;
    }

    public IEnumerable<Tour> GetTours()
    {
        return tourService.GetTours();
    }
}
```

---

## 🔌 Расширяемость

Вы можете реализовать собственные сервисы, например:

* бизнес-логика расчёта стоимости тура
* статистика по турам
* фильтрация и сортировка

Достаточно реализовать интерфейсы из данного пакета.

---

## 👤 Автор

SuiQRim

---

## 📄 Лицензия

Используется в учебных целях.
