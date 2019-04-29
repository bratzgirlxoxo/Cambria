using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCameraTrigger : MonoBehaviour
{

    public GarageCameraController camController;

    [SerializeField] private int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GarageCameraController.CamPos currPos = camController.myCamPos;
            GarageCameraController.CamPos nextPos;
            if ((int)currPos == index)
            {
                nextPos = GarageCameraController.CamPos.FirstPos;
            } else
            {
                nextPos = GarageCameraController.CamPos.SecondPos;
            }

            camController.ChangeCameras(currPos, nextPos);
        }
    }
}
