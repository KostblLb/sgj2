using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public bool CanGoLeft = false;
    public bool CanGoRight = false;
    public bool ReverseHInput = false;
    public bool CanJump = false;
    public float PublicJumpForce = 75;
    public float gapBetweenJumps = 1f;

    private bool ReadyToJupm = false;
    private float deltaTimeBeforeJump = 0f;

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
        float mVertical = Input.GetAxisRaw("Vertical");
        flip(mHorizontal);
        Move(mHorizontal, mVertical);
        animate(mHorizontal);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == ("ground") && ReadyToJupm == false && deltaTimeBeforeJump < gapBetweenJumps) {
            deltaTimeBeforeJump += Time.deltaTime;
        } else if (col.gameObject.tag == ("ground") && ReadyToJupm == false && deltaTimeBeforeJump >= gapBetweenJumps) {
            deltaTimeBeforeJump = 0f;
            ReadyToJupm = true;
        }
    }

    void Move(float mHorizontal, float mVertical) {
        if ((mHorizontal > 0 && !CanGoRight) || (mHorizontal < 0 && !CanGoLeft)) {
            return;
        }

        float jumpForce = 0;
        if (ReadyToJupm && CanJump && mVertical > 0)
        {
            jumpForce = PublicJumpForce;
            ReadyToJupm = false;
        }

        rgbd.AddRelativeForce(new Vector2((ReverseHInput ? -1 : 1) * mHorizontal * Time.fixedDeltaTime, jumpForce), ForceMode2D.Impulse);
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
