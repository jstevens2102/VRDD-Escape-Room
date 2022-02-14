# VRDD-Escape-Room
Virtual Reality Escape Room for VRDD II group project in Semester 2 2021.

### Created by:  
Cynthia Faulkner  
Georgia Stephens  
Jiayun Hu  
Nathan Hartman  
Wisely Lee  
Xintong Ying  
Zeheng Fan  
Jack Stevens  

### Installation:
1. Install Unity 2021.1.25 or later
2. Download the project by clicking the green 'Code' button up the top right and selecting 'Download ZIP'
3. Unzip the folder and move it to your Unity projects folder (or wherever you prefer)
4. Add the project to your project list using the 'Add' button in Unity Hub

## Changelog
Read below for complete changelog history.

### 10/11/2021
- Imported book puzzle assets.
- Imported Cynthia's sounds.
- Added sounds to scene interactions.
- Added puzzle completion sounds.
- Finished book puzzle.
- Added more grabbable objects.
- Added light switch controller which can disable/enable the lights.
- Added explosion effect to heater puzzle.
- Added ending scene with credits.
- Added scene controller to control transition to ending scene.

### 09/11/2021
- Imported Georgia's built scene.
- Adjusted lighting, added spotlight to flashlight.
- Added LEDs to water heater puzzle.
- Added colliders to most objects and made some small objects grabbable.
- Added a particle emitter to heater puzzle for door explosion.
- Adjusted lock key position.

### 01/11/2021
- Imported Zehang's basement decorations.
- Imported Georgia's hammer/nails.
- Imported Cynthia's draft noises.

### 27/10/2021
- Imported Nathan's water heater model.
- Started porting water heater puzzle to new model.

### 25/10/2021
- Added LED panel control script.
- Added placeholder puzzles to main scene and set up LED panel.
- Added mesh collider to basement model to avoid teleporting through scene.
- Imported keyhole object.
- Changed collision matrix to prevent teleport ray being stopped by grabbables.

### 23/10/2021
- Added Unity Events to Heater Puzzle.
- Implemented first version of key-lock puzzle.
- Implemented first version of torn label puzzle.

### 18/10/2021
- Imported Georgia's wine bottle with label and torn label assets.
- Imported Jiayun's bookcase and key.
- Implemented heater puzzle controller and fixed up valve controller.
- Added keypad sounds to keypad.

### 17/10/2021
- Imported Jiayun's cabinet, curtain and lamp.
- Imported Georgia's LED panel.
- Created first version of valve controller for heater puzzle.

### 11/10/2021
- Added barrel label, barrel tap and storage box packages.
- Updated project to Unity version 2021.1 to make use of URP 11.

### 19/09/2021
- Updated Wiseley's furniture models.
- Updated keypad prefab to fix weird offset.
- Imported keypad model and modified keypad UI to fit model size and layout.

### 13/09/2021
- Updated basement room model.
- Updated basement ceiling/door model.
- Imported v1 of Wisely's furniture package.
- Imported flashlight.
- Imported cabinet.
- Imported Nathan's lighting package.
- Added second UI interactor to left hand so both hands can be used.
- Finished script interaction of keypad.
- Imported basement staircase.

### 06/09/2021
- Experimented with physical hand colliders, causes some strange physics behaviours so have disabled it for now.
- Added first version of keypad prefab.
- Added UI interactor to right hand.
- Began working on script side of keypad interaction.
- Adjusted hand collider positions to make grabbing feel a bit more intuitive.
- Imported basement room model and created new scene for game level.

### 30/08/2021
- Imported Barrel Stand, Wine Bottle and Wine Rack packages to main project.
- Added v1 of button, slider and wheel interactable controls.

### 29/08/2021
- Added first version of drawer/cupboard + lever interactions created using Unity joints.

### 23/08/2021
- Implemented filtered socket interactor for tag checking, added example socket interactor to starter scene
- Created a tag called SocketablePuzzleObject

### 17/08/2021
- Imported wine barrel package.
- Added log files to .gitignore.

### 16/08/2021
- Added offset grab.
- Fixed teleport selection bug and made it so that only one teleport ray can be active at a time.

### 15/08/2021
- Removed unused controller models.
- Removed unused HandPresence script.
- Created a new script called XRInputListener that can be used to check for various inputs using the Action-based input system.
- Created a new InputActionAsset to avoid overwriting the default one when adding/editing controls.
- Added two new InputActions: 'Trigger' and 'Grip' to get the level of depression of the trigger/grip buttons.
- Teleport rays are now hidden by default and are re-activated when the XRInputListener script detects the 'Teleport Mode Activate' input from the controller and deactivated after the teleport finishes.
- Created a new HandPresenceInputListener script that animates the Oculus hand models based on the 'Trigger' and 'Grip' input values.

### 09/08/2021
- Converted project to Universal Render Pipeline.
- Upgraded teleport ray visuals using URP shader graph materials.

### 08/08/2021
- Created repository.
- Fixed input for teleporter ray.
