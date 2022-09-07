using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        tmP = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine("ChangeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("cL_Level_Scene").isLoaded)
        {
                fade.FadeIn();
                StartCoroutine("LoadGame");
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
