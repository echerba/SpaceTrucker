using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationMenuController : MonoBehaviour {

	public class NavObject
	{
		public Transform Transform;

	}

	// Use this for initialization
	void Start () {
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Destination");

		

		Button navButton = GetComponentInChildren<Button>();

		Debug.Log("Found buttons: " + navButton.name);

		GetComponentInChildren<Button>().onClick.AddListener(delegate { NavButtonClick(); });

		//for (int i = 0; i < targets.Length; i++)
		//{
		//	GameObject button = new GameObject();
		//	button.transform.parent = this.gameObject.transform;
		//	button.AddComponent<RectTransform>();
		//	button.AddComponent<Button>();
		//	button.transform.position = Vector3.zero;
		//}	
	}
	
	public void NavButtonClick()
	{
		ShipController.SetDestination(GameObject.FindGameObjectWithTag("Destination").transform);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
