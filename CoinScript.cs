using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	private Transform player;
	public float speed = 1000;
	public float gogogo = 30;
	public float gogogoDis = 10;
	public GameObject origin;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (player.position, transform.position);
		
		if (distance < gogogoDis) 
		{
			Vector3 dir = (player.position - transform.position).normalized;
			transform.position = dir * gogogo * Time.deltaTime + transform.position;
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			AudioController._instance.PlayCollectable();
			Instantiate(origin, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
