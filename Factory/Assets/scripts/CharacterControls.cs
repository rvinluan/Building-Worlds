using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	
	private CharacterController control;
    public float speed = 6.0F;
	public float airSpeed = 6.0F/2;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		control = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey ("a") ) {
			moveDirection.x = -airSpeed;
		}
		if( Input.GetKey ("d") ) {
			moveDirection.x = airSpeed;
		}
		
		//moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        if (control.isGrounded) {
		moveDirection = Vector3.zero;
		if( Input.GetKey ("a") ) {
			moveDirection.x = -1;
		}
		if( Input.GetKey ("d") ) {
			moveDirection.x = 1;
		}
        moveDirection *= speed;
            if (Input.GetKey("w"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        control.Move(moveDirection * Time.deltaTime);
	}
	
	void FixedUpdate() {
	}
}
