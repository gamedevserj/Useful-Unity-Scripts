using UnityEditor;
using UnityEngine;
using System.IO;
namespace GDS
{
    public class CreateFolders : EditorWindow
    {
        public string gameFolderName = "MY_AWESOME_GAME";

        public Folder[] folders = new Folder[] {
            new Folder("Animations"),
            new Folder("Audio", new string[] { "Music", "Sounds"}),
            new Folder("Images", new string[]{ "Sprites", "Textures"}),
            new Folder("Materials"),
            new Folder("Models"),
            new Folder("Prefabs"),
            new Folder("Scenes"),
            new Folder("Scripts", new string[]{ "Managers", "Utilities"}),
            new Folder("Shaders")
        };

        [MenuItem("Assets/Create Folders")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<CreateFolders>("Create Folders");
        }

        void OnGUI()
        {
            ScriptableObject scriptableObject = this;
            SerializedObject serializedObject = new SerializedObject(scriptableObject);

            EditorGUILayout.Space(30);
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
                Directory.CreateDirectory(path + folders[i].folder);
                if (folders[i].subFolders.Length > 0)
                {
                    for (int k = 0; k < folders[i].subFolders.Length; k++)
                    {
                        Directory.CreateDirectory(path + folders[i].folder + "/" + folders[i].subFolders[k]);
                    }
                }
            }
            AssetDatabase.Refresh();
        }
    }

    [System.Serializable]
    public class Folder
    {
        public string folder = "";
        public string[] subFolders = new string[] { };

        public Folder()
        {}
        public Folder(string f)
        {
            folder = f;
        }
        public Folder(string f, string[] subF)
        {
            folder = f;
            subFolders = subF;
        }
    }
}