# 3.Distributeur de friandises (Phase 1)
![](CTSTFR0059.jpg)  

**Énoncé**  

Les distributeurs de friandises doivent faire face à toutes les situations possibles (stock épuisé, plus de pièces) afin de ménager le service client de l'entreprise.  

En l'occurrence, vous devez programmer l'algorithme de rendu de monnaie de la machine, en veillant à rendre un **minimum** de pièces tout en respectant le stock de pièces s'y trouvant actuellement (si c'est possible).  

**Format des données**  

__Entrée__  
Ligne 1 : un entier **M**, représentant le montant à rendre en euros. **M** est compris entre _1_ et _25000_.  
Ligne 2 : un entier **T**, le nombre de types de pièces se trouvant dans la machine. **T** est compris entre _1_ et _10_.  
Lignes 3 à **T**+2 : deux entiers **N** et **V** séparés par un espace, respectivement le nombre de pièces de ce type disponibles dans la machine et leur valeur unitaire en euros. **N** et **V** sont compris entre _1_ et _50_. Par ailleurs, il n'y a pas plus de 150 pièces dans la machine. Les lignes 3 à T+2 sont triées par ordre croissant de **V**.  

__Sortie__  
Un entier représentant le nombre minimum de pièces que l'on peut rendre tout en respectant le montant demandé, ou bien la chaîne de caractères <span style="color: #5379AA;">IMPOSSIBLE</span> s'il n'est pas possible de rendre la monnaie.  
