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
    public GameObject pressStart;
    int indice;
    bool created;
    // Start is called before the first frame update
    void Start()
    {
        pressStart.SetActive(false);
        tmP = GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine("ChangeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("cL_Level_Scene").isLoaded)
        {
            pressStart.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.UnloadSceneAsync("Load");
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
        yield return new WaitForSeconds(timeTips);
        if (!created)
        {
            SceneManager.LoadScene("cL_Level_Scene", LoadSceneMode.Additive);
            created = true;
        }
        StartCoroutine("ChangeText");
    }
}
