using UnityEngine;
using System.Collections;

public class GameSixController : MonoBehaviour {

	public GameObject bang, bang2;
	public GameObject player;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Hithithit");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Hithithit()
	{


		yield return new WaitForSeconds (1f);

		Vector3 bangPos = (new Vector3 (player.transform.position.x + 100, 10, 0));
		Vector3 bangPos2 =(new Vector3 (player.transform.position.x - 100, 10, 0));
		Instantiate (bang, bangPos, Quaternion.identity);
		Instantiate (bang2, bangPos2, Quaternion.identity);
		yield return new WaitForSeconds (1f);
		bangPos = (new Vector3 (player.transform.position.x + 100, 10, 0));
		bangPos2 =(new Vector3 (player.transform.position.x - 100, 10, 0));
		Instantiate (bang, bangPos, Quaternion.identity);
		Instantiate (bang2, bangPos2, Quaternion.identity);
		yield return new WaitForSeconds (1f);
		bangPos = (new Vector3 (player.transform.position.x + 100, 10, 0));
		bangPos2 =(new Vector3 (player.transform.position.x - 100, 10, 0));
		Instantiate (bang, bangPos, Quaternion.identity);
		Instantiate (bang2, bangPos2, Quaternion.identity);
		StartCoroutine ("Hithithit");

	}
}
