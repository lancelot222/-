using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float delay;

	// Use this for initialization
	void Start () {
		StartCoroutine ("DestroySuperMove");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator DestroySuperMove()
	{
		yield return new WaitForSeconds(delay);
		Destroy(this.gameObject);
	}
}
