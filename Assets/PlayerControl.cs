using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	// controls move speed for user
	public float MoveSpeed = 3f;
	// controls both velocity and horizontal values of object
	float velX;
	float velY;
	// controls sprite flipping from right or left 
	bool facingRight = true;

	// gets velocity value to move sprite 
	Rigidbody2D rigBody;



    // Start is called before the first frame update
    void Start()
    {
		//initialize rigid body for access to it 
		rigBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
		
    {
		// horizontal and vertical speed passed to rigid body 
		velX = Input.GetAxisRaw("Horizontal");
		velY = rigBody.velocity.y;
		rigBody.velocity = new Vector2(velX * MoveSpeed, velY);
        
    }

	void LateUpdate()
	{
		// Getting currrent scale 
		Vector3 localScale = transform.localScale;
		// checking if velocity is positive or negative 
		if (velX > 0)
		{
			facingRight = true;
		} else if (velX < 0)
		{
			facingRight = false;

		}
		// checking if scale and movememnt match if not it changes scale by multiplying by -1 
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x < 0)))
		{
			localScale.x *= -1;
		}
		//updated local scale 
		transform.localScale = localScale;
	}
}
