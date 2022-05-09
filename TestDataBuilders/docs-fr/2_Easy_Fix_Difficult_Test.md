# Correction facile, test difficile

![A pipe fixed with wrenches](images/quick-fix.jpg)

*[Image Source](https://pixabay.com/photos/plumbing-pipe-wrench-plumber-840835/)*

## Voici l'application

### Qu'est-ce qu'elle fait?

Nous possédons une société qui vend des livres on-line dans plusieurs villes à travers le monde. 
Pour gérer nos commandes, nous avons développé un système avec 2 portails :

#### 1. Le portal client

Ce portail fournit à nos clients les fonctionnalités pour chercher et commander des livres. 

Le worflow de commande se présente comme suit : 
1. Les clients ajoutent les livres qu'ils veulent dans leur panier.     
1. Puis ils valident leur panier.
1. Lors de la validation, notre système doit générer une facture avec les propriétés suivantes : 
    1. Les taxes avec règles de réduction doivent être appliqués pour chaque livre du panier
    2. Le montant total de la facture doit être la somme des montants des livres (après taxe) du panier
    3. La devise de la facture correspond à la devise du pays
1. La facture est envoyée au client et une copie est sauvegardée dans notre repository pour référence future   

> 💡 Tip: Il est important de noter que chaque pays a ses propres taux de taxe et règles de réduction. 
> Vous trouverez le tableau de ces règles ci-dessous.  
 
#### 2. Le portail de reporting

Le second portail est utilisé par les administrateurs pour générer des rapports des ventes à travers le monde. 

Le rapport doit inclure les informations suivantes : 
1. Somme cumulée de tous les montants des factures expédiées
1. Le décompte des factures traitées
1. La devise du rapport est le dollar américain (USD) 

### Pays, Devises, Langue, Taux de taxe et règles de réduction   

| Pays          | Devise            | Langue    | Taux de change avec l'USD  | Taux de taxe | Règles de réduction des taxes                             | 
| :-------------|:-----------------:| :--------:| :-------------------------:|:------------:|:---------------------------------------------------------:|
| USA           | USD               | English   | 1.0                        | 15%          | Réduction de 2% sur les romans (Novels)                   |  
| France        | Euro              | French    | 1.14                       | 25%          | Pas de réductions                                         | 
| UK            | Pound Sterling    | English   | 1.27                       | 20%          | Réduction de 7% sur les romans                            |
| Spain         | Euro              | Spanish   | 1.14                       | 10%          | Suppression des taxes pour les livres en langue étrangère |  
| China         | Renminbi          | Mandarin  | 0.15                       | 35%          | Suppression des taxes pour les livres en langue étrangère |
| Japan         | YEN               | Japanese  | 0.0093                     | 30%          | Pas de réduction sur les taxes                            |
| Australia     | Australian Dollar | English   | 0.70                       | 13%          | Pas de réduction sur les taxes                            |     
| Germany       | Euro              | German    | 1.14                       | 22%          | 5% de réduction sur les livres écrits en allemand         |  


### Repository

Le repository est la base de données ou nous enregistrons les copies de toutes les factures expédiées.
Il est défini via une interface avec 2 méthodes :
1. AddInvoice: Ajoute une facture dans la base de données du repository 
1. GetInvoiceMap: Renvoie toutes les factures disponibles dans une Map

Cette interface nous permet d'avoir différentes implémentations de notre base de données (Json, InMemory, Relational, NoSql, etc). 

Pour cet atelier, nous avons écrit une implémentation JSON de cette interface
([JsonRepository.cs](../Application/Storage/JsonRepository.cs)). 
Cette implémentation simpliste stock les données au format JSON dans un fichier [file](../Application/Storage/repository.json) 
dans le répertoire Storage.  

> 💡 Tip: Lire le fichier repository.json peut vous aider à comprendre la structure du code plus rapidement.  

A l'initialisation, la classe parse le fichier JSON et charge les données dans une Map.
 
Le singleton MainRepository renvoie le repository actuellement configuré.

## Avec un bug dedans !

Nous avons remarqué que certaines valeurs générées par le rapport étaient fausses. 

| Report                                  | Actual | Expected | 
|:---------------------------------------:|:------:|:--------:| 
| The total number of books sold          | 16     |  16      |
| The total number of issued invoices     | 6      |  6       |
| The total amount of all invoices in USD | 1016.04|  424.57  |

Heureusement, nos supers équipiers nous ont donné des pistes sur l'origine du problème:

> C'est comme si les taux de conversion et les réductions de taxes n'avaient pas été appliquées.
> [L'expert du domaine]

> C'est bizarre parce que le code correspondant exuste dans les classes TaxRule et CurrencyConverter!
> [Un développeur sénior]

## Votre mission est de corrigerer le bug et tester unitairement le code 

### 1. Description du bug

L'équipe reporting a fourni un scenario pour reproduire le bug !  
Dans le répertoire Storage, ils ont enregistré un fichier json ([repository.json](../Application/Storage/repository.json)) qui contient 
des données issues de factures de transactions existantes.

> 💡 Tip: Le montant total de chaque facture n'est pas inclus dans la liste. 

La classe principale ([Program.cs](../Application/Program.cs)) initialise
une instance de ReportGenerator puis appelle les méthodes pour récupérer les 3 valeurs du rapport: 
1. Nombre total de livres vendus
1. Nombre total de factures expédiées
1. Somme des montants totaux de toutes les factures

### 2. Tips pour corriger le bug

Après analyse, l'un de nos développeurs a pu identifier rapidement les bugs dans le code et nous à fourni les corrections !  

<details>
  <summary markdown='span'>
  Aperçu de la correction du bug dans Invoice.cs
  </summary>

  ```diff
      public double ComputeTotalAmount()
      {
          var totalAmount = 0.0;
  -       totalAmount = PurchasedBooks.Sum(book => book.TotalPrice);
  +       totalAmount = PurchasedBooks.Sum(book => book.TotalPrice * TaxRule.GetApplicableRate(Country, book.Book));
          return totalAmount;
      }
  ```

</details>

<details>
  <summary markdown='span'>
  Aperçu de la correction du bug dans ReportGenerator.cs
  </summary>

  ```diff
        public double GetTotalAmount()
        {
            var invoices = _repository.GetInvoiceMap().Values;
  -         var totalAmount = invoices.Sum(invoice => invoice.ComputeTotalAmount());
  +         var totalAmount = invoices.Sum(invoice => CurrencyConverter.ToUsd(invoice.ComputeTotalAmount(), invoice.Country.Currency));
            return totalAmount;
        }
  ```

</details>

### 3. Appliquez les correctifs puis annulez les changements

Une approche pour corriger le problème est la suivante: 
1. Appliquer les 2 patches ci-dessus dans le code dans les classes [Invoice](../Application/Purchase/Invoice.cs) et 
[ReportGenerator](../Application/Report/ReportGenerator.cs) 
1. Relancer la classe principale ([Program.cs](../Application/Program.cs))
1. Vérifier que les valeurs correctes sont affichées

Maintenant que nous savons ce qui a causé le problème, essayons de le corriger proprement.
Nous voudrions donc d'abord ajouter un test unitaire permettant de reproduire le problème.

Donc, on revert !

### 3. Ecrivez un test sur Invoice et seulement après corrigez la classe

Ajoutez donc un test à la classe
[Invoice](../Application/Purchase/Invoice.cs), constatez le problème et corrigez le problème.

Utiliser des mocks sur du code legacy n'est pas forcément une bonne idée. Le seul test double que l'on s'autorise est le 
[InMemoryRepository](../Application.Tests/Storage/InMemoryRepository.cs)

### 4. [BONUS] Ecrivez un test sur ReportGenerator et seulement après corrigez la classe

Si vous avez assez de temps, reproduisez l'étape 3 pour [ReportGenerator](../Application/Report/ReportGenerator.cs):
ajoutez un test, constatez le bug et corrigez-le.

## Mini Retro

Prenez quelques minutes pour discuter des côtés positifs et négatifs de cette approche.

Then compare them to what people usually say in
[Animation Guide.md](./Animation_Guide.md)

---
[Continue...](./3_Building_Test_Data.md)