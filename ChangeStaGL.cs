using UnityEngine;
using System.Collections;

public class ChangeStaGL : MonoBehaviour {

	private bool render = true;
	public float delay, conti;

	// Use this for initialization
	void Start () {
		StartCoroutine ("DDelay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator DDelay()
	{
		yield return new WaitForSeconds (delay);
		StartCoroutine ("Change");
	}

	public IEnumerator Change()
	{
		yield return new WaitForSeconds(conti);
		if (render == true) 
		{
			this.gameObject.renderer.enabled = false;
			this.gameObject.collider2D.enabled = false;
			render = false;
		}
		else
		{
			this.gameObject.renderer.enabled = true;
			this.gameObject.collider2D.enabled = true;
			render = true;
		}
		StartCoroutine ("Change");

	}
}
