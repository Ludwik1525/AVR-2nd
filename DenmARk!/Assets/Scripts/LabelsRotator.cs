using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LabelsRotator : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        transform.LookAt(new Vector3(target.position.x, this.transform.position.y, target.position.z));
    }
}
