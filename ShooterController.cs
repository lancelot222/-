using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {
	
	public float shootSpeed;
	public GameObject feibiao;

	// Use this for initialization
	void Start () {
		StartCoroutine ("CreateFeibiao"); 
	}
	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator CreateFeibiao()
	{
		yield return new WaitForSeconds(shootSpeed);
		Vector3 dir = (GameController._instance.GetPlayerPos() - transform.position);
		if(Mathf.Sqrt(dir.x*dir.x + dir.y*dir.y + dir.z*dir.z) < 20)
			Instantiate(feibiao, transform.position, Quaternion.identity);
		StartCoroutine ("CreateFeibiao");
	}
}
