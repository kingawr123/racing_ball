using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform ObjectToTrack;
    public Vector3 delta;
	
	void FixedUpdate ()
    {
        var trackedRigidbody = ObjectToTrack.GetComponent <Rigidbody>();
        var speed = trackedRigidbody.velocity.magnitude;

        transform.LookAt(ObjectToTrack);
        var targetPosition = ObjectToTrack.position + delta * (speed/20f + 1f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime*2f);

    }

    internal Vector3 ViewportToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
