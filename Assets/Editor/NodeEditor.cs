using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Nodes))]
public class NodeEditor : Editor
{
    Nodes nodes;
    Color waypointColor;

    private void OnSceneGUI()
    {
        Nodes nodes = (target as Nodes);
        List<Vector3> points = nodes.GetPoints();
        Transform transform = nodes.transform;

        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        if (nodes.editMode == true)
        {
            Selection.activeGameObject = nodes.gameObject;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    nodes.AddPoint(hit.point);
                }
            }

            for (int index = 0; index < points.Count; index++)
            {
                Vector3 point = points[index];
                point = Handles.DoPositionHandle(point, Quaternion.identity);

                points[index] = point;
            }

            nodes.SetPoints(points);
        }
    }
    }
