using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.transform.gameObject;
            Debug.Log("hit" + hitObject.name);

            MeshRenderer mr = hitObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = Color.green;
        }
    }
}
