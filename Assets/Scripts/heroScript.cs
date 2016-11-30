using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {

	public float speed = 10f;
	public float jumpHeigt = 700f;
	Rigidbody2D rig;



	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");
		rig.velocity = new Vector2 (move * speed, rig.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)) {
			rig.AddForce(new Vector2(0, jumpHeigt));
		}
	}
}