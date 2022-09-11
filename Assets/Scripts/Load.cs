using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class Load : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public Fade fade;
    int indice;
    bool created;
    VideoPlayer videoP;
    // Start is called before the first frame update
    void Awake()
    {
        tmP = GetComponentInChildren<TextMeshProUGUI>();
        videoP = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("TrueLoad").isLoaded)
        {
                StartCoroutine("LoadGame");
        }
        if(videoP.time >= 61)
        {
            fade.FadeIn();
        }
        if (videoP.time >= 62)
        {
            if (!created)
            {
                SceneManager.LoadScene("TrueLoad", LoadSceneMode.Additive);
                created = true;
            }
        }
    }
    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.UnloadSceneAsync("Load");
    }
}
