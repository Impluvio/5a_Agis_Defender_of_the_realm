using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates; //holds coords of point
    public bool isTraversable;     //whether it can be explored or path
    public bool isExplored;        //whether it can be path
    public bool isPath;            //whether it is path
    public Node connectedTo;       //which node this node is connected to.

    public Node(Vector2Int coordinates, bool isTraversable)
    {
        this.coordinates = coordinates;
        this.isTraversable = isTraversable;
    }
}
