	using UnityEngine;
	using System.Collections;
	
	public class Radar : MonoBehaviour 
{  // from the Unity Wiki; Original code source :http://wiki.unity3d.com/index.php?title=Radar
		//
		public Transform centerObject;
		public float maxDist;
		public RComp[] RadaObjects;
		[System.Serializable]
		public class RComp{
			public string TagName;
		}
		
		public void OnGUI()
		{
				foreach(RComp c in RadaObjects){ 
					Debug.Log ("");
					GameObject[] gos = GameObject.FindGameObjectsWithTag(c.TagName);
					foreach (GameObject go in gos){
						nameObj(go);
					}
			}
		}
		
		private void nameObj(GameObject go)
	{
			Vector3 centerPos = centerObject.position;
			Vector3 extPos = go.transform.position;
			
			// first we need to get the distance of the enemy from the player
			float dist = Vector3.Distance(centerPos, extPos);

 			if (dist < maxDist)
			Debug.Log (go.tag + ":" + dist + "units away");
			
		}
	}
