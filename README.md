# FLAPPYTHON
## Twist Name
Random Gravity Flip
## One Sentence Description
Every few seconds gravity randomly flips direction, forcing the player to instantly adapt their flapping rhythm and spatial awareness to survive.
## How It Works
- A timer randomly triggers a gravity flip every 3 to 7 seconds.
- One second before the flip, a warning plays — the arrow image rotates 180° to show the new direction while "GRAVITY FLIPPING!" bounces onto the screen.
- The screen pulses orange as a final one-second alert before the flip occurs.
- On flip, `Physics2D.gravity` is negated and the bird sprite is flipped vertically to stay visually upright.
- The jump input automatically reverses so Space always pushes the bird away from the current gravity direction.
## Why It Fits Flappy
- Preserves the original one-tap control and endless scoring system while adding an unpredictable layer of challenge.
- The narrow pipe gaps become twice as punishing when gravity is unpredictable, raising the skill ceiling without changing any level design.
## Controls
- SPACE → Flap
- Mouse Click → Start
## Setup
1. Clone or download this repository
2. Open Unity Hub → click Add → select the `Flappython` folder
3. Let Unity import all assets, then open the main scene
4. Press Play to run the game in the editor

OR

1. Run `Flappython.exe`
2. Press SPACE to start flapping
3. Survive as long as possible and pass through pipes to increase your score
## Asset Credits
- Developed using Unity 2D
- UI text rendered using TextMeshPro
- Sprites sourced from [The Spriters Resource — Mobile Flappy Bird Miscellaneous Version 1.2](https://www.spriters-resource.com/mobile/flappybird/asset/59894/)

Developed by Vinayak More & Yash Choudhary
