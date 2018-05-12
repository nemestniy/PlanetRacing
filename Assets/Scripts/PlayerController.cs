using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Vector3 moveDirection;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        moveDirection = new Vector3(1, 0, 0).normalized;
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * speed * 100 * Time.deltaTime, Space.Self);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }
}
