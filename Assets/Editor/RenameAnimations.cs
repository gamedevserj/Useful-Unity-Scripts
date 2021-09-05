using UnityEditor;
using UnityEngine;

namespace UsefulUnityScripts
{
    public class RenameAnimations : EditorWindow
    {

        [SerializeField]
        public Object[] models;

        [MenuItem("Tools/Rename animations")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<RenameAnimations>("Rename animations");
        }
        void OnGUI()
        {
            ScriptableObject scriptableObject = this;
            SerializedObject serializedObject = new SerializedObject(scriptableObject);

            GUILayout.Space(30);

            SerializedProperty serializedModels = serializedObject.FindProperty("models");
            EditorGUILayout.PropertyField(serializedModels, true);
            
            serializedObject.ApplyModifiedProperties();

            if(GUILayout.Button("Rename"))
            {
                Rename();
            }
        }
        void Rename()
        {
            for (int i = 0; i < models.Length; i++)
            {
                string modelPath = AssetDatabase.GetAssetPath(models[i]);
                
                ModelImporter modelImporter = AssetImporter.GetAtPath(modelPath) as ModelImporter;
                ModelImporterClipAnimation[] animations = modelImporter.defaultClipAnimations;

                if (animations.Length > 1) // model has more than one animation on it
                {
                    for (int k = 0; k < animations.Length; k++)
                    {
                        string animationName = animations[k].name;
                        int lastSeparator = animationName.LastIndexOf("|") +1; // blender animations have | as a separator
                        animationName = animationName.Substring(lastSeparator);
                        animations[k].name = animationName;
                    }
                }
                else if(animations.Length == 1) // mixamo models usually have 1 animations on them
                {
                    animations[0].name = models[i].name; // setting animation to be the same as model name
                }
                modelImporter.clipAnimations = animations;
                modelImporter.SaveAndReimport();
            }
            AssetDatabase.Refresh();
        }
    }
}