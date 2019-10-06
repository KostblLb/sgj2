using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private bool isTouched = false;
    Camera sceneCamera;
    public float CameraFlipTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        sceneCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FlipCameraSmooth());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlipWorldOnPlayerTouch(collision);
    }

    private void FlipWorldOnPlayerTouch(Collision2D collision)
    {
        if (isTouched) return;

        var player = collision.transform.GetComponent<PlayerController>();
        if (player == null) return;

        
        isTouched = true;
        player.ReverseHInput = !player.ReverseHInput;
        player.transform.Rotate(Vector3.up, 180, Space.Self);
        StartCoroutine(FlipCameraSmooth());
        StartCoroutine(SetTouchedState());
    }

    private IEnumerator SetTouchedState()
    {
        yield return new WaitForSeconds(CameraFlipTime);
        transform.Find("mirror_untouched").gameObject.SetActive(false);
        transform.Find("mirror_touched").gameObject.SetActive(true);
    }

    private IEnumerator FlipCameraSmooth()
    {
        var inverseFlipTime = 1f / CameraFlipTime;
        var startTime = Time.time;
        var currentTime = startTime;
        var cameraInitRotation = sceneCamera.transform.rotation.eulerAngles;
        var cameraInitAngle = cameraInitRotation.y;
        var cameraEndAngle = 180 - cameraInitAngle;

        var cameraInitZPos = sceneCamera.transform.position.z; 
        var cameraEndZPos = -cameraInitZPos;


        while (currentTime - startTime < CameraFlipTime)
        {
            var progress = (currentTime - startTime) * inverseFlipTime;
            var currentAngle = Mathf.Lerp(cameraInitAngle, cameraEndAngle, progress);
            var currentZpos = Mathf.Lerp(cameraInitZPos, cameraEndZPos, progress);

            sceneCamera.transform.SetPositionAndRotation(
                new Vector3(sceneCamera.transform.position.x, sceneCamera.transform.position.y, currentZpos),
                Quaternion.Euler(cameraInitRotation.x, currentAngle, cameraInitRotation.z)
            );

            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        sceneCamera.transform.SetPositionAndRotation(
            new Vector3(sceneCamera.transform.position.x, sceneCamera.transform.position.y, cameraEndZPos),
            Quaternion.Euler(cameraInitRotation.x, cameraEndAngle, cameraInitRotation.z)
        );
    }
}
