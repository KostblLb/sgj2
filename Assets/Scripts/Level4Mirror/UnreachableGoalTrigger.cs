using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnreachableGoalTrigger : MonoBehaviour
{
    public float PlatformSpeed;
    public float PlatformInterval;
    public float PlatformDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>() != null)
        {
            StartCoroutine(LaunchPlatforms());
        }
    }

    private IEnumerator LaunchPlatforms()
    {
        var platformGroup1 = GameObject.Find("PlatformBase1").GetComponentsInChildren<PlatformController>();
        var platformGroup2 = GameObject.Find("PlatformBase2").GetComponentsInChildren<PlatformController>();
        var platformGroup3 = GameObject.Find("PlatformBase3").GetComponentsInChildren<PlatformController>();
        var mirrorPlatform = GameObject.Find("MirrorPlatform").GetComponent<PlatformController>();

        foreach (PlatformController[] platformGroup in new[] { platformGroup1, platformGroup2, platformGroup3 })
        {
            foreach (var platform in platformGroup)
            {
                platform.vSpeed = PlatformSpeed;
                platform.vDirectionChangeInterval = PlatformInterval;
                StartCoroutine(ChangePlatformSpeed(platform, -PlatformSpeed * 0.4f));
            }
            yield return new WaitForSeconds(PlatformDelay);
        }
        mirrorPlatform.vSpeed = - PlatformSpeed * 0.7f;
        StartCoroutine(ChangeMirrorPlatformSpeed(mirrorPlatform, 2.9f, 1f));
    }

    private IEnumerator ChangePlatformSpeed(PlatformController platform, float speed)
    {
        yield return new WaitForSeconds(PlatformInterval);
        platform.vSpeed = speed;
    }

    private IEnumerator ChangeMirrorPlatformSpeed(PlatformController platform, float speed, float interval)
    {
        yield return new WaitForSeconds(PlatformInterval);
        platform.vSpeed = speed;
        platform.vDirectionChangeInterval = interval;
    }
}
