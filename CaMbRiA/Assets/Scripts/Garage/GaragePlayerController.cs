using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
INTENT:    this is the base player controller for both Morpho and Abercrombie.
           ideally, both their controllers will inherit from this one, but we'll see.
           
Usage:     this script goes on any object that will be controlled by the player.
*/     


public class GaragePlayerController : MonoBehaviour
{
    // PUBLIC FIELDS
    public float movementSpeed; // speed of movement
    public float rotationSpeed; // speed of rotation
    public float gravityScale; // scale of gravity    
    
    
    // OBJECT COMPONENETS
    private Rigidbody rBody; // rigidbody on this object
    
    // PRIVATE FIELDS
    private Vector3 inputVector;

    private float t;
    
    void Start()
    {
        rBody = GetComponent<Rigidbody>(); // assign rigidboyd
    }

    void Update()
    {
        // get inputs
        float inputSide = Input.GetAxisRaw("Horizontal");
        float inputFwd = Input.GetAxisRaw("Vertical");

        inputVector = Vector3.zero;
        inputVector = new Vector3( inputSide, 0f, inputFwd);

        transform.Rotate(new Vector3(0f, inputSide * rotationSpeed, 0f));

        
    }

    
    // actual movement will go on here, since we're using velocity changes with the movement
    // and velocity is part of the physics engine, which updates in FixedUpate.
    void FixedUpdate()
    {
        if (inputVector.z > 0)
            rBody.velocity = transform.forward * movementSpeed + Physics.gravity * gravityScale;
        else if (inputVector.z < 0)
        {
            rBody.velocity = -transform.forward * movementSpeed + Physics.gravity * gravityScale;
        }

        RayThing fwdCast = CastRay(transform.position, transform.position, 3f, true);
    }

    
    // function for casting rays, which we'll be doing a lot of in this script
    RayThing CastRay(Vector3 origin, Vector3 direction, float distance, bool visualize)
    {
        
        // initialize ray
        Ray myRay = new Ray(origin, direction);
        
        // visualize the ray if desired
        if (visualize)
            Debug.DrawRay(origin, direction, Color.yellow, distance);
        
        RayThing output = new RayThing();

        output.didHit = Physics.Raycast(myRay, out output.rayHit, distance); // fill the output class


        return output; // return the raything output
    }
    
    
}



