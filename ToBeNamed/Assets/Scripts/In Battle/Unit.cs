using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Vector3 destination;

    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards destination
        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;

        // Make sure distanced moved does not exceed distance we want
        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);
    }
}
