# Flappython 🐦

## Twist Name
**Random Gravity Flip**

## One Sentence Description
Gravity randomly flips direction every few seconds, forcing the player to constantly adapt their movement and spatial awareness.

## How It Works
- Every 3–7 seconds, `Physics2D.gravity` is negated, instantly pulling the bird in the opposite direction
- 1 second before each flip, a warning plays — the arrow image smoothly rotates 180° to show the new gravity direction, the "GRAVITY FLIPPING!" text bounces onto screen, and the screen pulses orange
- On flip, the bird's sprite is flipped vertically so it always appears upright relative to gravity
- The jump input automatically reverses direction to match the current gravity, so Space always pushes the bird *away* from the current pull
- If the bird flies off the top or bottom of the screen, death is triggered just like hitting a pipe

## Why It Fits Flappy Bird
- Flappy Bird's core challenge is precise, rhythmic tapping — flipping gravity completely disrupts that rhythm and forces the player to re-learn timing on the fly, dramatically raising the skill ceiling
- The narrow pipe gaps become twice as deadly when gravity is unpredictable, keeping the tension high without changing any level design
