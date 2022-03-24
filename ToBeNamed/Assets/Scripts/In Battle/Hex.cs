using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public int x;
    public int y;

    public Hex[] getNeighbours()
    {
        // If we are at x, y -- the neighbour to our left is at x-1, y
        GameObject leftNeighbours = GameObject.Find("Hex" + (x - 1) + "_" + y);
        GameObject RightNeighbours = GameObject.Find("Hex" + (x + 1) + "_" + y);

        return null;
    }
}
