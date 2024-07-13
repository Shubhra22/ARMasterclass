using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public XROrigin arorigin;
    public GameObject trailObjectPrefab;
    public TMP_Text positionTxt;

    
    private GameObject spawnedTrail;
    private Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = arorigin.Camera.transform.position + arorigin.Camera.transform.forward;
        if (Input.GetMouseButtonDown(0))
        {
            spawnedTrail = Instantiate(trailObjectPrefab, cameraPos, Quaternion.identity);
        }
        
        if (Input.GetMouseButton(0))
        {
            spawnedTrail.transform.position = cameraPos;
        }
        
        positionTxt.text = arorigin.CameraInOriginSpacePos.ToString() + " " + arorigin.Camera.transform.position;
        
    }
}
