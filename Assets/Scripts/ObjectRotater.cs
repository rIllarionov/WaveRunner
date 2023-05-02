using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectRotater : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed = 2;
    
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,_rotateSpeed),Space.Self);
    }

}
