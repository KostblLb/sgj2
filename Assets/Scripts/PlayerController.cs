using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public bool CanGoLeft = false;
    public bool CanGoRight = false;

    Rigidbody2D rgbd;
    SpriteRenderer sRend;
    Animator anim;

    // Use this for initialization
    void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        processMoving();
        checkGameOver();
    }

    void processMoving() {
        float mHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        flip(mHorizontal);
        Move(mHorizontal);
        animate(mHorizontal);
    }

    void Move(float mHorizontal) {
        if ((mHorizontal > 0 && !CanGoRight) || (mHorizontal < 0 && !CanGoLeft)) {
            return;
        }

        rgbd.AddForce(new Vector2(mHorizontal * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
    }

    private void flip(float mHorizontal) {
        if (mHorizontal == 0) {
            return;
        }

        sRend.flipX = mHorizontal < 0;
    }

    void animate(float mHorizontal) {
        anim.SetBool("isWalking", mHorizontal != 0);
    }

    void checkGameOver() {
        if (rgbd.transform.position.y <= -6) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
