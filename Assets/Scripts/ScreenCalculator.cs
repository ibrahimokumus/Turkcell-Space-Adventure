using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator : MonoBehaviour
{
    public static ScreenCalculator instance;
    float height;
    float width;
    
    public  float HeightScreen
    { 
        get 
        { 
            return height;
        }
    }
    public float WidthScreen
    {
        get
        {
            return width;
        }
    }
    void Awake()
    {
        //singleton pattern
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        { 
            Destroy(gameObject);
        }
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

   
}
