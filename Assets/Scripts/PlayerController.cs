using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedMoving;
    public float speedRotation;

    private Vector3 moveDirection;
    private Rigidbody rb;
    public UIController uiController;
    public GameController gameController;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        float manage = uiController.GetManage();
        moveDirection = new Vector3(speedMoving, 0, 0).normalized;
        transform.Rotate(Vector3.up, manage * speedRotation * 100 * Time.deltaTime, Space.Self);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * 3 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            gameController.StopGame();
        }
    }
}
