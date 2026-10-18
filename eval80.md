# Évaluation intermédiaire (80 %) – Nathan Schmid

## Synthèse

Le joueur se déplace horizontalement et lâche des noisettes. 8 ennemis de 4 « races » apparaissent sans se chevaucher et rebondissent sur les bords et entre eux. **Les noisettes ne touchent rien et ne sont jamais supprimées.** Il n'y a ni obstacles, ni tirs ennemis, ni score, ni fin de partie. Les races n'ont pas de comportement différent (seule la taille du TANK change). Le journal est très bien tenu, mais le rapport ne contient que 2 US.

## Points à améliorer d'ici au rendu final (30.10)

1. Collisions noisette/guêpe avec suppression, ≥ 10 ennemis, tirs ennemis, 5 feuilles (obstacles), score et fin de partie.
2. Encapsuler (champs privés `_x` + propriétés `X`).
3. Différencier réellement les races (vitesse, PV, points), ou les supprimer.
4. Rapport : toutes les US avec tests d'acceptance, puis conception, tests, IA et bilans.
5. Ajouter des tests unitaires
6. Déplacer les classes `Ennemi` et `TirJoueur` dans le dossier `Model`
