using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInVR : MonoBehaviour
{
    [SerializeField]
    public List<Collider> m_Colliders = new List<Collider>();
    private GvrViewer gvr;

    bool isVR
    {
        get
        { return gvr.VRModeEnabled; }
    }

	void Start ()
    {
        gvr = FindObjectOfType<GvrViewer>();
	}

    public void CheckVR()
    {
        foreach(Collider c in m_Colliders)
        {
            c.enabled = !isVR;
        }
    }
}
