using UnityEngine;
using System.Collections;

public class Thrunderbolt : MonoBehaviour {

	public ParticleSystem thunder;
	public GameObject player;

	void Start () {
		StartCoroutine ("TakeThunder");
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		if(thunder.renderer.enabled == true && 
		   Mathf.Abs(thunder.transform.position.x - player.transform.position.x) < 0.5f &&
		   thunder.transform.position.y < player.transform.position.y)
		{
			GameController._instance.Die();
		}



		/*if(Input.GetKeyDown(KeyCode.X))
		{
			thunder.renderer.enabled = false;
		}

		if(Input.GetKeyUp(KeyCode.X))
		{
			thunder.renderer.enabled = true;
			//thunder.loop = true;
			//thunder.Play();
		}*/
	}

	public IEnumerator TakeThunder()
	{
		yield return new WaitForSeconds(2f);
		if(thunder.renderer.enabled == true)
		{
			thunder.renderer.enabled = false;
		}
		else
		{
			thunder.renderer.enabled = true;
		}
		StartCoroutine ("TakeThunder");
	}
}
