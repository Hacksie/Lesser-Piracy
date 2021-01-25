using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform target;
    

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target, Vector3.up);
    }
}
