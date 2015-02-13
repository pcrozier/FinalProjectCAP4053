using UnityEngine;
using System.Collections;

public class AgentFactoryController : MonoBehaviour {
	public GameObject agent3Prefab;
	private bool makeAgent = false;
	private Vector3 creationCoordinates;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			creationCoordinates = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			creationCoordinates.z = 0;
			makeAgent = true;
		} else if (makeAgent) {
			// Don't make the agent until we release the fire button.
			// Otherwise, we'll spawn a ton on top of eachother everytime we click.
			makeAgent = false;
			createAgent (creationCoordinates);
		}
	}

	void createAgent(Vector3 creationCoordinates){
		Instantiate (agent3Prefab, creationCoordinates, Quaternion.identity);
	}
}
