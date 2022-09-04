using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    VideoPlayer backGround;
    public GameObject buttons;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        backGround = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        buttons.SetActive(backGround.time >= 9);
        
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
