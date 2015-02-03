using UnityEngine;
using System.Collections;

public class GameFourController : MonoBehaviour {

	public GameObject deadline;

	private bool startGame;

	// Use this for initialization
	void Start () {
		startGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		if(startGame)
		{
			Vector3 current = deadline.transform.position;
			current = current + (new Vector3 (0, 0.3f, 0));
			deadline.transform.position = current;
		}
		else
		{
			Vector3 playerpos = GameController._instance.GetPlayerPos();
			if(playerpos.x + 13 > deadline.transform.position.x)
			{
				startGame = true;
			}
		}
	}
}
