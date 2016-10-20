# 3.Distributeur de friandises (Phase 1)
![](CTSTFR0059.jpg)  

**�nonc�**  

Les distributeurs de friandises doivent faire face � toutes les situations possibles (stock �puis�, plus de pi�ces) afin de m�nager le service client de l'entreprise.  

En l'occurrence, vous devez programmer l'algorithme de rendu de monnaie de la machine, en veillant � rendre un **minimum** de pi�ces tout en respectant le stock de pi�ces s'y trouvant actuellement (si c'est possible).  

**Format des donn�es**  

__Entr�e__  
Ligne 1 : un entier **M**, repr�sentant le montant � rendre en euros. **M** est compris entre _1_ et _25000_.  
Ligne 2 : un entier **T**, le nombre de types de pi�ces se trouvant dans la machine. **T** est compris entre _1_ et _10_.  
Lignes 3 � **T**+2 : deux entiers **N** et **V** s�par�s par un espace, respectivement le nombre de pi�ces de ce type disponibles dans la machine et leur valeur unitaire en euros. **N** et **V** sont compris entre _1_ et _50_. Par ailleurs, il n'y a pas plus de 150 pi�ces dans la machine. Les lignes 3 � T+2 sont tri�es par ordre croissant de **V**.  

__Sortie__  
Un entier repr�sentant le nombre minimum de pi�ces que l'on peut rendre tout en respectant le montant demand�, ou bien la cha�ne de caract�res <span style="color: #5379AA;">IMPOSSIBLE</span> s'il n'est pas possible de rendre la monnaie.  
