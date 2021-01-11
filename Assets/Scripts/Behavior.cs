using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] protected float m_strength = 1;

    public BasicAgent Agent { get { return GetComponent<BasicAgent>(); } }

    // calculate movement force
    public abstract Vector3 Execute(GameObject[] gameObjects);
}
