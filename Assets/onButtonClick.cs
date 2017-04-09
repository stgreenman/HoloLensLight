using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule
{
	public enum TypeOfButton
	{
		Hide,
		Lock
	}
	
	public enum TagSelection2
	{
		head, 
		upperCranium, 
		lowerCranium
	}
	public class OnButtonClick : MonoBehaviour, IInputClickHandler
	{
		public TypeOfButton typeOfButton;
		//private ScriptableObject script = (script)GameObject.FindGameObjectWithTag;

		public void OnInputClicked(InputClickedEventData eventData)
		{    
			string buttonName = typeOfButton.ToString();
			GameObject gameObj = GameObject.FindGameObjectWithTag(buttonName);
			Debug.Log ("Printed nameOfButton: " + buttonName);


		}

	}
}

