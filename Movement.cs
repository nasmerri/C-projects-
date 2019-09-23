using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed; //  creates a public float called speed that will appear in the hierarchy for user to change
	private Rigidbody2D rb2d;// creates a private that is only avalible in the script to obtain rididbody 2d under the name rb2d
	private Vector2 moveInput;// created a vector2 called moveInput

	private bool on = false;// creates a private bool called on and set it to false
	public GameObject ship;// creates a public gameobject called ship so we can insert spaceShip here
	private bool activateit; //  creates a private bool called activateit

	private bool dash = false;// creataes a private bool called dash and its set to false

	// Start is called before the first frame update
	void Start()
	{
		speed = 10f;// once the game starts, speed is set to 10
		rb2d = GetComponent<Rigidbody2D>();// this will get the rigidbody 2d for us

	}

	// Update is called once per frame
	private void Update()
	{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // collects user input for asdw and arrow keys and calls them moveinput
		this.moveInput = moveInput.normalized * speed; // this will take our move input and multiply it by our speed


		TurnOffStarShip();// created methid that will run when activated
		Dash();// created method that will run when activated
		Freeze();// created method that will run when activated
	}

	private void FixedUpdate() //  this is used when were using physics
	{
		rb2d.MovePosition(rb2d.position + moveInput * Time.fixedDeltaTime); // this will move our gameobject for use in relation to our current postion once moved

	}

	void Freeze()
	{
		if (Input.GetKey(KeyCode.P))// this will collect user input when they press the p key
		{
			if (on)
			{
				speed = 0f;// speed is set to 0
				on = false;// bool is now changed to false
				print("Game Froze");
			}
			else
			{
				speed = 10f;// speed is set to 10
				on = true;// bool is now changed to true
				print("Game not froze");
			}

		}    
	}


	void TurnOffStarShip()
	{
		if (Input.GetKeyDown(KeyCode.Q))// this will collect user input when they press the Q key
		{
			if (activateit == true)// if bool is true
			{
				ship.SetActive(true);// game object will be active

			}
			else
			{
				ship.SetActive(false);// game object will be deactivated
				print("Ship is gone");
			}
		}

	}

	void Dash()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))// this will collect user input when they press the left shift or right shift key
		{
			if (dash)
			{
				speed = 1f;// speed is now 1 unit
				dash = false;// bool is false
				print("Dash Not acive");
			}
			else// start else
			{
				speed = 10f;// speed is now 10 units
				dash = true;// bool is true
				print("Dash active");
			}
		}
	}
}

