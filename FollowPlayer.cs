using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float smoothing = 3;
	private Transform player;

	//public GameObject moon;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		Vector3 targetPos = player.position + new Vector3 (0, 0, -10);
		transform.position = Vector3.Lerp (transform.position, targetPos, smoothing);
		//moon.transform.position = player.position + new Vector3(10, 10, 1);
	}
}
