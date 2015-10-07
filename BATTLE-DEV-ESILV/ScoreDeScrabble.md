# Score De Scrabble

## Enoncé

Soit un jeu de données contenant une première ligne formée d’une séquence alternée de lettres et de nombres entiers positifs ou nuls écrits en décimal, séparés par des espaces. Par exemple "a 1 b 3 c 3 d 2 e 1 f 4". Chaque nombre correspond au score associé à la lettre qui le précède. Les lignes suivantes sont composées de mots. Par exemple :
a 1 b 3 c 3 d 2 e 1 f 4 g 2 u 1 
cafe 
button 
face
bad 
zebra 
bug
À chaque mot, on peut associer un score qui correspond à la somme des scores de chaque lettre tels qu’indiqués dans la première ligne. Si une lettre n’est pas présente dans cette première ligne, son score est de 0. Vous devez réaliser un programme qui lit un jeu de données et écrit sur la sortie standard les mots triés par ordre décroissant de score. Le tri doit être stable, c’est-à-dire qu’en cas d’égalité de score entre deux mots, ils doivent être écrits dans l’ordre qui était le leur en entrée.
Dans notre exemple les mots correspondent aux scores suivants :
cafe 3+1+4+1=9 
button 3+1+0+0+0+0=4 
face 4+1+3+1=9
bad 3+1+2=6 
zebra 0+1+3+0+1=5 
bug 3+1+2=6
La sortie attendue serait donc :
cafe
face
bad
bug
zebra
button


## Format des données

### Entrée
La première ligne est composée d’une séquence alternée de lettres minuscules et de nombres entiers positifs ou nuls écrits en décimal, séparés par des espaces, chaque lettre étant suivie d’un nombre. Les lignes suivantes sont composées de "mots", c’est-à-dire à dire de séquences de lettres minuscules (jusqu’au retour à la ligne).

### Sortie
Les lignes sont composées des "mots" lus en entrée, un par ligne, suivant l’ordre défini dans l’énoncé.