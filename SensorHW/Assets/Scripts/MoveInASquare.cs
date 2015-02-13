using UnityEngine;
using System.Collections;

public class MoveInASquare : MonoBehaviour {
	public float length;
	private float remainingLength;
	public float speed;
	
	void Start () {
		remainingLength = length;
	}
	
	// Update is called once per frame
	void Update () {
		// Not completely uneffected by lag, but it shouldn't deviate from the path because of it.
		if (remainingLength > 0) {
			// Move
			if (remainingLength - speed * Time.deltaTime >= 0){
				transform.position += transform.up * speed * Time.deltaTime;
				remainingLength -= speed * Time.deltaTime;
			} else {
				transform.position += transform.up * remainingLength;
				remainingLength = 0;
			}
		} else {
			// Turn
			transform.Rotate (new Vector3(0,0,-90)); // Turn 90 degrees right
			remainingLength = length;
		}
	}
}
