using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Nodes : MonoBehaviour
{
    [HideInInspector]
    public Color lineColor;
    //[HideInInspector]
    public bool editMode, targetSelected;

    public List<Vector3> points = new List<Vector3>();

    public List<Vector3> GetPoints()
    {
        return points;
    }

    public void SetPoints(Vector3[] newPoints)
    {
        for (int i = 0; i < newPoints.Length; i++)
        {
            points[i] = newPoints[i];
        }
    }

    public void SetPoints(List<Vector3> newPoints)
    {
        points = newPoints;
    }

    public void AddPoint(Vector3 newPoint)
    {
        points.Add(newPoint);
    }

    public void BeginPoint(Vector3 beginPoint)
    {
        if (points.Count == 0)
        {
            points.Add(beginPoint);
        }
        else
        {
            points[0] = beginPoint;
        }
    }

    private void OnDrawGizmos()
    {
        if (targetSelected == true)
        {
            Gizmos.color = lineColor;
            for (int i = 1; i < points.Count; i++)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(points[i], points[i - 1]);
            }
        }
    }
}
