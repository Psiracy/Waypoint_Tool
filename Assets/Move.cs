using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Nodes nodes;

    int count;
    public float movementSpeed;

    List<Vector3> points;
    Vector3 target;
    // Use this for initialization
    void Start()
    {
        nodes = FindObjectOfType<Nodes>();
        points = new List<Vector3>();
        points = nodes.GetPoints();
        target = points[0];
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, target.z), Time.deltaTime * movementSpeed);
        if (Vector3.Distance(transform.position, new Vector3(target.x, transform.position.y, target.z)) <= 0)
        {
            if (count + 1 < points.Count)
            {
                count++;
            }
            else
            {
                count = 0;
            }
            target = points[count];
        }
    }
}
