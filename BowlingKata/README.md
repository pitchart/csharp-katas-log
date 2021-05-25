# Bowling Game Kata
SOLID Principles | TDD | Experienced | Outside-In | Software-Design

## Règles du bowling
* Le jeu se déroule en 10 tours.
* A chaque tour, le joueur a 2 lancers pour faire tomber 10 quilles
* Le score d'un tour est le nombre total de quilles renversées, plus des bonus pour les spares et les strikes.
* Un spare est quand le joueur renverse les 10 quilles en deux lancers lors d'un tour.
    * Le bonus pour un spare est le nombre de quilles renversées par le prochain lancer.
* Un strike est quand le joueur renverse les 10 quilles lors du premier lancer de son tour
    * Dans ce cas, son tour est terminé
    * Le bonus pour un strike est la valeur des deux prochains lancers.
* Dans le dixième tour, un joueur qui réalise un spare ou un strike est autorisé à effectuer des lancers supplémentaires pour compléter le tour.
    * Cependant, pas plus de trois lancer ne peuvent être effectués au dixième tour
* La partie parfaite (que des strike) a un score total de 300 points


## Objectifs
Ecrire une classe Game qui a deux méthodes :
* void roll(int) qui est appelé à chaque fois qu'un joueur effectue un lancer. L'argument est le nombre de quilles tombées à ce lancer.
* int score() retourne le score total de la partie.

## Informations supplémentaires
* On considère que la méthode score ne sera appelée qu'à la fin de la partie
* On considère que le nombre de lancers effectués avant d'appeler la méthode score est toujous valide.
