# MPZT
projekt studencki

Aplikacja webowa wspierająca gminy i miasta w konsultacjach społecznych przy tworzeniu miejscowych planów zagospodarowania przestrzennego
Wykorzystane technologie: ASP.NET MVC, SQL Server, NHibernate

#Opis
  Aplikacja składa się z czterech projektów: MPZT.Core, MPZT.Infrastructure, MPZT.Api oraz MPZT.GUI.  
 - MPZT.Core pełni funkcję “domain layer”, czyli definiuje obiekty domenowe i interfejsy repozytoriów. 
 - MPZT.Infrastructure to projekt wspomagający komunikację pomiędzy warstwami oraz odpowiada za przechowywanie i dostęp do danych. 
 Warstwa ta zawiera implementacje repozytoriów oraz interfejsy i implementację serwisów. 
Komunikację pomiędzy projektami zapewniają tzw. DTO (Data Transfer Object), które przekazują i zwracają dane potrzebne w UI do warstwy domenowej. 
- MPZT.Api wykorzystuje bibliotekę Unity.WebApi do komunikacji pomiedzy GUI, a MPZT.Infrastructure, dzięki czemu widoki są zupełnie oddzielone od warstwy logicznej i 
domenowej aplikacji. 
- MPZT.GUI - Grafczny interfejs użytkownika wykonano za pomocą technologii APS.NET.Core wykorzystując wzorzec projektowy MVC (Model-View-Controller). 
