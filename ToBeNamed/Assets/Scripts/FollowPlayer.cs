using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float rotationY;
    public float rotationX;

    [SerializeField] Transform target;

    [SerializeField] float offset = 8.0f;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField] float smoothTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rotationY += horizontalInput * rotationSpeed * Time.deltaTime;
        rotationX += verticalInput * rotationSpeed * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, 30, 80);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);


        transform.localEulerAngles = currentRotation;
        transform.position = target.position - transform.forward * offset;

    }
}
