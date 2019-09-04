using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class NodeToolWindows : EditorWindow
{
    bool editMode;
    Nodes nodes;
    Color waypointColor;
    string selectedObject;
    GameObject waypointTarget;
    float movementSpeed;
    [MenuItem("Windows/NodeTool")]

    static void Init()
    {
        GetWindow<NodeToolWindows>(false, "Level Editor", true);
    }

    void OnEnable()
    {
        nodes = FindObjectOfType<Nodes>();
    }

    private void OnGUI()
    {
        EditorGUILayout.TextField("Current Selected Object", selectedObject);
        //edit mode
        editMode = GUI.Toggle(new Rect(20, 20, 100, 50), editMode, "Edit Mode");
        //color
        waypointColor = EditorGUI.ColorField(new Rect(20, 40, Screen.width - 120, 15), "Waypoint Color:", waypointColor);
        //waypoint target
        GUILayout.BeginArea(new Rect(20, 80, Screen.width - 120, 200));
        if (GUILayout.Button("Set Waypoint target"))
        {
            selectedObject = Selection.activeGameObject.name;
            waypointTarget = Selection.activeGameObject;
            nodes.BeginPoint(waypointTarget.transform.position);
        }
        GUILayout.EndArea();
        //reset all nodes
        GUILayout.BeginArea(new Rect(20, Screen.height - 250, Screen.width - 120, 200));
        if (GUILayout.Button("Reset"))
        {
            nodes.GetPoints().Clear();
            nodes.BeginPoint(waypointTarget.transform.position);
        }
        GUILayout.EndArea();
    }

    private void Update()
    {
        if (editMode == true && Selection.activeGameObject != nodes)
        {
            Selection.activeGameObject = nodes.gameObject;
        }
        nodes.editMode = editMode;
        nodes.lineColor = waypointColor;

        if (Selection.activeGameObject == waypointTarget)
        {
            nodes.targetSelected = true;
        }
        else
        {
            nodes.targetSelected = false;
        }
    }
}
