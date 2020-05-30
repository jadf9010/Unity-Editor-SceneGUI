using UnityEditor;
using UnityEngine;
using System.Collections;

// Creates an instance of a primitive depending on the option selected by the user.
public class EditorGUILayoutPopup : EditorWindow
{
    private Color _color;

    public string[] options = new string[] { "Cube", "Sphere", "Plane" };
    public int index = 0;

    [MenuItem("EditorWindowExamples/Editor GUILayout Popup usage")]
    static void Init()
    {
        EditorWindow windowPopup = GetWindow(typeof(EditorGUILayoutPopup));
        windowPopup.Show();
    }

    void OnGUI()
    {
        index = EditorGUILayout.Popup(index, options);
        if (GUILayout.Button("Create"))
            InstantiatePrimitive();

        GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel);

        _color = EditorGUILayout.ColorField("Color", _color);

        if (GUILayout.Button("COLORIZE!"))
        {
            Colorize();

            ShowMessagePopup();
        }

        if (GUILayout.Button("Close!")) this.Close();

    }

    private static void ShowMessagePopup()
    {
        EditorWindowExample window = ScriptableObject.CreateInstance<EditorWindowExample>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowModalUtility();
    }

    void InstantiatePrimitive()
    {
        switch (index)
        {
            case 0:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Vector3.zero;
                break;
            case 1:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Vector3.zero;
                break;
            case 2:
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.position = Vector3.zero;
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = _color;
            }
        }
    }
}