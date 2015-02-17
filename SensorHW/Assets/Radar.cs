﻿	using UnityEngine;
	using System.Collections;
	
	public class Radar : MonoBehaviour 
{  // from the Unity Wiki; Original code source :http://wiki.unity3d.com/index.php?title=Radar
		//
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
		/*if(centerObject){
				Rect r=new Rect(Screen.width-50 - RadarSize, 50, RadarSize, RadarSize);
				
				UnityEngine.GUI.DrawTexture(r, radarBG,ScaleMode.StretchToFill);
				mapCenter = new Vector2(Screen.width-50-RadarSize/2,50+RadarSize/2);*/
				foreach(RComp c in RadaObjects){ 
					Debug.Log ("");
					GameObject[] gos = GameObject.FindGameObjectsWithTag(c.TagName);
					foreach (GameObject go in gos){
						nameObj(go);
					}
				//}
			}
		}
		
		private void nameObj(GameObject go)
	{
			Vector3 centerPos = centerObject.position;
			Vector3 extPos = go.transform.position;
			
			// first we need to get the distance of the enemy from the player
			float dist = Vector3.Distance(centerPos, extPos);
			
			float dx = centerPos.x - extPos.x; // how far to the side of the player is the enemy?
			float dz = centerPos.z - extPos.z; // how far in front or behind the player is the enemy?
			
			// what's the angle to turn to face the enemy - compensating for the player's turning?
			float deltay = Mathf.Atan2(dx, dz) * Mathf.Rad2Deg - 270 - centerObject.eulerAngles.y;
			
			// just basic trigonometry to find the point x,y (enemy's location) given the angle deltay
			float bX = dist * Mathf.Cos(deltay * Mathf.Deg2Rad);
			float bY = dist * Mathf.Sin(deltay * Mathf.Deg2Rad);


			
		//	bX = bX * mapScale; // scales down the x-coordinate by half so that the plot stays within our radar
		//	bY = bY * mapScale; // scales down the y-coordinate by half so that the plot stays within our radar
		if (dist < maxDist)
		Debug.Log (go.tag + ":" + dist + "units away");
			/*if (dist <= maxDist)
			{
				// this is the diameter of our largest radar circle
				UnityEngine.GUI.DrawTexture(new Rect(mapCenter.x + bX, mapCenter.y + bY, 2, 2), aTexture);
			}*/
		}
	}
