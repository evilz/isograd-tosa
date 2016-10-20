using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleDevRegionsJobMars2016._3.three
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            
            Enoncé

Le Pipotron est un générateur automatique de phrases qui permet de facilement meubler la conversation. 
Le principe est que la phrase est conçue en ajoutant plusieurs composants les un derrières
les autres et en ajoutant un espace entre chaque composant. Chaque composant est tiré au hasard.
Par exemple, dans un Pipotron générant des phrases à 3 composants, on a une liste de possibilités 
pour le 1er composant, une liste de possibilités pour le 2ème composant et une liste de possibilités
pour le 3ème composant. 
On tire au hasard un élément de la première liste, un élément de la seconde, un élément de la 3ème,
on les met bout à bout en les séparant par des espaces et on obtient une phrase pleine de sens.

On peut trouver des exemples ici :
- http://richard.geneva-link.ch/excusotron.html
- http://www.lepipotron.com/
- http://www.chateauloisel.com/humour/pipotron.htm

L'objectif de ce challenge est de déterminer si une phrase est un Pipotron.

Il n'y as pas de contrainte de complexité sur l'algorithme.

Format des données

Entrée
Ligne 1 : un entier n compris entre 3 et 5 représentant le nombre de composants du Pipotron.
Ligne 2 : n entiers séparés pas des espaces représentant le nombre de chaînes possibles pour chaque composant 
du Pipotron. On nommera ces entiers P1,P2...Pn. Et on appellera T la somme P1 + P2 +...+ Pn.
Ligne 3 à T + 2 : Les chaines possibles pour chaque composant du Pipotron. 
Chaque chaîne contient entre 2 et 150 caractères non accentués et peut contenir des majuscules et des ponctuations.
Les P1 premières chaînes correspondent au premier composant puis de P1+1 à P1 + P2, les chaînes du second et ainsi de suite.

            Ligne T + 3: un entier Q représentant le nombre de phrases à vérifier.
Ligne T + 4 à T + 3 + Q : une phrase comprenant entre 1 et 750 caractères qui peut être ou non un Pipotron.

            */
           // var input = Console.In;
            var input = File.OpenText(@"C:\Users\Vincent\Documents\GITHUB\isograd-tosa\BattleDevRegionsJobMars2016\3.three\samples\input2.txt");

            // READ COUNT
            var count = int.Parse(input.ReadLine());

            var ints = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            // READ LINES of INTs

            List<List<string>> part = new List<List<string>>();
            foreach (var i in ints)
            {
                var list = new List<string>();
                part.Add(list);
                for (int j = 0; j < i; j++)
                {
                    list.Add(input.ReadLine());
                }
            }

           
            var countPhrases = int.Parse(input.ReadLine());

            // READ LINES of string
            var phrases = Enumerable.Range(0, countPhrases)
                .Select(i => input.ReadLine())
                .ToArray();

          
            var result = 0;
           foreach (var p in phrases)
           {
               var current = p;
                foreach (var subPart in part)
                {
                    var isOk = false;
                    foreach (var sub in subPart.OrderByDescending(s => s.Length))
                    {
                        if (current.StartsWith(sub))
                        {
                            current = current.Substring(sub.Length);
                            current = current.TrimStart();
                            isOk = true;
                            break;
                        }
                    }
                    if(!isOk)
                        break;
                  
                }
               if (current.Length == 0)
                   result++;

            }

          //  Utils.LocalPrint(count.ToString());
          //  Utils.LocalPrintArray(new List<object>());

            Console.WriteLine(result);

        }
        
    }
}
