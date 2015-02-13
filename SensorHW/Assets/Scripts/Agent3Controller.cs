using UnityEngine;
using System.Collections;

public class Agent3Controller : MonoBehaviour {
	// Position (x,y) = (transform.position.x, transform.position.y)
	// Heading (or theta) = transform.rotation

	// Use this for initialization
	void Start () {
		// Change the theta (transform.rotation) randomly using the transform.Rotate() method.
		transform.Rotate(new Vector3(0,0,Random.Range (0, 11)*30)); // Do it in blocks of 30 so it will rotate the sprite better.
	}

	// Update is called once per frame
	void Update () {
	
	}
}
