using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{
    GameObject player;
    bool visible;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
        StartCoroutine(Say(1, 3));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (visible)
            transform.position = new Vector3(
                player.transform.position.x + 5.5f,
                player.transform.position.y - 0.5f,
                player.transform.position.z);
        else
            transform.position = new Vector2(-1000, -1000);
    }

    IEnumerator Say(int from, int to) {
        visible = false;
        yield return new WaitForSeconds(from);
        visible = true;
        yield return new WaitForSeconds(to);
        visible = false;
    }
}
