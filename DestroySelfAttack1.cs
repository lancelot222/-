using UnityEngine;
using System.Collections;

public class DestroySelfAttack1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroySelfAttack()
	{
		Destroy (this.gameObject);
	}
}
