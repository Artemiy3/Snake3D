using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject sideViewCamera;
    public GameObject firstPersonViewCamera;

    private bool sideViewIsActive;

    void Start()
    {
        sideViewIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Change View")) {
            if (sideViewIsActive) {
                sideViewCamera.SetActive(false);
                firstPersonViewCamera.SetActive(true);
                sideViewIsActive = false;
            } else {
                sideViewCamera.SetActive(true);
                firstPersonViewCamera.SetActive(false);
                sideViewIsActive = true;
            }
        }
    }
}
