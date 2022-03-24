using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject hexPrefab;

    // Size of map in terms of # of hextiles
    // Not representative of the amount of world space we will take up
    // our tiles may be more or less than 1 Unity world unit
    int width = 20;
    int height = 20;

    public float xOffset = 0.882f;
    public float zOffset = 0.764f;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;
                // Are we on off row?
                if (y % 2 == 1)
                {
                    xPos += xOffset/2;
                }
                Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
