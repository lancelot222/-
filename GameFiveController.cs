using UnityEngine;
using System.Collections;

public class GameFiveController : MonoBehaviour {

	public GameObject deadline;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		Vector3 current = deadline.transform.position;
		current = current + (new Vector3 (0.3f, 0, 0));
		deadline.transform.position = current;
	}
}
