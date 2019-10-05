using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    PlayerController player;

    public bool CanGoLeft = false;
    public bool CanGoRight = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var hSpeed = 0f;
        if (Input.GetAxis("Horizontal") != 0) hSpeed = Mathf.Sign(Input.GetAxis("Horizontal")) * player.speed;
        if ((hSpeed > 0 && !CanGoRight) || (hSpeed < 0 && !CanGoLeft)) return;
        playerRigidbody.AddForce(new Vector2(hSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
    }
    
}
