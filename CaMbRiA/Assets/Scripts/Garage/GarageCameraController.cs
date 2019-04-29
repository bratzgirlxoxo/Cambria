using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCameraController : MonoBehaviour
{

    public CamPos myCamPos = CamPos.FirstPos;

    public Camera[] myCameras;

    public void ChangeCameras(CamPos currCamPos, CamPos nextCamPos)
    {
        myCamPos = nextCamPos;

        myCameras[(int)currCamPos].enabled = false;
        myCameras[(int)nextCamPos].enabled = true;
    }

    public enum CamPos
    {
        FirstPos, SecondPos, ThirdPos
    }
}
