using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //Assign play's transform in unity, essential for tracking position
    public Transform player;
    //Stores the initial offset between camera's and player's
    private Vector3 offset;
    //how quickly the camera should smooth its movement towards the target position
    private float smoothTime;
    //track current velocity of the camera's movement
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Initial offset
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Desired position for the cameraa based on player and predefined offset
        var targetPosition = player.position + offset;
        //Move camera towards target position,creat a fluid camera motion with uses current position,target position and smooth time.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}