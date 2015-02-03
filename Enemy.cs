using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform player;
	private Animator anim;
	public float attackDis = 15;
	public float speed = 5;
	public GameObject origin, dieeffect;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 0)
		{
			return;
		}

		float distance = Vector3.Distance (player.position, transform.position);

		if (distance < attackDis) 
		{
			anim.SetBool("Run", true);
			if(player.position.x < transform.position.x){
				transform.localScale = new Vector3(-1, 1, 1);
			}else{
				transform.localScale = new Vector3(1, 1, 1);
			}

			Vector3 dir = (player.position - transform.position).normalized;
			transform.position = dir * speed * Time.deltaTime + transform.position;
		}
		else
		{
			anim.SetBool("Run", false);
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "Player" && player.position.y > transform.position.y + 3)
		    || col.tag == "Feibiao"
		    || col.tag == "AttackEffect") {
			AudioController._instance.PlayEnemyDie ();

			Instantiate(origin, transform.position, Quaternion.identity);
			Instantiate(dieeffect, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
		else 
		{
			GameController._instance.GetAttack();
			//Application.LoadLevel("001");
		}
	}
}
