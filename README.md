MojeDemotywatory
================

MojeDemotywatry to projekt w ASP.NET MVC 4, który ma zadanie wyświetlanie demotywatorów (tylko obrazków, bez reklam i innych zbędnych dodatków ze strony demotywatory.pl 

Jak to działa: 

Obrazki są pobierane ze strony demotywatory.pl. Pobierane są wszystkie obrazki ze strony łącznie z obrazkami w formie slajdów. Obrazki są wyświetlane jeden pod drugim łącznie ze wszystkimi slajdami (czyli nie potrzeba nic klikać, nic przewijac itd)

MojeDemotywatory pozwalają na:

  -  wyświetlanie demotywatorów z dowolnej strony, 
  -  przeskakiwanie do nastepnej strony. Nie ma limitu stron, 
  -  przeskakiwanie do losowej strony (co pozwala odkryć więcej demotywatorów, których nie widzieliśmy),
  -  dodanie do ulubionych(w tej chwli w formie adresu  do pliku) obrazków,
  -  przeglądanie ulubionych.

### Szybki start:

MojeDemotywatory składają się z 4 projektów:

  * MojeDemotywatory, który jest rozwiazaniem ASP .NET-owym dającym dostęp przeglądania demotywatorów na stronie.
  
  * MojeDemotywatoryApi, który jest biblioteką w C#. Jest to API do strony demotywatory.pl. Api udostępnia metody:
    - IEnumerable<Demotywator> PobierzZeStron(int page) - pobiera demotywatory od strony 1 do strony podaj w argumencie.
    - IEnumerable<Demotywator> PobierzZeStrony(int page) - pobiera demotywatory z konkretnej strony podajej w argumencie.
    - IEnumerable<Demotywator> PobierzZGłownej() - pobiera demotywatory z głównej strony czyli z pierwszej.
    
  * BazaLite, która jest wstępną wersją obsługi ulubionych demotywatorów. Udostępnia metody:
    -  void Dodaj(string linia) - dodaje adres do pliku
    -  void Usun(string linia) - usuwa adres z pliku
    -  IEnumerable<string> Odczytaj() - odczytuje wszystkie adresy z pliku.

Projekt jest sukcesywanie rozwijany.

  

      
