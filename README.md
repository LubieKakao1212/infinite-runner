# infinite-runner

## Gameplay Instructions

### Basic Info
- Player [White Square] will follow the horizontal position of the mouse cursor, with certain speed  
- Use the above to dodge falling obstacles [Brown and Green hotizontal tic-tacs] and catch [Powerups](#powerups)  [Gray, Cyan and Blue circles]
- When you have an active powerup you can use it with right mouse button
- You can have only one active powerup at a time
- Player starts with two shield charges which protect from incoming obstacles, you can gain more by collecting the [Shield Powerup](#powerups) 
- You can encounter [Random Events](#random-events) with random intervalas
- When you die your distance traveled will be displayed
- Be aware the game constantly speeds up!
- Have fun :)

### Powerups
- Dash [Cyan], an active powerup, when used uncaps player speed for a short perion of time
- Slowdown [Gray], an active powerup, slows the world by some amount for some time and than catches up the speed (I havent done calculations about what is the net gain of the world speed it may be positive or negative I don't know)
- Shield [Blue], a passive powerup, adds one shield charge

### Random Events
- Blackout, When this event happens first the lights will brighten as a warning thanthey will go out for a short time


## Known Issues
- When using Dash powerup player sometimes jitters around the coursor
- There is only one type of random event
- During impossibly late game, there is no way to loose because obstacles travel entier distance in one frame
- During even later game, there is an immence lag due to multiple obstacles spawning on the exact same frame

## Code Info
- I used DOTween, a nd some of my premade utilities int this project, premade utilities are marked wit a comment
- I used new Input System, Cinemachine was not needed (Packages I add to alost every project)
- Class SystemManager and everything related is unused, I was planning to use it but in the end I didn't need to, it sould still work though but I haven't tested it
- Modifiables could be improved, but it wasen't my priority
- There is a possibility to add more random events
- I made a fancy "glitchy" shader for world background
- Perspective related shaders are not used, it was a cool idea but it was harder to make than I expected

### Thats it
I hope I didn't forget to mention anything
