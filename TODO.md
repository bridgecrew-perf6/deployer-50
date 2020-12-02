Kde to lze, tool pracuje přímo s repozitářem - okamžité commity.
Všechna data se drží v datovém modelu, UI je nabindováno na datový model.
Datový model obsahuje i všechny výkonné operace se svn - skeny, aktualizace...

Uživatel zadá URL repozitáře

Prověříme, že cesta je dostupná (zkusíme vylistovat obsah repo)

V repozitáři se zkontroluje vnitřní struktura
 * shared
 * release
 * install

Neexistuje-li, nabídneme vytvoření.
 * Přímo do repo vytvoříme vnitřní strukturu (jen ty části, které chybí, bez modulů...)

Prokenujeme vnitřní strukturu repozitáře
 * Hledáme tzv. moduly (IG, WLTS)
   * Podadresáře těsně pod *shared*, nebo pod *release*
 * Hledáme releasy pro každý z nalezených modulů
   * /release/<module>/head
   * /release/<module>/candindate/<module>/<versionName>
   * /release/<module>/final/<module>/<versionName>
 * Hledáme instalace pro každý z nalezených modulů
   * /install/<state>/<site>/<env>/<module>

Naplníme listbox App Modules
Pro vybraný modul plníme listboxy Releases, Installs, Shared resources (externals)

New App Module
 * Vybereme template z konfigurační složky Templates
 * Založíme repo podadresář pod shared, release, install
 * Vytvoříme Head release 

New Head release
 * Založíme podadresář release/<module>/head
 * Vložíme do něj počáteční strukturu adresářů/souborů dle konfigurace
   * vytvořit lokální temp adresář, v něm
   * svn checkout
   * copy files
   * svn add
   * vytvořit svn head externalsy podle konfigurace
   * svn commit
 * Zopakujeme sken, aktualizujeme UI



Nepotřebujeme templaty, Head release poslouží jako template (externalsy jsou v něm napojené na HEAD trunku).
Z Headu vytváříme Candidate prostou svn kopií se zapnutím pinováním.


Všechny externalsy dáváme na root folder dané oblasti (releases/IG/Head).

Na jejich editaci použijeme TortoiseProc
  TortoiseProc.exe /command:properties /path:"file:///D:/Work/svn/xxx/repo/releases/IG/Head" /property:svn:externals

# Vytvoření kandidáta z Headu
Potřebujeme kořenové externalsy převést na "pinned to peg revision"
Bude možné použít TortoiseProc?
  TortoiseProc.exe /command:copy /path:"file:///D:/Work/svn/xxx/repo/releases/IG/Head" /url:"file:///D:/Work/svn/BIST/repo/releases/IG/Candidate/2.0.2"
POZOR! Pokud to děláme přímo v repozitáři (ne ve WC), nenabídne to napinování externalsů.

Zde má smysl udělat podporu v toolu "Make candidate".
  - zeptá se na jméno kandidáta (např. "2.0.1")
  - udělá svn copy Head Candidate/2.0.1 (to zkopíruje externalsy jak jsou, tj. ve stavu trunk HEAD)
  - pozmění kořenové externalsy tak, že každý z nich napinuje (pokud ještě není) na konkrétní revizi
    - pokud to byl trunk HEAD, napinuje ho
      - najde head revizi pro každý z nich
         - převede externals reference na kompletní URL
	     - zeptá se přes svn info na číslo revize
      - přidá peg revision
      - uloží nové externals
	- pokud to byl peg rev pinned externals
	  - ponechá
	- pokud to byl branch external (pozná ze tak že v jeho jméně se vyskytuje "branches"), napinuje ho
      - stejně jako u trunk
	- pokud to byl tag external (pozná ze tak že v jeho jméně se vyskytuje "tags")
      - ponechá v jeho HEAD verzi, předpokládá, že tag je neměnný a tedy HEAD tagu se nikdy nezmění
	  
	
	
# Vytvoření final z kandidáta
Potřebujeme kořenové externaly převést na "tag" externalsy. Tagy musíme u každého externalsu nějprve vytvořit.
 - zeptá se na jméno final releasu
 - udělá svn copy Candidate/2.0.1 Final/2.0.1 (zkopíruje externalsy jak jsou, tj. v peg rev pinned stavu)
 - pro každý kořenový external
   - pokud to byl trunk, zkopíruje ho (svn copy) do tags/2.0.1 a pozmění externals na tag HEAD
     - pokud tag toho jména už existuje, vypíše varování, ale pokračuje
   - pokud to byl pinned, zkopíruje (svn copy) konkrétní revizi do tags/2.0.1 a pozmění externals na tag HEAD
     - pokud tag toho jména už existuje, vypíše varování, ale pokračuje
   - pokud to byl tag external (pozná ze tak že v jeho jméně se vyskytuje "tags")
      - ponechá v jeho HEAD verzi, předpokládá, že tag je neměnný a tedy HEAD tagu se nikdy nezmění
	  - ALTERNATIVA (zatím nerealizovat)
	    - vytvoří tag nového jména zkopírováním head stavu existujícího tagu
        - pokud tag toho jména už existuje, vypíše varování, ale pokračuje
		- jde o duplikát tagu, může být spíš matoucí, ztratí se tím jasně viditelná vazba na origoš tagu (který tam mohl být použit z nějakého důvodu záměrně)



# Přelinkování kandidáta na jinou revizi sdíleného zdroje
Nastane například po commitu změny do kandidáta pomocí tortoiseSVN. TortoiseSVN provede update na verzi z trunku a přepinuje kandidáta na novou verzi trunku.
Můžeme vynutit i hromadně, ale proč, když stejného výsledku dosáhneme vytovřením nového kandidáta z headu?
Po jednom to lze udělat i ručně z TortoiseSVN dialogu pro editaci properties.
Není tedy potřeba prakticky žádná speciální podpora z toolu. Snad jen rychle otevřít seznam externalsů (sdílených zdrojů) pro daný release daného modulu.


# Je pegged external to pravé ořechové?
Pegged externaly dovolují udělat commit zpět do trunku a ani o tom nikomu neříct. Příští svn update (na úrovni kde je external prop hostována) vrátí revizi na původní hodnotu.

Bezpečnější je namísto pegged externalu udělat external na branch sdíleného zdroje, třeba něco jako shared/IG/Bin/All/branches/canidate/2.0.1.
Commity sem půjdou vždy jen do brache a nikdy se samy kouzelně nedostanou do trunku (tam jedině mergem - záměrná a vědomá operace)
SVN update na branchovém externalsu nikdy nezmění working copy na něco starého.
Na branchi je  to daleko intuitivnější...


Candidate release vyrábět jako branch sdíleného zdroje (ne tedy jako pegged revision - ta je více matoucí)
  trunk => branches/candidate/2.0.1

Final release vyrábět jako kopii aktuální verze zdroje - ať už kandidátního branche, nebo přímo trunku
  trunk  => tags/final/2.0.0
  branches/candidate-2.0.1 => tags/final/2.0.1

Změny z kandidátního branche zpět do trunku předávat pomocí merge
  - v trunkovém WorkingCopy zvolíme Merge a namergujeme rozsah revizí z příslušné branches/....

Při "Make Candidate" bychom si mohli vybrat, jakého typu ten kandidát bude - zda peg pnned, nebo branched...
  "Make candidate (pinned to trunk)" - commits affect trunk directly (unsafe, use witch caution!)
  "Make candidate (branch)" - commits do not affect trunk, safe, changes can be merged to trunk

Tag argument ReleaseMakeru 


Operace nad releasama
 - zkopíruj aktuální stav pod nové jméno
   - obyčejné svn copy release adresáře s identickým nastavení externalsů
   - obvykle není užitečné samo o sobě, musí být doplněno přebudováním externalsů
 - smaž  

V rámci jednoho pojmenovaného releasu by bylo vhodné stav jeho externalsů neměnit, aby se v tom dalo vyznat.
To nám nezabraňuje komponovat release z různých variant externalsů. Dopředu ale nevíme, varainty exetrnalsů chceme měnit i za běhu.

Varianty releasů
  - Head
    - Všechno na trunk latest
	- Commity přímo do trunku
	- Vysoce nestabilní prostředí (odkudkoliv může přilétnout nežádoucí změna)
	- Zároveň slouží jako template pro tvorbu ostatních typů releasů
	
  - Integrační
    - Vyžadovány rychlé commity integrovaných modulů do jejich trunk verze, zatímco většinu ostatních chceme neměnnou
	- Většina zdrojů je v peg-pinned trunk režimu
	- Zdroje měněné integrací (konfigurace, binárky) jsou
	   - buď rovnou na trunk HEAD,
	   - nebo trunk-peg ale WC se při první změně updatne na head
	      - pozor zde při svn update hrozí návrat ke staré peg verzi
		  - po každém commitu vyžaduje změnu pegu v externalsu

  - Kandidát (testovací)
	- Vyžaduje se jednoduchost (nemění se nečekaně pod rukama při svn update) a bezpečnost užívání (zabraňuje přímé změně trunku)
    - Commity lokálních změn jen vyjímečně
	- V samostatné větvi integrovaných modulů
	- Případné provedené změny jdou do větve, odkud se musí integrovat zpět do trunku pomocí svn merge
	
 - Finální
    - Vyžaduje se naprostá neměnnost (svn update nesmí nic poměnit, svn commit se musí vzpěčovat)
	- Commity lokálních změn se nědělají vůbec
	- V samostatném tagu integrovaných modulů (TortoiseSVN varuje před commitem do tagu)

Vytváření releasů
  - Head => Integrační
     - Nalinkuje na (trunk peg) všech sdílených zdrojů
  - Head => Kandidát
     - U všech sdílených zdrojů vytvoří branch se jménem kandidáta (branches/candidate/2.0.1) z trunk@HEAD
	 - Nalinkuje na tuto branch
  - Integrační => Kandidát
     - U všech sdílených zdrojů vytvoří branch se jménem kandidáta (branches/candidate/2.0.1) z peg-revize (trunk@254)
	 - Nalinkuje na tuto branch
  - Kandidát => Final
     - U všech sdílených zdrojů vytvoří tag se jménem releasu (tags/final/2.0.1) z HEAD kandidátské branche (branches/candidate/2.0.1@HEAD)
	 - Nalinkuje na tento tag
  - Head => Final
     - U všech sdílených zdrojů vytvoří tag se jménem releasu (tags/final/2.0.1) z HEAD trunku (trunk@HEAD)
	 - Nalinkuje na tento tag



Operace nad sdílenými zdroji
  - vytvoř branch z aktuálního stavu trunku@HEAD
  - vytvoř branch z aktuálního stavu pegovaného trunk@254
  - vytvoř tag z aktuálního stavu trunk@HEAD
  - vytvoř tag z aktuálního stavu pegovaného trunk@254
  - vytvoř tag z aktuálního stavu branch@HEAD
    

Operace nad externalsama
  - trunk@HEAD => trunk@254
  - trunk@254 => branches/candidate/2.0.1
  - branches/candidate/2.0.1 => tags/final/2.0.1



Kopírování releasu vyžaduje
  - srcUrl
  - destUrl

Operace nad sdíleným zdrojem vyžaduje
  - původní external
  - co z něj udělat
     - head
	 - peg
	 - branch - vyžaduje jméno
	 - tag - vyžaduje jméno

Pokud branch nebo tag už existuje, co pak? Jak to může vzniknout?
  - Požadujeme omylem již existující jméno releasu, nechceme nic přepsat.
  - Záměrně chceme předefinovat existující release na nějaký nový obsah.

V současném stavu použijeme existující branch/tag sdíleného zdroje.
  - To je OK jen pokud se záměrně vracíme ke starému releasu.
  - Není OK pokud jsme chtěli úplně nový (chybně zadané kolizní jméno)
  - Není OK pokud jsme chtěli předefinovat starý release

Potřebujeme předem prověřit, zda některý z branchů/tagů již existuje, a nechat uživatele rozhodnout.
Tedy nejprve provést něco jako "dry run" nebo "check" aniž bychom něco měnili, jenom při tom zkontrolujeme, zda cíle už náhodnou neexistují.
Má smysl hlavně u Branch/Tag požadavků, u jiných nedochází k vytváření ničeho nového.
Taky u kopírování přes již existující.
Dry run tedy namísto SVN copy provede SVN info na destUrl a pokud to již existuje, vrací False.
=> Samostatná checkovací metoda
 - prověří zda již existuje release daného jména
 - prověří zda u každého se sdílených zdrojů existuje brang/tag daného jména (jeno u PinType Branch/Tag)
 - vrací False pokud něco z toho existuje, a k tomu seznam kde všude by byla kolize
Uživateli zobrazíme varovný dialog, že už něco z toho existuje.
Pokud zvolí "force", při svncopy nejprve ověříme, zda cíl již existuje, a případně jej prvně smažeme.
=> Copy metoda potřebuje příznak "force"

# Linkování Installs na releasy

Extrahovat externalsy z aktuálního installs a zobrazit dole.

Čudlík co do instalace nalinkuje aktuálně zvolený release aktuálního modulu

* Sestaví externals:
  * Target: <module>
  * Link:  ^/<release>
* Přepíše existující (stejný Target).
* Pokud Target neexistuje, nedovolí nalinkovat (komponenta se musí přidat ručně - automaticky by to bylo příliš nebezpečné).
* Pokud Target již existuje a je jiný, varuje že se přelinkovává na jinou verzi.



