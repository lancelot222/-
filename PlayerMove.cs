using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float force_move = 50;
    private Animator anim;
    public float jumpVelocity = 20;
    public bool isGround = false;
	public bool isWall = false;
	public bool isSlide = false;
	public bool isSold = false;
	private Transform wallTrans;
	private bool canHit;

	public Text shuaidaoText;
	private float xuliTime;

	public GameObject speedorigin;
	public GameObject jumporigin;
	public GameObject feibiao;
	public GameObject superMove;
	//public GameObject attack1;
	//public GameObject thrunder;

	private int canJumps = 1;
	private int jumpCount = 0;

	private bool need2jump, need2dao, need2stop, need2biao;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
		anim.SetBool ("isSold", false);
		canHit = true;
		shuaidaoText.text = "蓄力完成，拔刀斩 C ！"; 

		need2jump = need2dao = need2stop = need2biao = false;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 0)
			return;

		UpdateBlueBuff ();



		float h = Input.GetAxis("Horizontal");
		print (h);
		if(isSlide == false){
			//不在滑行的时候

			bool speedUp = GameController._instance.IsSpeedUp();
			float upSpeed = 0;
			if(speedUp)
			{
				upSpeed = 120;
				Instantiate(speedorigin, transform.position, Quaternion.identity);
			}

			//if(h < 0.05f && h > -0.05f)
			//	h = DirectionController._instance.hor;

			if (h > 0.05f)
	        {
				GameController._instance.setFbFlyRight(true);
	            rigidbody2D.AddForce(Vector2.right * (force_move + upSpeed));
	            transform.localScale = new Vector3(1, 1, 1);
	        }
			else if (h < -0.05f)
	        {
				GameController._instance.setFbFlyRight(false);
				rigidbody2D.AddForce(-Vector2.right * (force_move + upSpeed));
	            transform.localScale = new Vector3(-1, 1, 1);
	        }

	        Vector2 velocity = rigidbody2D.velocity;
			anim.SetFloat("vertical", velocity.y);
			print(velocity.y);
	        anim.SetFloat("horizontal", Mathf.Abs(h));


			if (isSold == false && ((jumpCount <= canJumps) || isGround) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || need2jump))
	        {
				need2jump = false;
				isGround = false;
				anim.SetBool("isGround", false);
				//Handheld.Vibrate();
	            Vector2 tvelocity = rigidbody2D.velocity;
				tvelocity.y = jumpVelocity + GameController._instance.GetAward()*1f;
	            rigidbody2D.velocity = tvelocity;
				AudioController._instance.PlayJump();

				Instantiate(jumporigin, transform.position, Quaternion.identity);

				jumpCount++;
	        }

			if(Input.GetKeyDown(KeyCode.Z))
			{
				//Instantiate(thrunder, transform.position + transform.forward * 10, Quaternion.identity);
			}
	
			anim.SetFloat("vertical", rigidbody2D.velocity.y);

			if((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton1) || need2biao)&& GameController._instance.canThrow())
			{
				need2biao = false;
				Vector2 pp = transform.position;
				pp.x += GameController._instance.getFbFlyRight() == true ? 3 : -3;
				Instantiate(feibiao, pp, Quaternion.identity);
			}

			if((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton2) || need2dao) && canHit)
			{

				AudioController._instance.PlayShuaiDao();
				anim.SetBool ("attacking1", true);
				canHit = false; 
 				xuliTime = 0;
				StartCoroutine("AutoStopDao");
				/*Vector2 pp = transform.position;
				pp.x += 2.08f;
				pp.y += 3.16f;
				Instantiate(attack1, pp, Quaternion.identity);*/
			}

			if(Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.JoystickButton2))
			{
				anim.SetBool ("attacking1", false);
			}

			need2jump = false;
			need2dao = false;
			need2biao = false;
		}
		else
		{
			//在墙上滑行的时候 
		}

		if(isWall == false || isGround == true)
		{
			isSlide = false;
		}

		if(canHit)
		{
			shuaidaoText.text = "蓄力完成，拔刀斩 C ！";
		}
		else
		{
			xuliTime += Time.deltaTime;
			shuaidaoText.text = xuliTime.ToString();
			if(xuliTime > 1f)
			{
				canHit = true;
			}
		}


	}

	IEnumerator AutoStopDao()
	{
		yield return new WaitForSeconds (0.07f);
		anim.SetBool ("attacking1", false);
		need2dao = false;
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground") 
		{
			isGround = true;
			if(col.transform.position.y < transform.position.y)
				jumpCount = 0;
		} 
		else if (col.collider.tag == "Wall") 
		{
			isWall = true;
			rigidbody2D.velocity = Vector2.zero;
			wallTrans = col.collider.transform;

			//ChangeDir();
		}else if(col.collider.tag == "Sold")
		{
			rigidbody2D.drag = rigidbody2D.drag*2;
			isSold = true;
		}else if(col.collider.tag == "DieLine")
		{
			GameController._instance.Die();
		}
		anim.SetBool ("isSold", isSold);
		anim.SetBool ("isGround", isGround);
		anim.SetBool ("isWall", isWall);
    }

	public void OnCollisionExit2D(Collision2D col)
    {
		if (col.collider.tag == "Ground") 
		{
			isGround = false;
		} 
		else if (col.collider.tag == "Wall") 
		{
			isWall = false;
		}else if(col.collider.tag == "Sold")
		{
			rigidbody2D.drag = rigidbody2D.drag/2;
			isSold = false;
		}
		anim.SetBool ("isSold", isSold);
		anim.SetBool ("isGround", isGround);
		anim.SetBool ("isWall", isWall);
    }

	public void ChangeDir()
	{
		isSlide = true;
		transform.localScale = new Vector3(1, 1, 1);
		if (wallTrans.position.x < transform.position.x) 
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		else
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "DieLine")
		{
			GameController._instance.Die();
		}
	}

	void UpdateBlueBuff ()
	{
		canJumps = GameController._instance.GetBlueBuff ();
	}	

	public void OnGUIJumpPress()
	{
		need2biao = false;
		need2jump = true;
		need2dao = false;

	}

	public void OnGUIFeiBiaoPress()
	{
		need2biao = true;
		need2jump = false;
		need2dao = false;
	}

	public void OnGUIStopPress()
	{
		PauseController._instace.clicked = true;
	}

	public void OnGUIDaoPress()
	{
		need2biao = false;
		need2jump = false;
		need2dao = true;
	}
}
