using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ElementSelector
{
    public static void UpdateComponentSelector()
    {

    }

    public static string GetSelectedPathOrFallback()
    {
        string path = "No Assets Selected";

        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetFileName(path);
                break;
            }
        }
        return path;
    }

    public static UnityEngine.Object GetSelectedObject()
    {
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Deep))
        {
            return obj;
        }

        return null;
    }
}