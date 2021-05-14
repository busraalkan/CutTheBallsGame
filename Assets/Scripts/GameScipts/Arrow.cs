using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody ArrowRigidbody;
    public float Speed;

    public void Start()
    {
        ArrowRigidbody = GetComponent<Rigidbody>();
        ArrowRigidbody.velocity = new Vector3(0, 1, 0) * Speed;
        Destroy(gameObject, 3f);
    }
}
