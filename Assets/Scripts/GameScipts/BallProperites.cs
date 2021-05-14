using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProperites : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    Rigidbody BallRB;
    float BallMass;  
    void Start()
    {
        BallRB = Ball.GetComponent<Rigidbody>();
        BallMass = BallRB.mass;
    }
    public float NewBallMass(Rigidbody NewBallObject)
    {
        BallMass += BallMass * 0.125f;
        return BallMass;
    }
    public Vector3 NewBallScale(GameObject NewBallObject)
    {
        NewBallObject.transform.localScale = NewBallObject.transform.localScale *0.75f;
        return NewBallObject.transform.localScale;
    }
}