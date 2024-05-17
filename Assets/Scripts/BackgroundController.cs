using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float backgroundPos;
    float distance=10.24f;//aradaki mesafeyi hesaplama
    // Start is called before the first frame update
    void Start()
    {
        backgroundPos=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundPos + distance <Camera.main.transform.position.y) 
        {
            locateBackground();
        }
    }
    // arka planin konumunu belirleme
    void locateBackground()
    {
        backgroundPos += (distance * 2);
        Vector2 newPos = new Vector2(0, backgroundPos);
        transform.position = newPos;
    }
 




                   
}
