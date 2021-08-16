# VRDD-Escape-Room
Virtual Reality Escape Room for VRDD II group project.

Steps to Install:
1. Install Unity 2020.3.15f2 (Latest LTS version)
2. Download the project by clicking the green 'Code' button up the top right and selecting 'Download ZIP'
3. Unzip the folder and move it to your Unity projects folder (or wherever you prefer)
4. Add the project to your project list using the 'Add' button in Unity Hub

## Changelog
Read below for complete changelog history.

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