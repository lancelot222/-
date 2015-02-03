using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	public GameObject origin;
	public GameObject explossion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			AudioController._instance.PlayCollectable();
			GameController._instance.SetSpeedUpBuff();
			Instantiate(origin, transform.position, Quaternion.identity);
			Instantiate(explossion, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
