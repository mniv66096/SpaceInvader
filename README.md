# SpaceInvader - Squint Interview
## Completion Time
I roughly spent 5 hours creating this mini-game. Below is an approximate breakdown

**First Hour:** Looking for the assets and tweaking them in the Editor

**1-4 Hour:** Finishing the basic gameplay: player input and movement, enemy spawn and movement, shooting, collision detection 

**4-5Hour:** Adding UI/sounds, creating the start scene, adding the local storing feature and playtest.



## How to Play

There are two modes: the traditional space invader style and FPS style. 

Use arrow keys to control the space movement and use "space" key to shoot the enemies.

I used the MVC design pattern: the input is handled on the `DesktopInputController` component. It is easier to write another InputController for other platforms while the main code structure remains unchanged.

## Local Storing 

I used the most straightforward way (PlayerPref) to track the highest score and the playtimes. I would use serialized int array to store the score for each game in the Application.persistentDataPath and read it via File.IO
