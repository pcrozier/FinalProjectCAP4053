using UnityEngine;
using System.Collections;

public class MoveInARectangle : MonoBehaviour {
	public float width;
	public float height;
	public float speed;
	private float stepsLeft;
	private int state;
	private float change = 0;
	private float carryOver = 0;
	private float carryOverBonus = 0;

	// Use this for initialization
	void Start () {
		// Start by going right.
		stepsLeft = width;
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// Check if we need to change state. 
		if (stepsLeft <= 0) {
			state = (state+1)%4; // Go to the next state.

			if (state%2 == 0) 
				stepsLeft = width; // states 0 and 2 are horizontal
			else 
				stepsLeft = height;
		}

		// Cycle through our states moving in the rectangle.
		if (stepsLeft - speed*Time.deltaTime <= 0){
			change = stepsLeft;
			stepsLeft = 0;
			carryOver = speed*Time.deltaTime - change; // Save this so we can make it up 
													   // when we start going a different direction.
		} else {
			change = speed*Time.deltaTime;
			stepsLeft -= change;
			carryOver = 0;
		}
		float newX = transform.position.x;
		float newY = transform.position.y;

		switch (state) {
		case 0: //Right
			newX = transform.position.x + change + carryOverBonus;
			break;
		case 1: //Down
        	newY = transform.position.y - change - carryOverBonus;
			break;
		case 2: //Left
	        newX = transform.position.x - change - carryOverBonus;
			break;
		case 3: //Up
	        newY = transform.position.y + change + carryOverBonus;
			break;

		}

		transform.position = new Vector3(newX,newY,0);

		carryOverBonus = carryOver; // Couldn't use carryOver right away, 
									// since it belongs to a different direction.
									// We'll use it next time.
	}
}
