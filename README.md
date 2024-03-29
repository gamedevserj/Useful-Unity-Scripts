# Useful Unity scripts

### Content
#### [Create folders](#create-folders-1)
#### [Rename animation clips](#rename-animation-clips-1)
#### [Scale animation curve](#scale-animation-curve-1)
#### [Swiping script](#swiping-script-1)

## Create folders

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/UsefulUnityScripts/CreateFoldersWindow.jpg">

Creates a number of folders to help with a new project setup
To use go to Tools/Create Folders

In the opened window enter the name of your game and add/remove folders and subfolders

Press 'Create' button and your directories will be created

## Rename animation clips

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/UsefulUnityScripts/AnimationClips.gif">

Automatically renames animation clips to exclude armature name (in case of import from Blender) or renames Mixamo animations using the file name. Names are changed both in the asset itself and in the animation import tab in the inspector.

**RenameAnimationsOnImport.cs** renames clips automatically on import. If you already have assets in the project you can either select them and hit reimport or go to Tools/Rename Animations and add objects with animations that needs renaming.

Note that changing the "Source Take" in the animation import tab might break the changes.

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/UsefulUnityScripts/AnimationClipsTab.png">

## Scale animation curve

<img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/UsefulUnityScripts/CurveOriginal.png" height="256"> <img src="https://raw.githubusercontent.com/gamedevserj/Images-For-Repo/main/UsefulUnityScripts/CurveScaled.png" height="256">

Allows scaling and normalization of animation curves retaining the tangent values.

## Swiping script

Contains basic swiping functionality that detects swipes in 8 directions. Split into separate versions that work in the Editor and on mobile devices.
