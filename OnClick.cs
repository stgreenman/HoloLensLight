using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace HoloToolkit.Unity.InputModule
{
	public enum TypeTw
	{
		Hide,
		Lock,
		SetFrame,
		ZoomIn,
		ZoomOut
	}
	public enum TagSelection
    {
		head, 
		upperCranium, 
		lowerCranium
    }

    public class OnClick : MonoBehaviour, IInputClickHandler
    {
		public Type type;

		// Hiding Buttons
		public TagSelection selection;
		private List<GameObject> hiddenObjects = new List<GameObject>();

		// Zooming Buttons
		Vector3 heading;
		float distance;

	
        public void OnInputClicked(InputClickedEventData eventData)
        {  	
			string buttonName = selection.ToString();
			GameObject gameObj = GameObject.FindGameObjectWithTag(buttonName);
			GameObject parentObj;
			switch(type) {

			case Type.Lock:

				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;

				Text buttonText = gameObject.GetComponentInChildren <Text> ();
				Debug.Log ("4");
				if (buttonText.text == "Lock Position") {
					Debug.Log ("5");
					buttonText.text = "Unlock Position";
					Debug.Log ("6");
					parentObj.GetComponent<HandDraggable> ().enabled = false;
					Debug.Log ("7");
				} else {
					Debug.Log ("8");
					buttonText.text = "Lock";
					Debug.Log ("9");
					parentObj.GetComponent<HandDraggable> ().enabled = true;
				}
				break;

			case Type.Hide :
				
				if (gameObj == null){
					hiddenObjects.Find(item => item.name == buttonName).SetActive(true);
					hiddenObjects.Remove(gameObj);
	            }
	            else{
					hiddenObjects.Add(gameObj);
					gameObj.SetActive (false);
	            }
				break;

			case Type.SetFrame:
				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;

				FindDistance track = new FindDistance ();
				float distance = track.getDistanceBetween (Camera.main, parentObj);
				//heading = parentObj.transform.position - Camera.main.transform.position;
				//distance = Vector3.Dot (heading, Camera.main.transform.forward);
				Camera.main.nearClipPlane = distance;
				Debug.Log ("Distance: " + distance);
				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
				break;

			case Type.ZoomIn:
				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;

				heading = parentObj.transform.position - Camera.main.transform.position;
				distance = Vector3.Dot (heading, Camera.main.transform.forward);
				Camera.main.nearClipPlane += 0.02f;
				Debug.Log ("Distance: " + distance);
				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
				break;

			case Type.ZoomOut :
				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;

				heading = parentObj.transform.position - Camera.main.transform.position;
				distance = Vector3.Dot (heading, Camera.main.transform.forward);
				Camera.main.nearClipPlane -= 0.02f;
				Debug.Log ("Distance: " + distance);
				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
				break;
				
			default : /* Optional */
				break;
			}
        }
	}



}