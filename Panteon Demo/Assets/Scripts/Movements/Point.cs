using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    /// <summary>
    /// we are using points in the grid system 
    /// </summary>
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
