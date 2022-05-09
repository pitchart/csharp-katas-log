# Mikado Method à la rescousse

![Mikado game sticks](../docs/images/mikado-sticks.jpg)

*[Image Source](https://pixabay.com/photos/mikado-play-puzzle-skill-colorful-1743593/)*

Les Test Data Builders vous permettent d'écrire de nouveaux tests plus rapidement une fois qu'ils sont disponibles.
Malheureusement, ils prennent encore plus de temps à écrire au départ !

C'est pas ça qui va nous aider à tester nos bugs dans du code legacy ! 

## Présentation de la  Mikado Method

La [Mikado Method](../docs/references/The_Mikado_Method.md) est une technique pour
réaliser de gros refactos, tout en continuant à développer des fonctionnalités.

Vous trouverez des ressources sur la Mikado Method 
[ici](../docs/references/The_Mikado_Method.md) ou sur les murs de la salle.

### Question/Réponse rapide

> En tant que groupe, quelles sont les 5 choses les plus importantes à retenir sur la Mikado Method ?

## Live code du début du Mikado Graph

Pour vous aider à démarrer, voici une démo de l'utilisation de la Mikado Method dans notre situation.

[![Video du début de la solution, en anglais](../docs/images/Testing%20legacy%20code%20with%20Mikado%20Method%20and%20Test%20Data%20Builders%20-%20YouTube.jpg)](https://www.youtube.com/watch?v=2wIb8kdxay4&feature=youtu.be)

### Video Screen Shots 

#### Mikado Graph

<details>
  <summary  markdown='span'>
  Screenshotdu Mikado Graph de la video
  </summary>
  <img src="../docs/images/MIkdaoScreenCapture.PNG" alt="Mikado Graph" />
</details>

#### Code Snippets 

<details>
  <summary markdown='span'>
  Code de la classe InvoiceTest de la video
  </summary>  

##### C#

  ```csharp
  using Xunit;
  using Application.Purchase;

  namespace Application.Tests
  {
      public class InvoiceTest
      {
          [Fact]
          public void Applies_Tax_Rules_When_Computing_Total_Amount()
          {
              Invoice oneNovelUsaInvoice = AnInvoice()
                  .From(USA)
                  .With(
                      APurchasedBook().Of(ANovel().Costing(2.99)))
                  .Build();

              Assert.Equal(2.99 * 1.15  *0.98, oneNovelUsaInvoice.ComputeTotalAmount());
          }
      }
  }
  ```

</details>


<details>
  <summary markdown='span'>
  Code de la classe NovelTestBuilder de la video
  </summary>

##### C#
  ```csharp
  using System.Collections.Generic;
  using Application.Domain.Book;
  using Application.Domain.Country;

  namespace Application.Tests
  {
      public class NovelTestBuilder
      {
          private double _price = 3.99;

          public NovelTestBuilder Costing(double price)
          {
              _price = price;
              return this;
          }

          public Novel Build()
          {
              return new Novel("Grapes with Wrath", _price, null, Language.English, new List<Genre>());
          }
      }
  }
  ```
  
</details>  

## DIY

Maintenant que vous avez une meilleure compréhension de la méthode, prenez un tableau blanc, un velleda, des post-its et
commencez votre propre graphe mikado pour ajouter un test.

![Photo of a whiteboard, markers and post-its, the material needed to draw a Mikado Method](../docs/images/workshop-material.jpg)

*[Image Source](https://pixabay.com/photos/workshop-pens-post-it-note-2209239/)*

### Supprimez les tests

Dans la vraie vie, vous suivriez les étapes

1. Utiliser la Mikado method pour ajouter un test avec les data builders
2. Corriger les bugs

Alors supprimons les tests !

### Utilisez la Mikado Method pour créer les Test Data Builders pour ajouter un test sur Invoice

On va d'abord se concentrer sur les tests d'[Invoice](../Application/Purchase/Invoice.cs).
C'est plus simple et réaliste étant donné le temps restreint.

Ecrivez vos tests comme si vous aviez déjà les builders et commencez à dessiner votre graphe Mikado.

Assurez vous que le projet continue à compiler tout le temps. Notez toutes les informations utiles que vous identifiez.

### Utilisez la Mikado Method pour créer les Test Data Builders pour ajouter un test sur Report Generator (Avancé)

Si vous avez le temps, répétez l'exercice sur la classe 
[ReportGenerator](../Application/Report/ReportGenerator.cs)

Vous devriez pouvoir réutiliser la plupart des builders déjà écrits.

Vous pourriez avoir besoin 
[d'autres types de builders](../docs/references/Test_Data_Builders.md) pour finir les tests.

## Retrospective

Faisons une rétrospective plus complète cette fois-ci.

1- Prenez quelques minutes pour écrire un ou 2 paragraphes pour répondre à ces questions :

> Quels sont les avantages et inconvénients de combiner les test data builders avec la Mikado Method ?
>
> Pour vous, quels sont les concepts et enseignements les plus importants de cette formation ?
> 
> Comment envisagez vous d'utiliser ce que vous avez appris ?

2- Est-ce que cet atelier a répondu à vos attentes?
> Retournez voir les notes que vous aviez écrites au début de l'atelier   

3- Lisez les à votre pair, discutez

4- Si vous voulez, proposez de les partager à tout le monde

5- Vous pouvez également consulter ce que les gens relèvent habituellement 
[ici](./Animation_Guide.md)

----
[Continue...](./5_Conclusion.md)
