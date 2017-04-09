using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindDistance : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (new Vector3 (1, 1, 1), 1);
	}
	
	// Update is called once per frame
	void Update () {

		//GameObject obj3= GameObject.FindGameObjectWithTag ("myHead-skull");
		//float num = getDistanceBetween (Camera.main, obj3);
	}

	//Transform obj1;
	//Transform obj2;

	float centerDiff = 0.0f; // difference between the centers
	float colliderDiff = 0.0f; // difference between the collider edges

	float rayDist1 = 0.0f;
	float rayDist2 = 0.0f;

	Vector3 drawlineOffset = new Vector3(0, 0.1f, 0); // for the drawlines to not render over each other


	public float getDistanceBetween(Camera camera, GameObject obj2) 
	{
		Debug.Log ("Camera pos: " + camera.transform.position);
		Debug.Log ("GameObj pos: " + obj2.transform.position);

		centerDiff = (obj2.transform.position - camera.transform.position).magnitude; // distance between 2 objects

		RaycastHit rayHit;

		if (Physics.Raycast( camera.transform.position, Vector3.zero - (camera.transform.position - obj2.transform.position).normalized, out rayHit) ) 
		{
			Debug.Log("Red-- cam pos: " + camera.transform.position + "rayHit point: " + rayHit.point);
			Debug.DrawLine(camera.transform.position, rayHit.point, Color.red, 40);
			rayDist1 = Vector3.Distance(rayHit.point, camera.transform.position);
		}

//		if (Physics.Raycast( obj2.transform.position, Vector3.zero - (obj2.transform.position - camera.transform.position).normalized, out rayHit) ) 
//		{
//			Debug.Log("Green-- obj pos + offset: " + (obj2.transform.position + drawlineOffset) + "rayHit point + offset: " + (rayHit.point + drawlineOffset));
//			Debug.DrawLine(obj2.transform.position + drawlineOffset, rayHit.point + drawlineOffset, Color.green, 40); // offset so line can be seen
//			rayDist2 = Vector3.Distance(rayHit.point, obj2.transform.position);
//		}

//		colliderDiff = Mathf.Abs(centerDiff - ( centerDiff - rayDist1 ) - ( centerDiff - rayDist2 )); // colliderDiff - (collider2 radius) - (collider1 radius)
//		Debug.Log("ColliderDiff: " + colliderDiff);
		//return colliderDiff;

		return rayDist1;
	}


//	public void OnDrawGUI() 
//	{
//		GUI.Box (new Rect (10, 5, 200, 25), "center Difference = " + centerDiff.ToString() );
//		GUI.Box(new Rect(10, 35, 200, 25), "collider Difference = " + colliderDiff.ToString() );
//	}
}
