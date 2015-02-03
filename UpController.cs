using UnityEngine;
using System.Collections;

public class UpController : MonoBehaviour {

	public float preDropDis, endy;
	public GameObject targetPlayer;
	
	private bool startUp;
	public float speed;
	
	// Use this for initialization
	void Start () {
		startUp = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		if(transform.position.x - preDropDis < targetPlayer.transform.position.x
		   && transform.position.y < endy)
		{
			startUp = true;
		}
		
		if(startUp)
		{
			Vector3 pp = transform.position;
			pp.y += speed;
			transform.position = pp;
		}
		
		if(transform.position.y > endy)
		{
			startUp = false;
		}
	}
}
