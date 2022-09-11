using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TrueLoad : MonoBehaviour
{
    VideoPlayer videoP;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        videoP = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(videoP.time > 29f && !created)
        {
            SceneManager.LoadScene("cL_Level_Scene", LoadSceneMode.Additive);
            created = true;
        }
        if (SceneManager.GetSceneByName("cL_Level_Scene").isLoaded)
        {
            SceneManager.UnloadSceneAsync("TrueLoad");
        }
    }

}
