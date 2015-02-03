using UnityEngine;
using System.Collections;

public class Feibiao4ShooterController : MonoBehaviour {

	
	void Start () {
		Vector3 dir = (GameController._instance.GetPlayerPos() - transform.position);
		dir.Normalize ();
		rigidbody2D.AddForce (new Vector2 (1000*dir.x , 1000*dir.y));

		AudioController._instance.PlayFeiBiao ();

	}

	void Update () {
		
	}
	
	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground")
			Destroy (this.gameObject);

	}
}
