using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public float minSpeed = 8f;
    //public float maxSpeed = 12f;
    public float maxSpeed = DropDownController.carSpeed + 4f;

    float speed = 1f;

	void Start ()
	{
        transform.localScale = new Vector2(DropDownController.carSizeMultiplier, DropDownController.carSizeMultiplier);
        speed = Random.Range(DropDownController.carSpeed, maxSpeed);
    }

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

}
