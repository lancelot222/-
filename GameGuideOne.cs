using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuideOne : MonoBehaviour {

	public Text guideText;
	public GameObject player;
	public int stepNow;

	// Use this for initialization
	void Start () {
		stepNow = 0;
		guideText.text = "按下空格可以跳跃，左右箭头控制方向。跳过去吧~年轻的忍者！！！";
	}
	
	// Update is called once per frame
	void Update () {
		if(stepNow == 0)
		{
			if(player.transform.position.x > -140f)
			{
				stepNow = 1;
				guideText.text = "拿到蓝色获得永久连跳加一的BUFF。勇敢的跳过去吧！";
			}
		}else if(stepNow == 1)
		{
			if(player.transform.position.x > -70f)
			{
				stepNow = 2;
				guideText.text = "拿到红色的获得永久弹跳高度加一BUFF。这次向上跳吧！！！";
			}
		}else if(stepNow == 2)
		{
			if(player.transform.position.x > -15f)
			{
				stepNow = 3;
				guideText.text = "这个蓝色的BUFF可以让你活得短暂的加速，注意你的左上角的Freeze！";
			}
		}else if(stepNow == 3)
		{
			if(player.transform.position.x > 243f)
			{
				stepNow = 4;
				guideText.text = "进到门内就会进入下一个试炼。注意！这个试炼中获得的BUFF不会带到下一个试炼中！！！祝你好运！";
			}
		}
	}
}
