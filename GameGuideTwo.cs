using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuideTwo : MonoBehaviour {

	public Text guideText;
	public GameObject player;
	public int stepNow;
	
	// Use this for initialization
	void Start () {
		stepNow = 0;
		guideText.text = "按下C键可以施展拔刀斩！！！";
	}
	
	// Update is called once per frame
	void Update () {
		if(stepNow == 0)
		{
			if(player.transform.position.x > -120f)
			{
				stepNow = 1;
				guideText.text = "按下X键可以发射飞镖\n飞镖会消耗能量，能量每秒恢复1点\n干掉前面的怪物吧（你也可以踩死他们）！！！\nPS: 碰到不会死亡";
			}
		}else if(stepNow == 1)
		{
			if(player.transform.position.x > -90f)
			{
				stepNow = 2;
				guideText.text = "红色的物理会让你死亡！！！死亡！！！！！！\nPS: 有些还会动哦~";
			}
		}else if(stepNow == 2)
		{
			if(player.transform.position.x > -50)
			{
				stepNow = 3;
				guideText.text = "前方神奇的机关每隔一秒会发射一枚飞镖！触及死亡！！！";
			}
		}else if(stepNow == 3)
		{
			if(player.transform.position.x > 15)
			{
				stepNow = 4;
				guideText.text = "注意：有些黑色的地面由于每种神奇的原因，每隔一秒会切换状态\n存在 或 不存在！";
			}
		}else if(stepNow == 4)
		{
			if(player.transform.position.x > 78f)
			{
				stepNow = 5;
				guideText.text = "技巧：在空中碰到黑色地面的侧面可以刷新跳跃！";
			}
		}else if(stepNow == 5)
		{
			if(player.transform.position.x > 100f)
			{
				stepNow = 6;
				guideText.text = "正式的试炼就在前方！去定义你的忍道吧！！！";
			}
		}
	}
}
