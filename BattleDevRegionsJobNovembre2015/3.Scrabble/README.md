# 3.Scrabble

## Enonc�

Votre grand-m�re vous invite � jouer au Scrabble. 



Pour simplifier, on va consid�rer qu'au Scrabble un mot a pour valeur la somme des valeurs des lettres qui le composent. Vous souhaitez r�aliser un outil qui vous aidera � jouer et qui calcule la valeur des mots contenus dans un dictionnaire.

### Format des donn�es

__Entr�e__
Ligne 1 : un entier N compris entre 1 et 100 repr�sentant le nombre de mots du dictionnaire.

Ligne 2 : 26 entiers s�par�s par des espaces repr�sentant pour chaque lettre de A � Z le nombre de points qu'elle rapporte.

Lignes 3 � N + 2 : un mot en lettres capitales contenant au plus 7 lettres.



__Sortie__
Deux entiers S et L s�par�s par un espace. S repr�sente le score maximal des mots contenus dans le dictionnaire. L repr�sente la longueur du mot le plus court contenu dans le dictionnaire r�alisant ce score maximal.