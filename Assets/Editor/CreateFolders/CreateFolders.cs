using UnityEditor;
using UnityEngine;
using System.IO;

namespace UsefulUnityScripts
{
    public class CreateFolders : EditorWindow
    {
        public string gameFolderName = "MY_AWESOME_GAME";

        public Folder[] folders = new Folder[] {
            new Folder("Animations"),
            new Folder("Audio", new Folder[] { new Folder("Music"), new Folder("Sounds")}),
            new Folder("Images", new Folder[]{ new Folder("Sprites"), new Folder("Textures")}),
            new Folder("Materials"),
            new Folder("Models"),
            new Folder("Prefabs"),
            new Folder("Scenes"),
            new Folder("Scripts", new Folder[]{ new Folder("Managers"), new Folder("Utilities")}),
            new Folder("Shaders")
        };

        [MenuItem("Tools/Create Folders")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<CreateFolders>("Create Folders");
        }
        void OnGUI()
        {
            ScriptableObject scriptableObject = this;
            SerializedObject serializedObject = new SerializedObject(scriptableObject);

            GUILayout.Space(30);
            EditorGUILayout.TextField(gameFolderName);
            EditorGUILayout.Space();

            SerializedProperty serializedFolders = serializedObject.FindProperty("folders");
            EditorGUILayout.PropertyField(serializedFolders, true);
            serializedObject.ApplyModifiedProperties();

            if(GUILayout.Button("Create"))
            {
                Create();
            }
        }
        void Create()
        {
            string path = Application.dataPath + "/" + gameFolderName + "/";
            
            for (int i = 0; i < folders.Length; i++)
            {
                Directory.CreateDirectory(path + folders[i].folderName);
                if (folders[i].subFolders.Length > 0)
                {
                    for (int k = 0; k < folders[i].subFolders.Length; k++)
                    {
                        Directory.CreateDirectory(path + folders[i].folderName + "/" + folders[i].subFolders[k]);
                    }
                }
            }
            AssetDatabase.Refresh();
        }
    }
}