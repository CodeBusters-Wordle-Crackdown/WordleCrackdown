using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cs_scroller : MonoBehaviour
{
    [SerializeField] private RawImage imgRef; //reference to background image that's scrolling
    [SerializeField] private float x_speed, y_speed;
    [SerializeField] private float speedMult =1; 
    [SerializeField] private Color bgColor; 
    // Update is called once per frame
    void Update()
    {
        //imgRef.color = bgColor; 
        imgRef.uvRect = new Rect(imgRef.uvRect.position +new Vector2(x_speed,y_speed) *speedMult* Time.deltaTime, imgRef.uvRect.size);
        
    }
}
