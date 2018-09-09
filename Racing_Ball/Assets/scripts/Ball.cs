using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float Speed = 6f;
    public bool CanMove = false;

    void Start ()
    {

    }

	void Update ()
    {
        if (!CanMove) return;

            var direction = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow))
                direction += Vector3.forward;

            if (Input.GetKey(KeyCode.DownArrow))
                direction += Vector3.back;

            if (Input.GetKey(KeyCode.LeftArrow))
                direction += Vector3.left;

            if (Input.GetKey(KeyCode.RightArrow))
                direction += Vector3.right;

            var rb = GetComponent<Rigidbody>();
            rb.AddForce(direction * Speed * Time.deltaTime*40f);        
	}
}
