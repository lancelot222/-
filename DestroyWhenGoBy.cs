using UnityEngine;
using System.Collections;

public class DestroyWhenGoBy : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pp = GameController._instance.GetPlayerPos();
		if(pp.x > transform.position.x)
		{
			Destroy(this.gameObject);
		}
	}
}
