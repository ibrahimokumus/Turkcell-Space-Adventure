using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformPool : MonoBehaviour
{
    //Object Pooling Pattern is used
    [SerializeField]
    GameObject platformPrefab = default;
    [SerializeField]
    GameObject harmfullPlatformPrefab = default;
    [SerializeField]
    GameObject playerPrefab = default;
    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPos; 
    Vector2 playerPos;

    [SerializeField]
    float platformDistance = default;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlatform(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreenCalculator.instance.HeightScreen)
        {
            LocatePlatform();
        }
    }

    void GeneratePlatform() 
    {
        platformPos = new Vector2(0, 0);
        playerPos = new Vector2(0, 0.5f);

        // Player'ý  oluþtur
        GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
        
        GameObject firstPlatform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
        platforms.Add(firstPlatform);
        NextPlatformPos();
        firstPlatform.GetComponent<PlatformController>().Movement = false;
        
        
        for (int i = 0; i < 8; i++)
        {   
            GameObject platform = Instantiate(platformPrefab, platformPos, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<PlatformController>().Movement = true;
            NextPlatformPos();
        }
        GameObject harmfullPlatform =Instantiate(harmfullPlatformPrefab,platformPos,Quaternion.identity);
        harmfullPlatform.GetComponent<HarmfulPlatform>().Movement = true;
        platforms.Add(harmfullPlatform);
        NextPlatformPos();
    }

    void LocatePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPos;
            NextPlatformPos(); 
        }
    }

    void NextPlatformPos() 
    {
        platformPos.y += platformDistance;
        float random = Random.value;
        if (random < 0.5f)
        {
            platformPos.x = ScreenCalculator.instance.WidthScreen / 2;
        }
        else
        {
            platformPos.x = -ScreenCalculator.instance.WidthScreen / 2;
        }
    }
}


