using System;
using UnityEngine;

public class AircraftController : MonoBehaviour {
  
    public float forwardThrustForce = 40.0f;
    public float turnForceMultiplier = 5000.0f;
    public float maxSpeed = 400.0f;

    private Vector3 controlForce;
    private Rigidbody rigidBody;

   // private Transform mytransform;

	void Start () {
       
        rigidBody = GetComponent<Rigidbody>();

        //mytransform = transform;
       // mytransform.position = new Vector3(10, 20, 30);
	}

	
	void Update () {
        controlForce.Set(
            Input.GetAxis("Horizontal") * turnForceMultiplier, 
            Input.GetAxis("Vertical") * turnForceMultiplier, 
            1.0f
        );
        controlForce = controlForce.normalized * forwardThrustForce;
    }

    void FixedUpdate()
    {
        float excessSpeed = Math.Max(0, rigidBody.velocity.magnitude - maxSpeed);        
        Vector3 brakeForce = rigidBody.velocity.normalized * excessSpeed;    
        rigidBody.AddForce(-brakeForce, ForceMode.Force);   
        rigidBody.AddRelativeForce(controlForce, ForceMode.Force);

        transform.forward = rigidBody.velocity;
    }
}
    