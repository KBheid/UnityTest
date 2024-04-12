# Project Goal
The goal of this project is to implement the look and functionality of the images found in the reference section.

## Reference images

**Image A**

![image](https://github.com/KBheid/UnityTest/assets/31446092/0edd0867-0c0f-4be9-a721-b13de5a23a01)

**Image B**

![image](https://github.com/KBheid/UnityTest/assets/31446092/2fd16270-2ade-4952-b448-9ae6e785d455)


## Goal functionality described

The functionality of Image A is as follows:
- The left button causes the lower image (key hole) to begin rotating.
- The right switch causes the key hole's rotation direction to switch - regardless of active rotation or not.
  - The right switch is activated only if the user clicks and drags upwards.
- The numbers above either control indicate how many times the respective control has been toggled.
- When the controls have been activated 10 times cumulatively, display Image B.

The functionality of Image B is as follows:
- The left button, labled `YES`, causes the scene to reset.
- The right button, labeled `NO`, causes the application to close.

# Implementation
The following section describes my implementation to achieve the goal.

## Design details
In order to write clean, maintainable and usable code, the code was written with the following in mind:

- Reusability
  - Decoupling
    - Making use of UnityEvents to drive functionality allows us to have fewer references between independent systems.
      - UnityEvents are utilized by both buttons (as typical), but also in the `TriggerAtValue` script, which is used in our demo to keep the running total of interactions before triggering the modal.
  - No assumed values
    - All functionality related values are exposed to the Unity inspector, such that components can be used in a variety of ways.
      - Most evident of this is the custom Switch (`DirectionSwitch.cs`) which allows custom tolerances of drag direction via the `threshold` field (visualized in Image C).
- Editor driven functionality
  - UnityEvents were also chosen in an effort to allow non-programmers to utilize the underlying code without knowledge of programming.
  - A custom Gizmo (found in `DirectionSwitch.cs`) was employed to assist in determining intended threshold values (as seen in Image C).

## Reference images for implementation
**Image C**
![testShowcase](https://github.com/KBheid/UnityTest/assets/31446092/3f232379-a617-4627-bf04-1432441ef3af)
