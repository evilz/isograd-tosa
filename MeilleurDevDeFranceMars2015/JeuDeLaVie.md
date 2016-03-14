# Le jeu de la vie

## Énoncé

Ce challenge est basé sur le jeu de la vie dont vous trouverez les principes ici : http://fr.wikipedia.org/wiki/Jeu_de_la_vie.

Dans cette variante, à chaque étape :
- lorsqu'une cellule a une voisine vivante au-dessus et une voisine vivante à gauche : elle devient vivante ;
- lorsqu'une cellule n'a pas de voisine vivante ni au-dessus ni à gauche : elle meurt ;
- dans le reste des cas, elle conserve son état.

Vous devez indiquer le temps de survie de la population à partir d'une configuration initiale. C'est à dire le nombre d'étapes après lequel il n'y a plus de cellule vivante.

Par commodité, la configuration initiale sera décrite par une série de rectangles de cellules vivantes.

## Format des données

### Entrée

Ligne 1 : un entier N compris entre 1 et 1 000 représentant le nombre de rectangles.
Lignes 2 à N+1 : quatre nombres entiers x1 y1 x2 y2 chacun compris entre 1 et 1 000 000 et séparés par des espaces. Touts les points inclus dans le rectangle délimité par x1, y1 (coin haut-gauche) et x2, y2 (coin bas-droite) sont des cellules vivantes. En effet, les abscisses vont croissant vers la droite, et les ordonnées vont croissant vers le bas.

Il n'y aura pas plus de 1 000 000 de cellules vivantes au départ.

### Sortie
Un entier représentant le temps de survie de la population. Si la population survit indéfiniment, renvoyez -1.

## Exemple

![sample](https://raw.githubusercontent.com/evilz/isograd-tosa/master/TOSA/MEILLEUR-DEV-DE-FRANCE-MARS-2015/CTSTFR0034-3.png)

Cette génération, désignée sur l'image tout à gauche par le test de 3 rectangles suivant :

```
3
5 1 5 1
2 2 4 2
2 3 2 4
```
a une durée de vie de 6. 









