using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RaycastHit hit;

    Transform cam;

    public LayerMask item;

    void Start()
    {
        cam = Camera.main.transform;
    }

    

    void Update()
    {

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 2f, item))
        {
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.name.Contains("bar"))
            {
                print("YESSS!");
            }
        }
        else
        {
            Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * 2f, Color.green);
        }

    }
}
