using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    public List<String> cedillasList;
    public List<int> points;
    public List<GameObject> lightBlueButton;
    public TMP_Text totalScoreText;
    [SerializeField] private string subject;
    public TMP_Text subjectText;
    void Start()
    {
        subjectText.text = subject;
        for (int i = 0; i < lightBlueButton.Count; i++)
        {
            LightBlueButtonChange l = lightBlueButton[i].gameObject.GetComponent<LightBlueButtonChange>();
            l.point = points[i];
            l.charLetter = cedillasList[i];
            l.LightTextChange();
        }
    }

    public void TextFonds(String s)
    {
        Debug.Log(s);
    }
}