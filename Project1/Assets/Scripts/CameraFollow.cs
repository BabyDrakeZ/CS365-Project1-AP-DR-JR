using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = Vector3.Lerp(transform.position + new Vector3(0, 0, -10), Camera.main.transform.position, 0.1f);
        Camera.main.transform.position = newCameraPosition;
    }
}
