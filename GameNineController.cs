using UnityEngine;
using System.Collections;

public class GameNineController : MonoBehaviour {

	public GameObject autoDestroy;
	public GameObject autoDestroy2;
	public GameObject coinTiles;
	public GameObject player;

	private int stepNow;

	// Use this for initialization
	void Start () {
		stepNow = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(stepNow == 0)
		{
			if(player.transform.position.x > 120f)
			{
				stepNow = 1;
				Destroy(autoDestroy.gameObject);
			}
		}else if(stepNow == 1)
		{
			if(player.transform.position.x > -34f && 
			   player.transform.position.y > 57f)
			{
				stepNow = 2;
				Instantiate(coinTiles, new Vector3(-73.06365f, 123.4989f, 0f), Quaternion.identity);
				Destroy(autoDestroy2);
			}
		}
	}
}
