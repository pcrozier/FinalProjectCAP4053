using UnityEngine;
using System.Collections;

public class PiSensor : MonoBehaviour {
	 // from the Unity Wiki; Original code source :http://wiki.unity3d.com/index.php?title=Radar
		private int[] a = {0,0,0,0}; 
		private string[] b = {null,null,null,null};
		public Transform centerObject;
		public float maxDist;
		public RComp[] RadaObjects;
		private Vector2 mapCenter;
		[System.Serializable]
		public class RComp{
			public string TagName;
		}
		
		public void OnGUI()
		{
		Debug.Log ("");
		a [0] = 0;
		a [1] = 0;
		a [2] = 0;
		a [3] = 0;
			foreach(RComp c in RadaObjects){ 
				GameObject[] gos = GameObject.FindGameObjectsWithTag(c.TagName);
				foreach (GameObject go in gos){
					a = nameObj(go,a);
				}
			for (int i=0; i<4 ; i++){
			if (a[i] == 0)
					b[i] = "None";
			if (a[i] == 1)
					b[i] = "Low";
			if (a[i] == 2)
					b[i] = "Medium";
			if (a[i] >= 3)
					b[i] = "High";
			

			}
			print(" up: "+ b[0] + " right: "+ b[1] + " down: "+ b[2] + " left: " + b[3]);
				//}
			}
		}
		
		private int[] nameObj(GameObject go, int[]x)
		{
			Vector3 centerPos = centerObject.position;
			Vector3 extPos = go.transform.position;
			
			// first we need to get the distance of the enemy from the player
			float dist = Vector3.Distance(centerPos, extPos);
		if (dist <= maxDist){
			float dx = centerPos.x - extPos.x; // how far to the side of the player is the enemy?
			float dy = centerPos.y - extPos.y; // how far in front or behind the player is the enemy?
			
			// what's the angle to turn to face the enemy - compensating for the player's turning?
			float deltay = (Mathf.Rad2Deg * Mathf.Atan2(dx, dy)) - centerObject.rotation.eulerAngles.y;
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