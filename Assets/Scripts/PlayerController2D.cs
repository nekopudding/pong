using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    bool hitBottom;
    bool hitTop;
    float vdirection;
    LayerMask wallLayer;


    [Range(0,5)][SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        wallLayer = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update() {
        vdirection = Input.GetAxisRaw("Vertical");

        this.hitBottom = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y, wallLayer).collider != null;
        this.hitTop = Physics2D.Raycast(coll.bounds.center, Vector2.up, coll.bounds.extents.y, wallLayer).collider != null;
    }
    void FixedUpdate() {
        Move();
	}
    void Move() {
        if (vdirection > 0 && !hitTop)
            rb.velocity = new Vector2(0f, speed);
        else if (vdirection < 0 && !hitBottom)
            rb.velocity = new Vector2(0f, -speed);
        else
            rb.velocity = Vector2.zero;
    }
}


//ball
//as time progresses speed ramps up
//starts random direction towards player