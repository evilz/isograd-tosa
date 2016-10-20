# 3.Scrabble

## Enonc�

Apr�s avoir int�gr� votre algorithme pr�c�dent dans une application install�e dans l'iPhone de votre grand-m�re, vous perdez un peu d'int�r�t pour ce jeu. En feuilletant un magazine, vous tombez sur un logigraphe.

![](CTSTFR0051-1.jpg)

Il s'agit d'une grille logique o� en lignes et en colonnes, on dispose du nombre de cases � noircir cons�cutivement. Par exemple, 4-2 signifie qu'il y a un bloc de 4 cases puis un bloc de 2 cases � noircir sur cette ligne. Idem en colonnes. Dans ce probl�me, il ne s'agit pas de r�soudre un logigraphe, mais d'en construire une grille pour un dessin donn�.

### Format des donn�es

__Entr�e__
Ligne 1 : deux entiers N et M s�par�s par des espaces, repr�sentant la hauteur et la largeur du dessin.

Lignes 2 � N + 1 : une ligne compos�e de M caract�res . (case blanche) et x (case noircie), repr�sentant une ligne du dessin.



__Sortie__
Les N+M instructions du logigraphe s�par�es par des espaces.

Chaque instruction est de la forme b1-b2-�-bk o� les bi sont des entiers repr�sentant le nombre de cases � noircir (dans le bon ordre).

L'ordre des instructions correspond aux N lignes puis aux M colonnes. Quand une instruction est vide utilisez la cha�ne ".".

Exemple : pour le logigraphe suivant,
![](CTSTFR0051.png)
Votre code doit renvoyer 1-1 1 3 1 2 1-1-1 2-1 1-2 .