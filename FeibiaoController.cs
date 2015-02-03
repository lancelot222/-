using UnityEngine;
using System.Collections;

public class FeibiaoController : MonoBehaviour {

	public GameObject effect;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (new Vector2(GameController._instance.getFbFlyRight() == true ? 3000 : -3000, 0));
		Instantiate (effect, transform.position, Quaternion.identity);
		AudioController._instance.PlayFeiBiao ();

		//StartCoroutine ("DestroySelf");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground")
			Destroy (this.gameObject);
	}

	/*public IEnumerator DestroySelf()
	{
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}*/

}
