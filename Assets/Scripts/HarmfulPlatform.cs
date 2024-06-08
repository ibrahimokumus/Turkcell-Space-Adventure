using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;

    bool hareket;
    float randomSpeed;
    float min;
    float max;
    public bool Movement
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float objectWidth = boxCollider2D.bounds.size.x / 2;// nesnenin colliderinin yarisi
        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.WidthScreen - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.WidthScreen + objectWidth;
            max = -objectWidth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D != null && hareket != false)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}
