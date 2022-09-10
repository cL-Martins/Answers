using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class Load : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public float timeTips;
    public string[] tips;
    public Fade fade;
    int indice;
    bool created;
    VideoPlayer videoP;
    // Start is called before the first frame update
    void Awake()
    {
        tmP = GetComponentInChildren<TextMeshProUGUI>();
        videoP = GetComponent<VideoPlayer>();
        //StartCoroutine("ChangeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("cL_Level_Scene").isLoaded)
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
                SceneManager.LoadScene("cL_Level_Scene", LoadSceneMode.Additive);
                created = true;
            }
        }
    }
    IEnumerator ChangeText()
    {
        tmP.text = tips[indice];
        if (indice < tips.Length -1)
        {
            indice++;
        } else
        {
            indice = 0;
        }
        if (!created)
        {
            SceneManager.LoadScene("cL_Level_Scene", LoadSceneMode.Additive);
            created = true;
        }
        yield return new WaitForSeconds(timeTips);
        StartCoroutine("ChangeText");
    }
    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.UnloadSceneAsync("Load");
    }
}
