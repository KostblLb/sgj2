using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 1;

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
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.GetComponent<Goal>() != null)
        {
            TryGoToNextLevel();
        }
    }

    private void TryGoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log(moveHorizontal);
        flip(moveHorizontal);
        anim.SetBool("isWalking", moveHorizontal != 0);
        rgbd.velocity = new Vector2(moveHorizontal, 0) * speed;
        //rgbd.AddForce(new Vector2(moveHorizontal, 0) * speed);
    }

    private void flip(float mHorizintal) {
        if (mHorizintal == 0) {
            return;
        }

        sRend.flipX = mHorizintal < 0;
    }
}
