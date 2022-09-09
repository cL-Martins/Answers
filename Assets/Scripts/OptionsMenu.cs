using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle normal;
    public Toggle protanopia;
    public Toggle deuteranopia;
    public Toggle tritanopia;
    public AudioMixer audioMixer;
    public void SetVolume (float volume){
        audioMixer.SetFloat("Volume",volume);
    }
    
}
