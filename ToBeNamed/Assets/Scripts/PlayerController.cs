using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimation;
    public GameObject targetPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                targetPos.transform.position = hit.point;
                player.SetDestination(hit.point);
            }
        }

        if (player.velocity != Vector3.zero)
        {
            playerAnimation.SetBool("isWalking", true);
        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimation.SetBool("isWalking", false);
        }
    }
}
