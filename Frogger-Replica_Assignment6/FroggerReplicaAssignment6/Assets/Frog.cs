using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;

    void Start()
    {
        transform.localScale = new Vector2(DropDownController.frogSizeMultiplier, DropDownController.frogSizeMultiplier);
    }

	void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow))
			rb.MovePosition(rb.position + Vector2.right);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			rb.MovePosition(rb.position + Vector2.left);
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			rb.MovePosition(rb.position + Vector2.up);
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			rb.MovePosition(rb.position + Vector2.down);

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
            Score.Lives--;
            Score.PointsThisLife = 0;
            Debug.Log("WE LOST!");
            //Score.TotalPoints = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(0, -4, 0);
		}
	}
}
