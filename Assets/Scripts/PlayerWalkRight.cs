using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkRight : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        var hSpeed = Input.GetAxis("Horizontal") > float.Epsilon ? player.speed : 0;
        playerRigidbody.velocity = new Vector2(hSpeed, playerRigidbody.velocity.y);
    }
}
