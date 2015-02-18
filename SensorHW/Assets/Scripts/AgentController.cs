using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {
	// Position (x,y) = (transform.position.x, transform.position.y)
	// Heading (or theta) = transform.rotation

	private float speed; // current speed.
	public float maxSpeed; // top speed possible.
	public float acceleration; // how quickly up arrow changes speed
	public float deceleration; // how quickly down arrow changes speed
	public float friction; // resistance to speeding up /slowing down and speed to halt self.
	public float turnSpeed;  // how quickly left/right arrows change direction
	public Transform centerObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Turning controls....note that it isn't totally lag resistant, but pretty good.
		if (Input.GetKey("left")) {
			//Debug.Log ("Turning left");
			transform.Rotate (- Vector3.back * turnSpeed * Time.deltaTime); // turning around Z-axis
		} else if (Input.GetKey("right")) {
			//Debug.Log ("Turning right");
			transform.Rotate (Vector3.back * turnSpeed * Time.deltaTime); // turning around Z-axis
		}

		// Acceleration controls.
		if (Input.GetKey("up")) {
			speed += acceleration - friction;

			if (speed > maxSpeed) {
				speed = maxSpeed;
			}

			//Debug.Log ("Moving forward, speed="+speed);
		} else if (Input.GetKey("down")) {
			speed -= acceleration - friction;
			
			if (speed < -maxSpeed) {
				speed = -maxSpeed;
			}
			
			//Debug.Log ("Moving backward, speed="+speed);
		} else {
			// If moving
			if (speed != 0){
				// If moving forward
				if(speed > 0){
					// Decrease speed by amount 'friction' (but not to speed < 0).
					if (speed - friction >= 0)
						speed -= friction;
					else 
						speed = 0;
				}else{
					// Decrease |speed| by amount 'friction' (but not to speed > 0).
					if (speed + friction <= 0)
						speed += friction;
					else 
						speed = 0;
				}
				//Debug.Log ("Slowing, speed="+speed);
			}
		}
		// Actually move with whatever speed we have.
		transform.position += transform.up * speed * Time.deltaTime;
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Wall") 
			Debug.Log ("Wall");
		else if (col.gameObject.tag == "Object") 
			Debug.Log ("Object detected");
			else Debug.Log ("Clear");
	}
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Detected:" + other.attachedRigidbody);
		}
}
