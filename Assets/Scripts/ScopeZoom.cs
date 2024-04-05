using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScopeZoom : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera zoomCam;
    //Testing script
    [ContextMenu("Zoom Test")]
    public void StartZoom()
    {
        zoomCam.m_Lens.FieldOfView = 15;
    }

    [ContextMenu("End Zoom")]
    public void EndZoom() //checking if altfireis needed
    {
        zoomCam.m_Lens.FieldOfView = 60;
    }
}
