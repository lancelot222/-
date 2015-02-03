using UnityEngine;
using System.Collections;

public class MovePlay : MonoBehaviour {

	//电影纹理
	public MovieTexture movTexture;

	void Start()
	{
		//设置电影纹理播放模式为循环
		movTexture.loop = false;
		StartCoroutine ("SwitchLevel");
	}
	
	void OnGUI()
	{
		//绘制电影纹理
		GUI.DrawTexture (new Rect (0,0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);  
		movTexture.Play ();

	}
	
	public IEnumerator SwitchLevel()
	{
		yield return new WaitForSeconds (6f);
		Application.LoadLevel ("getStart");
	} 
}
