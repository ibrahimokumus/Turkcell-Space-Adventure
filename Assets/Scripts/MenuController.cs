using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcons = default;
    [SerializeField]
    Button musicBtn = default;
    [SerializeField]
    bool musicEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameBtn()
    {
        SceneManager.LoadScene("Game");
    }
    public void HighestScoreBtn()
    {
        SceneManager.LoadScene("Score");
    }
    public void SettingsBtn()
    {
        SceneManager.LoadScene("Settings");
    }
    public void MusicPlayBtn()
    {
        if (musicEnabled)
        {
            musicEnabled = false;
            musicBtn.image.sprite = musicIcons[0];
        }
        else
        {
            musicEnabled = true;
            musicBtn.image.sprite = musicIcons[1];
        }

    }

}
