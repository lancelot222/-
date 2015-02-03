using UnityEngine;
using System.Collections;

public class DropController : MonoBehaviour {

	public float preDropDis;
	public GameObject targetPlayer;

	private bool startDrop;
	public float speed;

	// Use this for initialization
	void Start () {
		startDrop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		if(transform.position.x - 5 < targetPlayer.transform.position.x)
		{
			startDrop = true;
		}

		if(startDrop)
		{
			Vector3 pp = transform.position;
			pp.y += speed;
			transform.position = pp;
		}

		if(transform.position.y + 200 < targetPlayer.transform.position.y)
		{
			Destroy(this.gameObject);
		}
	}
}
