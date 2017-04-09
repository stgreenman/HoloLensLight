using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.Unity.InputModule
{

	public enum Type
	{
		addLight,
		removeLight,
		brighter,
		dimmer,
		cooler,
		warmer
	}

	public class OnClickTwo: MonoBehaviour, IInputClickHandler
	{
		public Type type;
		public GameObject prefabLight;
		private GameObject firstLight;
		public static Dictionary <int, GameObject> lightDict = new Dictionary <int, GameObject>();
		private string printLine = "";

		static void Start(){
			
//			firstLight = GameObject.FindGameObjectWithTag ("light");
//			//Rename light
//			Random.seed = System.DateTime.Now.Millisecond;
//			int randomNumber = (int)Random.Range (0.0f, 100000.0f);
//			firstLight.name = randomNumber.ToString ();
//			lightDict.Add (randomNumber, firstLight);
//			Debug.Log ("Start");

//			PrintDictionary ();

		}

		void PrintDictionary(){
			foreach (KeyValuePair<int, GameObject> light in lightDict)
			{
				//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
				//printLine = string.Format("Key = {0}, Value = {1}", light.Key, light.Value);
				Debug.Log (light.Key, light.Value);
			}
			Debug.Log (lightDict.Count);
		}

		public void OnInputClicked(InputClickedEventData eventData)
		{  	

			Light light = OpenMenu.currentObj.GetComponentInChildren<Light>();
			float red = 0.0f;
			float green = 0.0f;
			float blue = 0.0f;
			float alpha = 0.0f;

	
			switch(type) {
			case Type.addLight:

				Debug.Log ("Clicked Add Light");
				Vector3 newPos = transform.position;
				newPos.y = transform.position.y + 0.1f;
				GameObject newChild = Instantiate (prefabLight, newPos, Quaternion.identity) as GameObject;
				Random.seed = System.DateTime.Now.Millisecond;
				int randomNumber = (int)Random.Range (0.0f, 100000.0f);
				newChild.name = randomNumber.ToString ();

				// Add to dictionary
				lightDict.Add (randomNumber, newChild);

				PrintDictionary ();
				break;

			case Type.removeLight:
				Debug.Log ("clicked remove light button");

				if (lightDict.Count > 0) {
					lightDict.Remove (int.Parse(OpenMenu.currentObj.name));
					Destroy(OpenMenu.currentObj);
					Debug.Log("Removed light");
				} else {
					Debug.Log ("You can't delete your last light");
				}
				PrintDictionary ();

//				if (gameObj == null){
//					lightsArray.Find(item => item.name == buttonName).SetActive(true);
//					hiddenObjects.Remove(gameObj);
//				}
//				else{
//					hiddenObjects.Add(gameObj);
//					gameObj.SetActive (false);
//				}
				break;

			case Type.brighter:
				if (light.intensity < 8.1) {
					light.intensity += 0.3f;
				}
				Debug.Log ("The Light's intensity is: " + light.intensity);
				break;

			case Type.dimmer:
				if (light.intensity > 0.1) {
					light.intensity -= 0.3f;
				}
				Debug.Log ("The Light's intensity is: " + light.intensity);
				break;

			case Type.cooler:

				//light[0] = red
				//light[1] = green
				//light[2] = blue
				//light[3] = alpha

				red = light.color [0] - .01f;
				green = light.color [1] - .01f;
				blue = light.color [2] + .01f;
				alpha = light.color [3];

				light.color = new Color(red, green, blue, alpha);
				Debug.Log ("The Light's color is: " + light.color);
				break;

			case Type.warmer:

				//light[0] = red
				//light[1] = green
				//light[2] = blue
				//light[3] = alpha
				// Yellow. RGBA is (1, 0.92, 0.016, 1)

				red = light.color [0] + .01f;
				green = light.color [1] + .009f;
				blue = light.color [2] - .01f;
				alpha = light.color [3];

				light.color = new Color(red, green, blue, alpha);
				Debug.Log ("The Light's color is: " + light.color);
				break;
//			case Type.SetFrame:
//				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;
//
//				FindDistance track = new FindDistance ();
//				float distance = track.getDistanceBetween (Camera.main, parentObj);
//				//heading = parentObj.transform.position - Camera.main.transform.position;
//				//distance = Vector3.Dot (heading, Camera.main.transform.forward);
//				Camera.main.nearClipPlane = distance;
//				Debug.Log ("Distance: " + distance);
//				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
//				break;
//
//			case Type.ZoomIn:
//				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;
//
//				heading = parentObj.transform.position - Camera.main.transform.position;
//				distance = Vector3.Dot (heading, Camera.main.transform.forward);
//				Camera.main.nearClipPlane += 0.02f;
//				Debug.Log ("Distance: " + distance);
//				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
//				break;
//
//			case Type.ZoomOut :
//				parentObj = GameObject. FindGameObjectWithTag(buttonName).transform.parent.gameObject;
//
//				heading = parentObj.transform.position - Camera.main.transform.position;
//				distance = Vector3.Dot (heading, Camera.main.transform.forward);
//				Camera.main.nearClipPlane -= 0.02f;
//				Debug.Log ("Distance: " + distance);
//				Debug.Log ("Near Clip Plane: " + Camera.main.nearClipPlane);
//				break;

			default : /* Optional */
				break;
			}
		}

	}



}