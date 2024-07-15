using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FloorSelection : MonoBehaviour
{
    public Texture floorTexture;
    public ARPlaneManager planeManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFloorTexture()
    {
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.GetComponent<MeshRenderer>().material.mainTexture = floorTexture;
        }
    }
}
