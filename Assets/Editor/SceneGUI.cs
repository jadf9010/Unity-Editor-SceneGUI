using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameObject))]
public class SceneGUI : Editor
{
    public static UnityEngine.Object objectSelected;
    public static SceneView currentSceneview;

    [MenuItem("Editor Tool GUI/Enable")]
    public static void Enable()
    {
        SceneView.duringSceneGui += OnScene;
        Debug.Log("Scene GUI : Enabled");
    }

    [MenuItem("Editor Tool GUI/Disable")]
    public static void Disable()
    {
        currentSceneview = null;
        SceneView.duringSceneGui -= OnScene;
        Debug.Log("Scene GUI : Disabled");
    }

    /// <summary>
    /// This Method is called when occurs an event in the unity scene
    /// </summary>
    private void OnSceneGUI()
    {
        if (currentSceneview != null)
        {
            objectSelected = ElementSelector.GetSelectedObject();
            if (objectSelected != null)
                Debug.Log(objectSelected.name);
            else
                Debug.Log("No Selected Object");
        }
        else
            objectSelected = null;
    }

    private static void OnScene(SceneView sceneview)
    {
        currentSceneview = sceneview;

        Handles.BeginGUI();

        RotationPanelLayout();

        Handles.EndGUI();
    }

    private static void RotationPanelLayout()
    {
        GUILayout.BeginArea(new Rect(20, 60, 550, 100));

        var rect = EditorGUILayout.BeginVertical();
        GUI.color = Color.yellow;
        GUI.Box(rect, GUIContent.none);

        GUI.color = Color.white;

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Rotate");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (objectSelected != null)
        {
            GUI.backgroundColor = Color.red;
        }
        else
            GUI.backgroundColor = Color.gray;

        if (GUILayout.Button("Left"))
        {
            if (objectSelected != null)
            {
                RotateLeft(objectSelected);
            }
        }

        if (GUILayout.Button("Right"))
        {
            if (objectSelected != null)
            {
                RotateRight(objectSelected);
            }
        }

        GUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();


        GUILayout.EndArea();
    }

    public static void RotateLeft(UnityEngine.Object target)
    {
        (target as GameObject).transform.Rotate(Vector3.down, 15);
    }

    public static void RotateRight(UnityEngine.Object target)
    {
        (target as GameObject).transform.Rotate(Vector3.down, -15);
    }
}