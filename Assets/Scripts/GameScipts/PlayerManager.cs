using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ArrowPrefab;
    [SerializeField]
    private Transform ArrowPosition;
    Rigidbody PlayerRigidbody;
    public float Speed;
    bool FirePermit;
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        FirePermit = true;
    }
  
    public void RightButton()
    {
        PlayerRigidbody.velocity = Vector3.right * Speed;
    }
    public void LeftButton()
    {
        PlayerRigidbody.velocity = Vector3.left * Speed;
    }
    public void FireButton()
    {
        if (FirePermit)
        {          
            GameObject ArrowPrefabCopy = Instantiate(ArrowPrefab, ArrowPosition.position, Quaternion.Euler(0, 0, 180));
            FirePermit = true; //to do false
            StartCoroutine(FirePermitRoutine());
        }
    }
    IEnumerator FirePermitRoutine()
    {
        if (!FirePermit)
        {
            yield return new WaitForSeconds(2f);
            FirePermit = true; ;
        }
    }
}