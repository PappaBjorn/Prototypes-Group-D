using UnityEngine;
using System.Collections;

public class MoveBox : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private bool CanIMove=false;
	private Vector3 moveDirection = Vector3.zero;
	public int MyCurrentLevel;


	void Start ()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.grey;
	}
	
	
	private void OnMouseDown() {
		CanIMove=true;
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}

	private void OnMouseOver () {
		if(Input.GetMouseButtonDown(1)){
			CanIMove = false;
			gameObject.GetComponent<Renderer>().material.color = Color.grey;
		}
	}
	
	// Transport to next level:
	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		//Application.LoadLevel("Level2");
		int MyCurrentLevel = Application.loadedLevel;
		Application.LoadLevel(MyCurrentLevel + 1);
	}
	
	void Update() {
		
		if(Input.GetKeyDown(KeyCode.E)){
			CanIMove = false;
			gameObject.GetComponent<Renderer>().material.color = Color.grey;
		}

		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}

		if(CanIMove == true){

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		}
	}
}