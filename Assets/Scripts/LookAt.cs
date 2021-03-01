using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] public Transform lookAtTransform;

    void LateUpdate()
    {
        transform.LookAt(lookAtTransform.position);
    }
}
