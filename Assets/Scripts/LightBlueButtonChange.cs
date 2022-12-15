using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightBlueButtonChange : MonoBehaviour
{
    [SerializeField] public TMP_Text letter;
    [SerializeField] public TMP_Text pointText;

    public string charLetter;
    public int point;


    public void Add()
    {
        Mechanic.Instance.AddingLetters(this);
    }
    
    public void LightTextChange()
    {
        letter.text = charLetter;
        pointText.text = "" + point;
    }

}
