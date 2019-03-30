using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public float minSpeed;
	public float maxSpeed;

	float speed = 1f;

	void Start ()
	{
        if(StartMenuManager.easyDifficulty == true)
        {
            minSpeed = 8f;
            maxSpeed = 12f;
        }
        else if(StartMenuManager.mediumDifficulty == true)
        {
            minSpeed = 16f;
            maxSpeed = 20f;
        }
        else if(StartMenuManager.hardDifficulty == true)
        {
            minSpeed = 24f;
            maxSpeed = 28f;
        }
		speed = Random.Range(minSpeed, maxSpeed);
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

}
