using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundsList
{
    //Adicionar aqui um por um separado por vírgula cada efeito sonoro
    CollectKey
}
[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;
    public AudioClip[] sounds;//Lista de sons
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Para adicionar um gatilho de efeito sonoro use SoundEffects.PlaySound(Termo da maquina de estado SoundsList);
    }
    public static void PlaySound(SoundsList currentsound)
    {
        switch (currentsound) //Adicionar um novo case para cada novo efeito sonoro
        {
            case SoundsList.CollectKey:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.sounds[0]);
                break;

        }
    }
}

