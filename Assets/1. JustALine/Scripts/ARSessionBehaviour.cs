using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionBehaviour : MonoBehaviour
{
    private ARSession m_Session;
    void Start() 
    {
        if(ARSession.state == ARSessionState.Unsupported)
        {
            Debug.Log("Device not supported");
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
        }
    }
}
