using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public static AudioController _instance;
	public AudioSource audioSource;
	public AudioClip collectiblCilp;
	public AudioClip jumpClip;
	public AudioClip enemyDieClip;
	public AudioClip playerDieClip;
	public AudioClip backgroundClip;
	public AudioClip deathClip;
	public AudioClip feibiao;
	public AudioClip shuaidao;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		_instance = this;
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlayShuaiDao()
	{
		audioSource.PlayOneShot (shuaidao);
	}

	public void PlayCollectable()
	{
		audioSource.PlayOneShot (collectiblCilp);
	}

	public void PlayFeiBiao()
	{
		audioSource.PlayOneShot (feibiao);
	}

	public void PlayJump()
	{
		audioSource.PlayOneShot (jumpClip);
	}

	public void PlayEnemyDie()
	{
		audioSource.PlayOneShot (enemyDieClip);
	}

	public void playDeath()
	{
		audioSource.PlayOneShot (deathClip);
	}
}
