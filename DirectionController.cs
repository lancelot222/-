using UnityEngine;
using System.Collections;

public class DirectionController : MonoBehaviour
{

	public static DirectionController _instance;
	public float hor;

	void Awake()
	{
		_instance = this;
	}

	void OnEnable ()
	{  
		EasyJoystick.On_JoystickMove += On_JoystickMove;  
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;  
	}  
		
	void OnDisable ()
	{  
		EasyJoystick.On_JoystickMove -= On_JoystickMove;  
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;  
	}  
		
	void OnDestroy ()
	{  
		EasyJoystick.On_JoystickMove -= On_JoystickMove;      
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;  
	}  
		
		
	void On_JoystickMoveEnd (MovingJoystick move)
	{  
		if (move.joystickName == "Joystick") {  
			hor = 0;
			print ("idle");
		}  
	}  
		
	void On_JoystickMove (MovingJoystick move)
	{  
		if (move.joystickName == "Joystick") {  

			hor = move.joystickAxis.x;
		}
	}  
}
