using UnityEditor;
using UnityEngine;

public class EditorWindowExample : EditorWindow
{    
    [MenuItem("Examples/EditorWindow.ShowPopup")]
    static void Init()
    {
        EditorWindowExample window = ScriptableObject.CreateInstance<EditorWindowExample>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowModalUtility();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
        EditorGUILayout.LabelField("Updated by me", EditorStyles.wordWrappedLabel);

        GUILayout.Space(70);
        if (GUILayout.Button("Close!")) this.Close();
    }
}