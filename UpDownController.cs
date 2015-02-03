using UnityEngine;
using System.Collections;

public class UpDownController : MonoBehaviour {

	private float yyup, yydown;
	public float upoffset, downoffset;
	public bool goup;
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		goup = false;
		yyup 	= transform.position.y + upoffset;
		yydown 	= transform.position.y - downoffset; 
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		if(transform.position.y < yydown)
		{
			goup = true;
		}

		if(transform.position.y > yyup)
		{
			goup = false;
		}
		
		Vector3 pp = transform.position;
		pp.y += (goup ? 1 : -1) * speed;
		transform.position = pp; 
	}
}
