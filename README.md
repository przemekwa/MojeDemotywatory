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
  * MojeDemotywatory udostępnia tez api z możliwością pobrania demotywatorów (api dział ana zasadzie pobierania stron. Na jednej stronie jest około 7-10 demotywatorów)
   - api/page/n-m - pozwala pobrać strony od n do m np: api/page/2-3 pobiera strony 2 i 3.
   - api/page/n   - pozwala pobrać jedną stronę n. np: api/page/55 pobiera stronię 55.
   - api/page     - pozwala pobrać demotywatory z głównej strony.
 
  
  
  * MojeDemotywatoryApi, który jest biblioteką w C#. Jest to API do strony demotywatory.pl. Api udostępnia metody:
    - IEnumerable<Demotywator> GetPages(int page) - pobiera demotywatory od strony 1 do strony podaj w argumencie.
    - IEnumerable<Demotywator> GetPage(int page) - pobiera demotywatory z konkretnej strony podajej w argumencie.
    - IEnumerable<Demotywator> GetMainPage() - pobiera demotywatory z głównej strony czyli z pierwszej.
    
  * MojeDemotywatoryDatabaseApi, która jest wstępną wersją obsługi ulubionych demotywatorów. Udostępnia metody:
    -  void Add(Favorites favorites) - dodaje ulubiony demotywator do bazy
    -  void Remove(int id)) - usuwa ulubiony demotywator z bazy
    -  IEnumerable<string> Get() - odczytuje wszystkie ulubione demotywatory z bazy

Projekt jest sukcesywanie rozwijany.

  

      
