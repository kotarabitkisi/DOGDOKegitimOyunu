using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotSpeed;
    void Update()
    {
        transform.Rotate(rotSpeed*Vector3.up*Time.deltaTime);
    }
}
