using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlowStickHUD : MonoBehaviour
{
    TextMeshProUGUI tmP;
    public GlowStickPack glowPack;
    // Start is called before the first frame update
    void Start()
    {
        tmP = GetComponent<TextMeshProUGUI>();
        tmP.text = "Bastões de Luz: "+ glowPack.glowStickNumber;
    }

    // Update is called once per frame
    void Update()
    {
        tmP.text = "Bastões de Luz: " + glowPack.glowStickNumber;
    }
}
