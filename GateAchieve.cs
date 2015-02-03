using UnityEngine;
using System.Collections;

public class GateAchieve : MonoBehaviour {

	public string gototo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			Application.LoadLevel(gototo);
		}
	}
}
