using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
	public class OpenMenu : MonoBehaviour, IInputClickHandler
	{
		
		public float distance = 2f; 
		public Vector3 MenuOffSet;
		private Quaternion targetRotation;

		public static GameObject previousObj;
		public static GameObject currentObj;
		static GameObject menu;


		// 3/31 - Skyler TODO: Need to identify current clicked GameObject (light) and compare it to previously clicked GameObject. IF not the same, move the menu to the current light's position and have it reference it as it's public variable

		void Start (){
			
//			Debug.Log ("Should find menu: " + menu.name);
			menu = GameObject.FindGameObjectWithTag("menu");
			if (menu != null) {
				menu.SetActive (false);
			}
		}

		public void OnInputClicked(InputClickedEventData eventData)
		{
			currentObj = transform.gameObject; 
			if (previousObj != currentObj || previousObj != null && currentObj.tag == "light") {
				menu.transform.position = currentObj.transform.position; 
			}

			if (!GameObject.FindGameObjectWithTag ("menu")) {

				//				Vector3 camPos = Camera.main.transform.position;
				//				Vector3 objPos = transform.localPosition;
				//				Debug.Log ("local objPos: " + objPos);
				//				Vector3 upObjPos = objPos + transform.up;
				//
				//
				//
				//				Vector3 camObjDiff = camPos - objPos;
				//				Vector3 upObjDiff = upObjPos - objPos;
				//				Vector3 perpPos = Vector3.Cross (upObjDiff, camObjDiff).normalized;
				//
				//				Debug.DrawLine (camPos, objPos, Color.red, 120);
				//				Debug.DrawLine (upObjPos, objPos, Color.green, 120);
				//				Debug.DrawLine (perpPos, objPos, Color.blue, 120);
				//
				//
				//				menu.transform.position = perpPos;
				//				menu.transform.rotation = transform.rotation;
				menu.SetActive (true);
				Debug.Log ("menu state: (true);" + menu.activeSelf);
			}
			else{
				menu.SetActive (false);
				Debug.Log ("menu.SetActive (false);"  + menu.activeSelf);
			}
				
	/* 
			Vector3 offset = new Vector3 (0.01f, 0.01f, 0.01f);
			// Set menu position adjacent to gameObject
			Vector3 camPos = Camera.main.transform.position;
			Debug.Log ("camPos: " + camPos);

			Vector3 objPos = gameObject.transform.position;
			Vector3 upObjPos = gameObject.transform.position + gameObject.transform.up; 

			Vector3 camObjDiff = camPos - objPos;

			Debug.DrawLine (camPos, objPos, Color.red, 120);
			Debug.Log ("camPos: " + camPos);
			Debug.Log ("objPos: " + objPos);
			Debug.Log ("camObjDiff: " + camObjDiff);

			Vector3 upObjDiff = upObjPos - objPos;

			Debug.DrawLine (upObjPos, objPos, Color.green, 120);
			Debug.Log ("upObjPos: " + upObjPos);
			Debug.Log ("objPos: " + objPos);
			Debug.Log ("upObjDiff: " + upObjDiff);

			Vector3 perpPos = Vector3.Cross (upObjDiff, camObjDiff);
			perpPos += objPos;

			Debug.DrawLine (perpPos, objPos, Color.blue, 120);
			Debug.Log ("perpPos: " + perpPos);

			Vector3 camPos = new Vector3 (0.35f, -0.02f, -3.48f);
			Vector3 upObjPos = new Vector3 (2.42f, 3.22f, -2.14f);
			Vector3 objPos = new Vector3 (2.42f, 2.0f, -2.14f);


			Debug.Log (this.gameObject+ " should be looking at you");
	*/



//
//			menu.transform.Translate (Vector3.ClampMagnitude( (Camera.main.transform.position -menu.transform.position).normalized,1) * .8f,Space.Self);
//			menu.transform.Translate (Vector3.right *2f, Space.World);
//
			Vector3 dir = Camera.main.transform.right;
			dir.y = transform.position.y;
			dir.Normalize ();


			menu.transform.position = gameObject.transform.position;
			menu.transform.Translate (dir * .2f);


			menu.transform.LookAt (Camera.main.transform);
			menu.transform.RotateAround (menu.transform.position, menu.transform.up, 180f);


			//menu.transform.position = gameObject.transform.position + MenuOffSet;

			previousObj = transform.gameObject; 
		}
	}
}