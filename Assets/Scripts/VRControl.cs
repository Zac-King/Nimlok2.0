using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place script on the Camera
/// Camera need to be the one with the RotationTracking component
/// </summary>

public class VRControl : MonoBehaviour
{
    private GvrHead m_vrHead;
    private GvrViewer m_vrViewer;
    private RotationToMouseTracking m_mouseRot;

    private void Start()
    {
        m_vrHead = FindObjectOfType<GvrHead>();
        m_vrViewer = FindObjectOfType<GvrViewer>();
        m_mouseRot = FindObjectOfType<RotationToMouseTracking>();
    }

    public void VR(bool a_state)
    {
        m_vrViewer.VRModeEnabled = a_state;
        m_vrHead.enabled = a_state;
        m_mouseRot.EnableXRotation = !a_state;

        if(a_state)
        {
            Quaternion q = new Quaternion(0, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z, gameObject.transform.localRotation.w);
            gameObject.transform.localRotation = q;
        }
    }


}
