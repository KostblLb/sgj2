using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public bool IsFlipped = false;
    Camera sceneCamera;

    // Start is called before the first frame update
    void Start()
    {
        sceneCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlipWorldOnPlayerTouch(collision);
    }

    private void FlipWorldOnPlayerTouch(Collision2D collision)
    {
        var player = collision.transform.GetComponent<PlayerController>();
        if (player == null) return;

        player.ReverseHInput = !player.ReverseHInput;
        player.transform.Rotate(Vector3.up, 180, Space.Self);
        sceneCamera.transform.Rotate(Vector3.up, 180);
        sceneCamera.transform.Translate(0, 0, (sceneCamera.transform.position.z > 0 ? -2 : 2) * sceneCamera.transform.position.z);
    }
}
