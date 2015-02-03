using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public static PauseController _instace;

	private bool pauseOrNot;
	private Animator anim;
	public bool clicked;

	// Use this for initialization
	void Start () {
		_instace = this;
		pauseOrNot = false;
		anim = this.GetComponent<Animator>();
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pp = GameController._instance.GetPlayerPos ();
		pp.z -= 8;
		transform.position = pp;

		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton3) || clicked)
		{
			clicked = false;
			if(pauseOrNot == false)
			{
				pauseOrNot = true;
				anim.SetBool("isPlaying", false);
				StartCoroutine("ChangePauseStat");
			}
			else if(Time.timeScale == 0)
			{
				pauseOrNot = false;
				Time.timeScale = 1;
				anim.SetBool("isPlaying", true);
			}
		}
	}

	public IEnumerator ChangePauseStat()
	{
		yield return new WaitForSeconds (0.21f);
		Time.timeScale = 0;
	}
}
