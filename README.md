# Magazyn Butów

## Wprowadzenie

Celem projektu jest stworzenie aplikacji umożliwiającej zarządzanie kolekcją butów na sprzedaż. Użytkownik może przeglądać, dodawać, edytować i usuwać buty wraz z ich szczegółowymi informacjami, takimi jak kolor, marka, styl, rozmiar i cena. Aplikacja jest napisana w języku C# w architekturze MVVM, wykorzystując środowisko Visual Studio i bazę danych MySQL.

## Założenia projektu

Aplikacja pozwala użytkownikowi na:
- Dodawanie, edytowanie, usuwanie oraz przeglądanie butów wraz z ich szczegółowymi informacjami.
- Zarządzanie cenami butów w zależności od ich rozmiaru.
- Wyszukiwanie butów według określonych kryteriów.

Główne założenia:
- Intuicyjny interfejs użytkownika.
- Bezpieczeństwo danych.
- Możliwość łatwej rozbudowy aplikacji w przyszłości.

## Opis wymagań

Aby uruchomić i rozwijać aplikację, konieczne jest:
- Zainstalowanie środowiska programistycznego Visual Studio.
- Zainstalowanie i skonfigurowanie bazy danych MySQL.
- Zainstalowanie wszystkich wymaganych zależności .NET.

## Realizacja projektu

### Kluczowe metody w klasie `canMethods.cs`:

1. **CanAddShoe** - Sprawdza, czy możliwe jest dodanie nowego buta do bazy danych.
2. **CanAddToCennik** - Sprawdza, czy można dodać buta do cennika.
3. **CanModifyToCennik** - Sprawdza, czy możliwa jest modyfikacja cennika.
4. **CanDeleteFromCennik** - Sprawdza, czy możliwe jest usunięcie buta z cennika.
5. **CanResetFilterring** - Sprawdza, czy można zresetować filtry.
6. **CanFilterShoes** - Sprawdza, czy możliwe jest przefiltrowanie butów.
7. **CanDeleteShoe** - Sprawdza, czy możliwe jest usunięcie buta z bazy danych.

### Kluczowe komendy w klasie `Commands.cs`:

1. **AddShoeCommand** - Dodawanie nowego buta do magazynu.
2. **AddToCennikCommand** - Dodawanie buta do cennika.
3. **ModifyToCennikCommand** - Modyfikowanie informacji o butach w cenniku.
4. **UsunFromCennikCommand** - Usuwanie buta z cennika.
5. **ShoesFilterringCommand** - Filtrowanie butów według określonych kryteriów.
6. **ResetFilterringCommand** - Resetowanie filtrów.
7. **DeleteShoeCommand** - Usuwanie buta z magazynu.

### Kluczowe właściwości i metody w klasie `MagazynButowViewModel`:

- Inicjalizacja połączenia z bazą danych.
- Ładowanie podstawowych danych z bazy przy starcie.
- Metody operacji na danych: `AddShoe`, `DeleteShoe`, `AddToCennik`, `ModifyToCennik`, `DeleteFromCennik`, `ResetFilterring`, `ShoesFilterring`.

### Klasa `RelayCommand`

- Implementuje interfejs `ICommand` w architekturze MVVM.
- Definiowanie poleceń z określonymi akcjami i warunkami ich wykonania.

### Klasa `Variables`

- Definiuje model widoku dla aplikacji.
- Przechowuje informacje o połączeniu z bazą danych oraz różne typy danych aplikacji.

## Interfejs użytkownika

### Zakładka `Informacje ogólne`

- ComboBox do wyboru funkcji: Buty, Cennik, Kolory, Kolory_buta, Marki, Rozmiary, Rozmiary_marek, Style, Widokfiltrowaniabutow.

### Zakładka `Dodaj Buta`

- ComboBoxy do wyboru Stylu i Marki oraz TextBoxy do uzupełnienia informacji o butach.

### Zakładka `Usuń Buta`

- ComboBox do wyboru modelu, kolorystyki oraz SKU buta do usunięcia.

### Zakładka `Dodaj/Modyfikuj/Usuń cennik`

- ComboBoxy do wyboru modelu, kolorystyki, SKU oraz rozmiaru.
- TextBox do uzupełnienia lub modyfikacji ceny.

### Zakładka `Poszukaj butów`

- Możliwość filtrowania butów poprzez wybór z odpowiednich ComboBoxów.

## Wnioski

### Podsumowanie projektu

Projekt został zrealizowany zgodnie z założeniami. Użytkownik może dodawać, edytować, usuwać i przeglądać buty oraz zarządzać cenami. Aplikacja posiada pełną walidację danych i funkcje filtrowania.

