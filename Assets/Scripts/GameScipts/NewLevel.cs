using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball;
    public GameObject Barrier;
    [SerializeField]
    private Transform[] Positions;
    int LevelNo;

    void Start()
    {
        Barrier.SetActive(false);
        LevelNo = 1;
        NewLevelStart();
    }
    public void NewLevelStart()
    {
        Levels(LevelNo);
        LevelNo++;
    }
   public void BallLocalScaleSet(float ScaleValue)
    {
        Debug.Log("BallLocalSize:  "+ScaleValue/10);
        Ball.transform.localScale = new Vector3(ScaleValue/10,ScaleValue/10,ScaleValue/10);
    }
    void Levels(int LevelNo)
    {
        switch (LevelNo)
        {
            case 1: //.
                BallLocalScaleSet(1);
                Instantiate(Ball, Positions[16].transform.position, Quaternion.Euler(0, 0, 0));               
                break;
            //case 2: //.  .
            //    BallLocalScaleSet(1.5f);
            //    Instantiate(Ball, Positions[2].transform.position, Quaternion.Euler(0, 0, 0));
            //    BallLocalScaleSet(1.5f);
            //    Instantiate(Ball, Positions[12].transform.position, Quaternion.Euler(0, 0, 0));
            //    break;
            case 3://. . .
                Instantiate(Ball, Positions[0].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[14].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[6].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 4: //. . . .
                Instantiate(Ball, Positions[0].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[1].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[14].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[15].transform.position, Quaternion.Euler(0, 0, 0));
                break; 
            case 5: //: . :
                Instantiate(Ball, Positions[0].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[1].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[16].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[14].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[15].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 2: //barrier
                Barrier.SetActive(true);
                Instantiate(Ball, Positions[16].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[17].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 7: // 3 lü barier
                Instantiate(Ball, Positions[4].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[6].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[8].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[16].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 8: //ortada poşet
                Instantiate(Ball, Positions[16].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[17].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 9:
                Instantiate(Ball, Positions[2].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[12].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[17].transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case 10:
                Instantiate(Ball, Positions[6].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[1].transform.position, Quaternion.Euler(0, 0, 0));
                Instantiate(Ball, Positions[15].transform.position, Quaternion.Euler(0, 0, 0));
                break;        
        }
    }
}
