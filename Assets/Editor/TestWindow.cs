using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestWindow : EditorWindow
{
    [MenuItem("Test/Window")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<TestWindow>();
        window.Show();
    }
    void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Box("", EditorStyles.toolbar, GUILayout.ExpandWidth(true));
        //Rect timelineRect = GUILayoutUtility.GetLastRect();
        GUILayout.Space(10);
        GUILayout.Box("", EditorStyles.toolbar, GUILayout.ExpandWidth(true));

        GUILayout.EndVertical();
    }
}
