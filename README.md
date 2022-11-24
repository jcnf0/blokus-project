# Blokus study project
## The project
As part of our first year in the engineering school Ecole Centrale de Lyon, we worked, as a team of 6, on creating an application that allows to play the game Blokus (2v2 version) with/against AI or real players.
## Graphics
### Title screen

<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203803898-4b076e82-f876-4b1c-b749-eda786c02dd6.PNG" alt="title-screen" width="750"/>
</p>

### Tutorial

<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203805478-8cb39211-416c-469a-bc78-1c3089a408a4.png" alt="tutorial" width="750"/>
</p>

### Player selection screen

<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203805498-1244d24b-21ca-4514-acc6-d92226ad106d.PNG" alt="player-select" width="750"/>
</p>

### Example of an ongoing game

<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203805485-738620a7-4154-4137-9c39-6f338dd238ee.PNG" alt="ongoing-game" width="750"/>
</p>

## Artificial Intelligence

There are three levels of AI:  
  
**Easy** : The AI plays randomly  
**Intermediate** : The AI tries to play the hardest pieces to play  
**Difficult** : The AI follows a MinMax using an evluation function  

### Evaluation function

The evaluation function involves three complementary models that are combined together:  
  
**Naive** : The score is calculated by taking the weighted sum of the the different pieces. The weight is obtained using the following image. It is the ratio between the smallest covering rectangle (A<sub>ij</sub>) of the piece and the maximum of A<sub>ij</sub> of the pieces with the same amount of small squares (same i). 
<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203807197-d3c6ed63-e0f4-46f3-87d2-51b8a1b845e7.png" alt="aij" width="750"/>
</p>
  
**Micro** : The heuristic here is that by maximizing the amount of moves possible through the placement of a piece, the situation improves. The score is calculated by calculating the amount of corners available.  

**Macro** : The approach is to view the board as a whole and look at the tendency of the pieces. The score is calculated by taking the difference between the barycenters of the pieces of the AI and the closest opponent. If we want the AI to be aggressive, we want the difference to be as little as possible.

<p align="center">
<img src="https://user-images.githubusercontent.com/26343297/203811127-467c569c-3757-4f12-87b1-c0805667e233.png" alt="macro" width="750"/>
</p>  
