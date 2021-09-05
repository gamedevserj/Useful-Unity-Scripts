using UnityEngine;
using UnityEditor;

public class RenameAnimationsOnImport : AssetPostprocessor
{

    string nameSeparationCharacter = "|";// blender animations have | as a separator

    //renames clips in the inspector window (animation tab of the model)
    void OnPostprocessModel(GameObject g)
    {

        ModelImporter modelImporter = (ModelImporter)assetImporter;
        ModelImporterClipAnimation[] animations = modelImporter.defaultClipAnimations;
        
        if (animations.Length > 1) // model has more than one animation on it
        {
            for (int k = 0; k < animations.Length; k++)
            {
                string animationName = animations[k].name;
                int lastSeparator = animationName.LastIndexOf(nameSeparationCharacter) + 1; 
                animationName = animationName.Substring(lastSeparator);
                animations[k].name = animationName;
            }
        }
        else if (animations.Length == 1) // mixamo models usually have 1 animations on them
        {
            animations[0].name = g.name; // setting animation to be the same as model name
        }
        modelImporter.clipAnimations = animations;
    }

    //renames clips on the asset itself
    void OnPostprocessAnimation(GameObject g, AnimationClip clip)
    {
        if (!clip.name.Contains("mixamo.com"))
        {
            int lastSeparator = clip.name.LastIndexOf(nameSeparationCharacter) + 1; // blender animations have | as a separator
            string name = clip.name.Substring(lastSeparator);
            clip.name = name;
        }
        else
        {
            clip.name = g.name;
        }
    }
}