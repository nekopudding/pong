using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    Rigidbody2D rb;
    Collider2D coll;
    [Range(0, 10)] [SerializeField] float initialSpeed;
    [SerializeField] float currentSpeed;
    [Range(0,2)][SerializeField] float speedRamp = 0.1f;
    bool isOnPlayer;
    Vector2 playerPosition;
    float angle;
    [Range(0,2)][SerializeField] float angleMultiplier;
    float playerBoundsY;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed;
        coll = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(initialSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

	private void FixedUpdate() {
		if(isOnPlayer) {
            //change reflection angle based on position relative to player
            angle = Mathf.PI/2*(this.transform.position.y - playerPosition.y) / playerBoundsY/2 * angleMultiplier;
            currentSpeed = currentSpeed + speedRamp;
            rb.velocity = new Vector2(-Mathf.Cos(angle),Mathf.Sin(angle)).normalized * currentSpeed;
            isOnPlayer = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
            playerPosition = collision.transform.position;
            playerBoundsY = collision.collider.bounds.extents.y;
            isOnPlayer = true;
		}
	}
}
