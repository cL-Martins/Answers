using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    VideoPlayer backGround;
    public GameObject buttons;
    public GameObject options;
    public GameObject credits;
    public GameObject fade;
    bool ativaMenu = true;
    public Animator anim;
    public Image warning;
    float timeWarning;
    // Start is called before the first frame update
    void Start()
    {
        backGround = GetComponent<VideoPlayer>();
        warning.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (warning.enabled)
        {
            timeWarning += Time.deltaTime;
            if (timeWarning > 8)
            {
                backGround.Play();
                warning.enabled = false;
            }
        }
        if (ativaMenu){
            buttons.SetActive(backGround.time >= 12);
        }else{
            buttons.SetActive(false);
        }
        if (buttons.activeSelf){
            anim.SetBool("buttonsActivaded",true);
            fade.SetActive(false);
        }
        if (backGround.time >= backGround.clip.length - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void PlayGame(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Options(){ //Mostra o Menu Opções
        options.SetActive(true);
        ativaMenu = false;
    }
    public void Credits(){ //Mostra o Menu Creditos
        credits.SetActive(true);
        ativaMenu = false;
    }
    public void backToMenu(){
        options.SetActive(false);
        credits.SetActive(false);
        ativaMenu = true;
    }
}
