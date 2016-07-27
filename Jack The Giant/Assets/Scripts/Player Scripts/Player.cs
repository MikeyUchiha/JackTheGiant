using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float speed = 8.0f;
	public float maxVelocity = 4.0f;

	private Rigidbody2D myBody;
	private Animator anim;
	private SpriteRenderer sprite;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		PlayerMoveKeyboard();
	}

	void PlayerMoveKeyboard()
	{
		float forceX = 0.0f;
		float vel = Mathf.Abs(myBody.velocity.x);

		float h = Input.GetAxisRaw("Horizontal");

		if(h > 0)
		{
			if(vel < maxVelocity)
			{
				forceX = speed;
			}

			anim.SetBool("Walk", true);
			sprite.flipX = false;
		}
		else if(h < 0)
		{
			if(vel < maxVelocity)
			{
				forceX = -speed;
			}

			anim.SetBool("Walk", true);
			sprite.flipX = true;
		}
		else
		{
			anim.SetBool("Walk", false);
		}

		myBody.AddForce(new Vector2(forceX, 0));
	}
}
