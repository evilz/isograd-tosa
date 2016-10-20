# 2.Snake (Phase 1)
![](CTSTFR0062.png)  
**Enonc�**  

Sur les premiers t�l�phones, on trouvait le jeu du serpent. Pour simplifier on va consid�rer que le serpent se prom�ne simplement et qu'il conserve toujours la m�me longueur.  

Le serpent ne peut pas faire marche arri�re s'il fait un mouvement dans un sens, il ne peut pas faire juste apr�s un mouvement dans le sens oppos�. Le serpent ne peut pas non plus se mordre, c'est � dire qu'apr�s un mouvement, sa t�te ne peut pas �tre sur une partie de son corps.  

Le but de ce challenge est de d�terminer o� se trouve la queue du serpent apr�s une s�rie de mouvements.  

Exemple : le serpent part de la position horizontale (figure du haut), sa t�te fait le mouvement Droite->Bas->Droite->Bas->Bas->Bas->Droite. Il va se retrouver dans la position de la figure du bas. Si l'on consid�re que la coordonn�e en haut � gauche est (0,0), la queue se trouvera alors en (6,1).  
![](CTSTFR0062-1.png)  

**Format des donn�es**  

__Entr�e__  
Ligne 1 : un entier **N** entre _2_ et _50_ repr�sentant la taille du serpent. On suppose que le serpent part de la position horizontale, il s'�tale donc entre la position (0,0) et la position (**N**-1,0)  
Ligne 2 : un entier **P** compris entre 1 et 500 repr�sentant le nombre de mouvements de la t�te du serpent.  
Ligne 3 � **P** +2 : une lettre majuscule comprise dans _D, G, H, B_ pour repr�senter un mouvement de la t�te du serpent (Droite, Gauche, Haut, Bas). Le serpent ne sortira jamais du cadre et la t�te du serpent ne peut pas se d�placer vers une case qui serait occup�e par une partie de son corps apr�s le mouvement.  

__Sortie__  
Deux entiers s�par�s par un espace repr�sentant la position finale de la queue du serpent. La premi�re coordonn�e est la coordonn�e horizontale et la seconde coordonn�e est la position verticale. Dans l'exemple ci-dessus, la sortie doit �tre 6 1.  
