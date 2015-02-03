using UnityEngine;
using System.Collections;

public class GoGoGo : MonoBehaviour {

	public float force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		//Vector3 curr = transform.position;
		//curr += new Vector3 (-1, 0, 0);
		//transform.position = curr;
		rigidbody2D.AddForce (new Vector2 (-force, 0));
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "DieLine")
			Destroy (this.gameObject);
		else
			rigidbody2D.AddForce (new Vector2 (0, Random.Range(-1, 1) > 0 ? 5 : -5));
	}
}
