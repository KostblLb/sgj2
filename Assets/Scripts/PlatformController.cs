using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float hDirectionChangeTimer = 0f;
    private float vDirectionChangeTimer = 0f;

    public float vSpeed = 1;
    public float hSpeed = 1;

    public float hDirectionChangeInterval = 0f;
    public float vDirectionChangeInterval = 0f;


    Rigidbody2D rgbd;

    // Use this for initialization
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        hDirectionChangeTimer = hDirectionChangeInterval;
        vDirectionChangeTimer = vDirectionChangeInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rgbd.velocity = new Vector2(hSpeed, vSpeed);
        ChangeDirection();
    }


    void ChangeDirection()
    {
        if (hDirectionChangeInterval > 0)
        {
            hDirectionChangeTimer -= Time.fixedDeltaTime;
            if (hDirectionChangeTimer <= 0)
            {
                hSpeed = -hSpeed;
                hDirectionChangeTimer = hDirectionChangeInterval;
            }
        }
        if (vDirectionChangeInterval > 0)
        {
            vDirectionChangeTimer -= Time.fixedDeltaTime;
            if (vDirectionChangeTimer <= 0)
            {
                vSpeed = -vSpeed;
                vDirectionChangeTimer = vDirectionChangeInterval;
            }
        }
    }
}
