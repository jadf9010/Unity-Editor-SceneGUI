using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneGUIBezier))]
public class SceneGUIBezierInspector : Editor {
    void OnSceneGUI() {
        var script = (SceneGUIBezier) target;
        
        script.PointA = Handles.PositionHandle(script.PointA, Quaternion.identity);
        script.PointB = Handles.PositionHandle(script.PointB, Quaternion.identity);
        script.TangentA = Handles.PositionHandle(script.TangentA, Quaternion.identity);
        script.TangentB = Handles.PositionHandle(script.TangentB, Quaternion.identity);
        
        Handles.DrawBezier(script.PointA, script.PointB, script.TangentA, script.TangentB, Color.red, null, 5);
    }
}
