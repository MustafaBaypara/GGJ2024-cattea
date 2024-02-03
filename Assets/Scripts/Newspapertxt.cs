using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class RandomTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI leftText;
    public string[] texts;
    public string[] nexttexts;

    void Start()
    {
        ShuffleTexts(texts);
        ShuffleTexts(nexttexts);
        rightText.text = texts[0];
        leftText.text = nexttexts[0];
    }

    void ShuffleTexts(string[] shufftexts)
    {
        // Fisher-Yates shuffle algorithm to shuffle the texts
        for (int i = 0; i < shufftexts.Length; i++)
        {
            int randomIndex = Random.Range(i, shufftexts.Length);
            string temp = shufftexts[randomIndex];
            shufftexts[randomIndex] = shufftexts[i];
            shufftexts[i] = temp;
        }
    }

}