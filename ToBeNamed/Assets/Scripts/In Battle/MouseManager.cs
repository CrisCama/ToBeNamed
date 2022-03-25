using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    Unit selectedUnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Is Mouse over Unity UI element? -- it is so lets not do any custom mouse code.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.transform.parent.gameObject;
            //Debug.Log("MouseOver" + hitObject.name);
            if(hitObject.GetComponent<Hex>() != null)
            {
                MouseOverHex(hitObject);
            }
            else if (hitObject.GetComponent<Unit>() != null) //moves unit directly, look up pilemap tutorial for pathfinding on quil18creates
            {
                MouseOverUnit(hitObject);
            }
        }
    }
    void MouseOverHex(GameObject hitObject)
    {
        //Debug.Log("hit" + hitObject.name);

        if (Input.GetMouseButtonDown(0))
        {
            MeshRenderer mr = hitObject.GetComponentInChildren<MeshRenderer>();

            if (mr.material.color == Color.green)
            {
                mr.material.color = Color.white;
            }
            else
            {
                mr.material.color = Color.green;
            }

            if (selectedUnit != null)
            {
                selectedUnit.destination = hitObject.transform.position;
            }
        }
    }
    void MouseOverUnit(GameObject hitObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit = hitObject.GetComponent<Unit>();
            Debug.Log(selectedUnit.name + "Selected");
        }
    }
}
