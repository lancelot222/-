using UnityEngine;
using System.Collections;

public class OnClickStart : MonoBehaviour {
	public string str;
	// Use this for initialization
	void Start () {
		//label = GameObject.FindGameObjectWithTag ("PopList").guiText;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick()
	{
		Application.LoadLevel ("001");
		print ("aaaaaaaaaaaaa");
	}
}
