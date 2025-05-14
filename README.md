# Zen Zone 0 – Architecture and Design

## Introduction
**Zen Zone 0** is a calming VR space created for COMP 565. It offers relaxing environments, immersive sounds, interactive games, and hidden easter eggs for discovery. Users navigate through themed islands using a VR carousel interface, each island providing a unique interactive experience designed to promote tranquility and engagement.

## Design Goals
- Minimize development complexity and effort
- Promote calmness and immersion
- Ensure interactivity and fun in games
- Intuitive user interface
- Integration of immersive, calming audio

## System Behavior
Zen Zone 0 launches with a **Main Menu** and allows users to explore themed islands via a rotating **carousel**. Navigation involves rotating the carousel with the trigger and double-clicking to enter a selected island. Settings, including sound adjustments, are accessible via the XR system on the user’s left wrist.

### Key Experiences:
- **Basketball**: Throwing into a hoop triggers effects
- **Baseball / Golf**: Hit into rings for rewards
- **Freeplay Balls**: Interactive objects with custom logo effects

### Featured Islands:
- **Maze Island**: Includes a maze and puzzle game with special effects as rewards
- **Icelandia**: A hockey game with scoring and custom effects
- **Beachland**: Features lightweight beach balls with unique physics behavior
- **Purple Fairy Island**: Unlockable easter egg leading to a secret scene
- **Hell (Easter Egg)**: Boss fight scenario with auto-defeat mechanics

Estimated memory usage is around 3.7 GB with low impact on CPU/GPU resources.

## Logical View
Defines the main functional components and their interactions.

### High-Level Components
- **Main Menu System**
- **Carousel Navigation**
- **Island and Game Logic**
- **Audio Management**
- **Visual/Reward Effects**
- **Easter Egg Mechanisms**
- **Settings and UI Controls**

### Example Interactions
- Trigger-based carousel rotation and selection
- Object interactions using VR input
- Puzzle solving on Maze Island
- Haptic feedback guiding easter egg discovery

## Process View
Main threads and processes include:
- **Main Loop**: Manages scene transitions and input
- **Interaction Handler**: Processes VR controller actions
- **Game Logic Threads**: Handle physics and scoring mechanics
- **Effect Manager**: Triggers and displays audio/visual effects

## Physical View
- Runs locally on VR-ready devices
- Built in Unity using XR framework
- Includes prefabs for potential multiplayer expansion (not active)

## Development View
- Developed using Unity Engine
- Structure includes scenes for each island and game experience
- Assets organized with Unity's Hierarchy and Inspector views
- Multiplayer prefabs are present but gameplay is single-player focused

## Use Case View
### Navigate to Island
- Launch game
- Use trigger to rotate carousel
- Double-tap trigger on desired island to enter

### Play Basketball
- Enter Basketball Island
- Pick up and throw the basketball
- Scoring triggers a visual effect

### Discover Easter Egg
- Approach large tree on Purple Fairy Island
- Grab initials etched on the tree to trigger glowing effects
- Completing the sequence opens a portal to Hell scene

---

© Zen Zone 0 | COMP 565 | Architecture and Design Document
