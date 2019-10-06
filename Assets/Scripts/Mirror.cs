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
        
    }
}
