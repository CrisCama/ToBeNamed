using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject hexPrefab;

    // Size of map in terms of # of hextiles
    // Not representative of the amount of world space we will take up
    // our tiles may be more or less than 1 Unity world unit
    public int width = 10;
    public int height = 10;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

    // Start is called before the first frame update
    void Start()
    {
        for (int column = 0; column < width; column++)
        {
            for (int row = 0; row < height; row++)
            {
                float xPos = column * xOffset;
                // Are we on off row?
                if (row % 2 == 1)
                {
                    xPos += xOffset/2;
                }
                GameObject hex = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, row * zOffset), Quaternion.identity);

                // Name GameObject
                hex.name = "hex_" + column + "_" + row;

                // Make sure hex is aware of place on map
                hex.GetComponent<Hex>().x = column;
                hex.GetComponent<Hex>().y = row;

                // Cleaner Hierachy
                hex.transform.SetParent(this.transform);

                hex.isStatic = true;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
