using UnityEngine;
using System.Collections;

public class RandomEnemy : MonoBehaviour {

	public GameObject bang;
	//public GameObject poof;
	public GameObject player;


	// Use this for initialization
	void Start () {
		StartCoroutine ("RandomBang");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator RandomBang()
	{
		yield return new WaitForSeconds(1f);
		Vector3 bangPos = player.transform.position + (new Vector3 (100, Random.Range (-2, 5), 0));
		//Vector3 poofPos = new Vector3(player.transform.position.x + 50)
		Instantiate (bang, bangPos, Quaternion.identity);
		//Instantiate (poof, bangPos, Quaternion.identity);
		StartCoroutine ("RandomBang");
	}
}
