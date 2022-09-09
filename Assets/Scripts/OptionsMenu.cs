using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Wilberforce;
public class OptionsMenu : MonoBehaviour
{
    public Toggle normal;
    public Toggle protanopia;
    public Toggle deuteranopia;
    public Toggle tritanopia;
    public AudioMixer audioMixer;
    public Colorblind daltonic;
    public void SetVolume (float volume){
        audioMixer.SetFloat("Volume",volume);        
    }
    
    void FixedUpdate()
    {
        if (normal.isOn){
            daltonic.Type = 0;
        }
        else if (protanopia.isOn){
            daltonic.Type = 1;
        }
        else if (deuteranopia.isOn){
            daltonic.Type = 2;
        }
        else if (tritanopia.isOn){
            daltonic.Type = 3;
        }
    }
    
}
