using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerper : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float altitudeToLerp =5;
    [SerializeField] float cameraSize =2;
    CheckAltitude playerAltitude;
    Vector3 startPos;
    float startSizeCamera;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<Camera>();
        startSizeCamera = cam.orthographicSize;
        startPos = transform.position;
        playerAltitude = player.GetComponent<CheckAltitude>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAltitude.GetAltitude() < altitudeToLerp)
        {
            cam.orthographicSize = cameraSize;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = startPos;
            cam.orthographicSize = startSizeCamera;
            transform.position = startPos;

        }
    }
}
