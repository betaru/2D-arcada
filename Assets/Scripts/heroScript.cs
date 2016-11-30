using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {

	public float speed = 10f;
	public float jumpHeigt = 700f;
	Rigidbody2D rig;
	bool grounded = false;
	bool facingRight = true;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public int score = 0;
	float posX, posY;


	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		posX = rig.position.x;
		posY = rig.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis ("Horizontal");

//		if (grounded) {			
			rig.velocity = new Vector2 (move * speed, rig.velocity.y);			
//		}


		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			rig.AddForce(new Vector2(0, jumpHeigt));
		}

		if ((move < 0) && facingRight) {
			Flip();
		} else if ((move > 0) && !facingRight) {
			Flip();	
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

//	for enemy
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "enemy") {
			rig.position = new Vector2 (posX, posY);
		}
	}

//	for star
	void OnTriggerEnter2D(Collider2D col) {
		if (col.GetComponent<PolygonCollider2D> ().tag == "star") {
			Destroy (col.gameObject);
			score++;
		}
	}

	void OnGUI() {
		GUI.Box (new Rect(0,0,100,100), "Score = " + score);		
	}
}