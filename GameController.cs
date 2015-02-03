using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController _instance;
	//public Text score;
	public Text gate;
	public Text time, costTime, enegy;
	public float cost = 0;
	public int blueBuff = 0;
	public int Awards = 0;
	//public int hp = 1000000;
	public bool isSpeedUp = false;
	public float speedUpTime = -1;

	public string thisGate;
	public string nextGate;

	private bool feibiaoFlyRight;

	public int MP;
	public Scrollbar mpObject;
	public GameObject player;



	void Awake()
	{
		StartCoroutine ("BackUp");
		_instance = this;
		gate.text = "第 " + thisGate + " 关";
		cost = 0;
		feibiaoFlyRight = true;
		MP = 100;

	}

	void Update()
	{
		//score.text = "血量: " + hp.ToString ();

		if(Time.timeScale == 0)
		{
			return;
		}

		if (speedUpTime > 0) {
			speedUpTime -= Time.deltaTime;
			time.text = "Freeze!!!  " + speedUpTime.ToString();
		} else {
			isSpeedUp = false;
			time.text = "";
			cost += Time.deltaTime;
		}
		
		costTime.text = "Time  " + cost.ToString();
		enegy.text = MP.ToString ();

		mpObject.size = MP / 100.0f;


	}

	public IEnumerator BackUp()
	{
		yield return new WaitForSeconds (1f);
		if (MP < 100) 
		{
			MP++;
		}
		StartCoroutine ("BackUp");
	}

	public void setFbFlyRight(bool right)
	{
		feibiaoFlyRight = right;
	}

	public bool canThrow()
	{
		if (MP >= 10) 
		{
			MP -= 10;
			return true;
		}
		return false;
	}

	public bool getFbFlyRight()
	{
		return feibiaoFlyRight;
	}

	// Award
	public void AddAward()
	{
		Awards++;
	}
	public int GetAward()
	{
		return Awards;
	}

	public void SetBlueBuff()
	{
		blueBuff++;
	}

	public int GetBlueBuff()
	{
		return blueBuff;
	}

	public void SetSpeedUpBuff()
	{
		isSpeedUp = true;
		speedUpTime = 5;
	}

	public bool IsSpeedUp()
	{
		return isSpeedUp;
	}

	public void GetAttack()
	{
		//hp--;
		cost += 2;
		//if (hp == 0)
			//Die ();
	}

	public void Die()
	{
		Application.LoadLevel(thisGate);
	}

	public void GateAchieve()
	{
		Application.LoadLevel(nextGate);
	}

	public Vector3 GetPlayerPos()
	{
		return player.transform.position;
	}

	/*void OnGUI()
	{
		// 游戏控制界面
		Event e = Event.current;
		if ((GUI.Button (new Rect (0, 0, 0, 0), "") || e.isKey) )
		{
			Time.timeScale = 1;
		}
		if (GUI.Button (new Rect (0, 0, 0, 0), "") || e.keyCode.ToString() == "P")
		{
			Time.timeScale = 0;
		}
	}*/
}
