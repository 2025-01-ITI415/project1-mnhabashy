using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // public variable for player speed
	public float speed;

	// private reference to player's rigidbody component
	private Rigidbody rb;
	private int count;

	// Start is called before the first frame update
	void Start ()
	{
		// assigns Rigidbody component to private rb variable
		rb = GetComponent<Rigidbody>();

		// Sets count to zero
		count = 0;
	}

	// player physics
	void FixedUpdate ()
	{
		// sets local float variables equal to value of Horizontal and Vertical inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// creates Vector3 variable and assigns X and Z to feature horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// adds physical force to Player rigidbody using "movement" Vector3 above,
		// multiplying it by "speed" - public player speed that appears in inspector
		rb.AddForce (movement * speed);
	}

	// when this game object intersects a collider with "is trigger" checked,
	// store reference to that collider in variable named "other"
	void OnTriggerEnter(Collider other) 
	{
		// if game object intersected has tag "Pick Up" assigned to it
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// makes other game object (the pick up) inactive to make it disappear
			other.gameObject.SetActive (false);

			// adds one to score variable "count"
			count = count + 1;

			// runs "SetCount()" function below
			SetCount();
		}
	}

	void SetCount()
	{
		// checks if "count" is equal to or exceeds 80
		if (count >= 80)
		{
			// restarts game
			SceneManager.LoadScene("Maze");
		}
	}

	void OnCollisionEnter(Collision coll) {
        // finds out what hit player
        GameObject collidedWith = coll.gameObject;
        if ( collidedWith.CompareTag("Bad Guy") ) {
            // restarts game
			SceneManager.LoadScene("Maze");
		}
    }
}