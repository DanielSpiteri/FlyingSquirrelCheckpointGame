# FlyingSquirrelCheckpointGame
# Top-Down Checkpoint Challenge

A simple top-down vehicle checkpoint challenge created in Unity.

The objective is to drive through five checkpoints in the correct order before the timer runs out.

## Instructions for Playing

### Controls

- W / Up Arrow - Move forward
- S / Down Arrow - Reverse
- A / Left Arrow - Steer left
- D / Right Arrow - Steer right

### Objective

Drive through all five checkpoints in the correct order before the timer reaches zero.

The next checkpoint is visually highlighted, and the current checkpoint progress and remaining time are displayed on screen.

Reaching all five checkpoints before the timer expires completes the challenge.

If the timer reaches zero first, the challenge is lost.

After winning or losing, vehicle movement is disabled and the Restart button can be used to restart the challenge.

## Completed Features

- Keyboard-controlled vehicle movement and steering.
- Five checkpoints that must be reached in the correct order.
- Visual highlighting of the next required checkpoint.
- On-screen countdown timer.
- On-screen checkpoint progress (0/5 to 5/5).
- Win condition after completing all five checkpoints.
- Loss condition when the timer reaches zero.
- Vehicle controls are disabled when the challenge ends.
- Restart button that resets the challenge.
- Vehicle movement speed is configurable through the Inspector.
- Vehicle turning speed is configurable through the Inspector.
- Starting time is configurable through the Inspector.

## Unfinished Items

None. All features specified in the task requirements have been implemented.

## Known Issues

No known issues at the time of submission.

## Design Decision

I chose to separate the gameplay functionality into three main scripts: VehicleController, Checkpoint, and GameManager.

VehicleController is responsible for vehicle movement and player input, Checkpoint handles checkpoint detection and visual highlighting, and GameManager manages the timer, checkpoint progression, UI, win/loss states, and restarting.

I chose this structure to keep the different responsibilities separated, making the code easier to understand, maintain, test, and modify.

The vehicle and environment also use simple Unity shapes rather than detailed models, as the focus of the task was on implementing the required gameplay functionality rather than visual polish or realistic vehicle physics.

## External Resources and AI Tools

ChatGPT was used as an AI assistance tool during development. It was used for guidance on structuring the project, implementing parts of the C# gameplay logic, and troubleshooting during development.

No external game assets were used. The vehicle, checkpoints, and environment were created using Unity's built-in primitives and components.

## Unity Version

Unity 6 (6000.0.53f1)