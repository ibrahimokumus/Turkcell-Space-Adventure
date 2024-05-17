using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    bool hareket;
    float randomSpeed;
    float min;
    float max;
    public bool movement
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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float objectWidth = polygonCollider2D.bounds.size.x / 2;// nesnenin colliderinin yarisi
        if (transform.position.x > 0)
        {
            min= objectWidth;
            max = ScreenCalculator.instance.widthScreen - objectWidth;
        }else
        {
            min = -ScreenCalculator.instance.widthScreen+ objectWidth;
            max = -objectWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (polygonCollider2D != null)
        {
            float pingPongX = Mathf.PingPong(Time.time*randomSpeed, max-min) + min;
            Vector2 pingPong = new Vector2(pingPongX,transform.position.y);
            transform.position = pingPong;
        }
    }
}
