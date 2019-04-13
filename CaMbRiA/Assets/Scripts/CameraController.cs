
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    private Vector3 normalRelativePos;



    void Start()
    {
        normalRelativePos = transform.localPosition;
    }

    private float t;
    
    // Update is called once per frame
    void Update()
    {

        
        
    }

    void LateUpdate()
    {
        RayThing backRayThing = new RayThing();
        backRayThing = CastRay(transform.position, new Vector3(-transform.forward.x, 0f, -transform.forward.z), 5f,
            true);
        if (backRayThing.didHit)
        {
            Vector3 hitLocation = backRayThing.rayHit.point;
            float dist;
            if ((dist = Vector3.Distance(transform.position, hitLocation)) < 1f)
            {
                t = 0f;
                transform.position += transform.forward * (1f - dist);
            } else if (Vector3.Distance(transform.localPosition, normalRelativePos) > 0.01)
            {
                t += Time.fixedDeltaTime;
                transform.localPosition = Vector3.Lerp(transform.localPosition, normalRelativePos, t);
            }
            
            
        }
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
