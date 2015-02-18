using UnityEngine;
using System.Collections;

public class NewSensorScript : MonoBehaviour {
 // from the Unity Wiki; Original code source :http://wiki.unity3d.com/index.php?title=Radar
		//
		private int[] a ={0,0,0,0};
		public Transform centerObject;
		public float maxDist;
		public RComp[] RadaObjects;
		[System.Serializable]
		public class RComp{
			public string TagName;
		}
		
		public void radarfier()
		{
		a [0] = 0;
		a [1] = 0;
		a [2] = 0;
		a [3] = 0;
			foreach(RComp c in RadaObjects){ 
				GameObject[] gos = GameObject.FindGameObjectsWithTag(c.TagName);
				foreach (GameObject go in gos){
					a = pieSensor(go,a);
				}
			print(" up: "+ a[0] + " right: "+ a[1] + " down: "+ a[2] + " left: " + a[3]);
			}
		}

			

	private int[] pieSensor(GameObject go, int[]x)
	{
		Vector3 centerPos = centerObject.position;
		Vector3 extPos = go.transform.position;
		
		// first we need to get the distance of the enemy from the player
		float dist = Vector3.Distance(centerPos, extPos);
		if (dist <= maxDist){

			Debug.Log (go.tag + ":" + dist + "units away");//effectively the radar or circular scanner
			float dx = centerPos.x - extPos.x; // how far to the side of the player is the enemy?
			float dy = centerPos.y - extPos.y; // how far in front or behind the player is the enemy?
			
			// what's the angle to turn to face the enemy - compensating for the player's turning?
			float deltay = (((Mathf.Rad2Deg * Mathf.Atan2(dx, dy)) + 720)%360) - centerObject.rotation.eulerAngles.y;
			if ((deltay <= 45) || (deltay >= 315))
				a[0] = a[0]+1;
			if ((deltay >= 45) && (deltay <= 135))
				a[1] = a[1]+1;
			if ((deltay >= 135) && (deltay <= 225))
				a[2] = a[2]+1;
			if ((deltay >= 225) && (deltay <= 315))
				a[3] = a[3]+1;
		}
		return a;
	}
	}
