using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    Rigidbody BallRigidbody, NewBallLeftRigidbody, NewBallRightRigidbody;
    BackgroundImages backgroundObject;
    BallProperites ballProperites;
    NewLevel newLevel;
    GameObject NewBallLeft, NewBallRight;
    bool IsGrounded;
    float DistanceX;
    float DistanceY;
    float Before, Now;
    int objDirection;
    private static List<GameObject> ballList;
    void Awake()
    {
        ballProperites = Object.FindObjectOfType<BallProperites>();
        backgroundObject = Object.FindObjectOfType<BackgroundImages>();
        newLevel = Object.FindObjectOfType<NewLevel>();
        BallRigidbody = this.gameObject.GetComponent<Rigidbody>();
        IsGrounded = false;
        DistanceX = 0.5f;
        DistanceY = 2f;
    }
    int FindObjDirection(GameObject obj)
    {
        Now = obj.transform.position.x;
        objDirection = (Now - Before) >= 0 ? 1 : -1;
        Before = Now;
        return objDirection;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);           
            if (this.gameObject != null)
            {
                NewBalls(this.gameObject);
                Destroy(this.gameObject);
            }
            DestroySmallBalls();
            BarrierCheck();
            if (ballList.Count <= 0)
            {
                SetForNewLevel();
            }
        }
        CollisionCheck(collision);
    }
    void CollisionCheck(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            IsGrounded = true;
            DistanceX = 0.5f * FindObjDirection(this.gameObject);
        }
        if (collision.transform.CompareTag("LeftSide"))
        {
            BallRigidbody.AddForce(new Vector3(0.5f, 0, 0), ForceMode.Impulse);
            DistanceX = -0.5f * FindObjDirection(this.gameObject);
        }
        else if (collision.transform.CompareTag("RightSide"))
        {
            BallRigidbody.AddForce(new Vector3(-0.5f, 0, 0), ForceMode.Impulse);
            DistanceX = -0.5f * FindObjDirection(this.gameObject);
        }
        GroundDetect(new Vector3(DistanceX, DistanceY, 0));
    }
    void GroundDetect(Vector3 vector3)
    {
        if (IsGrounded)
        {
            BallRigidbody.AddForce(vector3, ForceMode.Impulse);
            IsGrounded = false;
        }
    }
    void NewBalls(GameObject gameObject)
    {
        NewBallLeft = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, 0));
        NewBallRight = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, 0));

        NewBallLeftRigidbody = NewBallLeft.GetComponent<Rigidbody>();
        NewBallRightRigidbody = NewBallRight.GetComponent<Rigidbody>();

        ballProperites.NewBallMass(NewBallLeftRigidbody);
        ballProperites.NewBallMass(NewBallRightRigidbody);

        ballProperites.NewBallScale(NewBallLeft);
        ballProperites.NewBallScale(NewBallRight);

        NewBallLeftRigidbody.AddForce(new Vector3(DistanceX, DistanceY, 0f), ForceMode.Impulse);
        NewBallRightRigidbody.AddForce(new Vector3(-DistanceX, DistanceY, 0f), ForceMode.Impulse);
    }
    void DestroySmallBalls()
    {
        GameObject[] ballItems = GameObject.FindGameObjectsWithTag("Ball");
        ballList = ballItems.ToList();
        foreach (var item in ballItems)
        {
            if (item.transform.localScale.x < 0.075f||item.GetInstanceID()==gameObject.GetInstanceID())
            {
                if (item != null)
                {
                    Destroy(item);
                    ballList.Remove(item);
                }
            }
        }        
    }
    void SetForNewLevel()
    {
        backgroundObject.NewLevelBackground();
        newLevel.Barrier.SetActive(false);
        newLevel.NewLevelStart();
    }
    void BarrierCheck()
    {
        GameObject[] ballItems = GameObject.FindGameObjectsWithTag("Ball");
        ballList = ballItems.ToList();
        foreach (var item in ballItems)
        {
            if (newLevel.Barrier.transform.position.y>= item.transform.transform.position.y)
            {
                if (item == null)
                {
                    newLevel.Barrier.SetActive(false);
                }
            }
        }
    }
}