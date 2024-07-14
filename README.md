## System Zarządzania Studentami

Projekt został stworzony w celu nauki i doskonalenia umiejętności związanych z łączeniem aplikacji desktopowej z bazą danych. 

Główne cele to:

- **Nauka Integracji z Bazą Danych**
- **Praktyczne Zastosowanie Entity Framework**
- **Zarządzanie Bazą Danych**

### Kluczowe Funkcje

- **Zarządzanie Studentami**:
  - **Dodawanie**: Umożliwia dodawanie nowych studentów z pełnymi danymi takimi jak imię, nazwisko, numer identyfikacyjny, data urodzenia itp.
  - **Edytowanie**: Edytowanie szczegółów istniejących studentów.
  - **Usuwanie**: Możliwość usuwania studentów z systemu.
  - **Przeglądanie**: Wyświetlanie listy studentów z opcjami filtrowania, sortowania i wyszukiwania.

- **Zarządzanie Kursami**:
  - **Dodawanie**: Możliwość dodawania nowych kursów z określonymi szczegółami, takimi jak nazwa kursu, kod kursu i opis.
  - **Edytowanie**: Edytowanie istniejących kursów.
  - **Usuwanie**: Usuwanie kursów, które nie są już potrzebne.
  - **Przypisywanie Kursów do Studentów**: Umożliwia przypisywanie kursów do studentów i śledzenie ich postępów.

- **System Oceny i Raporty**:
  - **Oceny**: Wprowadzanie i aktualizowanie ocen studentów w ramach kursów.
  - **Raporty**: Generowanie raportów dotyczących zapisów na kursy, ocen oraz postępów studentów. Możliwość eksportowania raportów do różnych formatów, takich jak PDF czy Excel.

- **Interfejs Użytkownika**:
  - **Przyjazny Interfejs**: Intuicyjny i łatwy w obsłudze interfejs użytkownika zaprojektowany z myślą o efektywności i wygodzie pracy.

### Struktura Kodu

- **Formularze**: Zawierają interfejs użytkownika dla różnych funkcji, takich jak dodawanie, edytowanie i przeglądanie studentów oraz kursów.
- **Modele**: Klasy reprezentujące dane aplikacji, takie jak `StudentClass`, `CourseClass`, `ScoreClass`.
- **Baza Danych**: Używa lokalnej bazy danych (SQL Server) do przechowywania informacji o studentach, kursach i ocenach. Wykorzystuje Entity Framework do mapowania obiektów na bazę danych.

### Zrzuty Ekranu

---

Ten opis zawiera wszystkie kluczowe informacje o projekcie, w tym funkcje, jak uruchomić aplikację, jak ją używać, strukturę kodu oraz technologie, co powinno pomóc potencjalnym pracodawcom i użytkownikom w zrozumieniu i ocenieniu Twojego projektu.
