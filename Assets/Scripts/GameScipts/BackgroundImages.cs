using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImages : MonoBehaviour
{
    [SerializeField]
    private Image BackGroundImage;
    [SerializeField]
    private Sprite[] BackGroundImages;

    public void NewLevelBackground()
    {
        BackGroundImage.sprite = BackGroundImages[Random.Range(0, BackGroundImages.Length)];            
    }
}