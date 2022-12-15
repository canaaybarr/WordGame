using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : Singleton<Mechanic>
{
    [SerializeField] private LightBlueButtonChange lightBlueButtonChange;
    [SerializeField] private Cell cell;
    
    public string clickedButton;
    public int clickedButtonInt;
    public string letterToBeInserted;
    public int letterToBeInsertedInt;

    private bool _changeLightBlueStart;
    private bool _changeCellStart;

    public void ChangeCell(Cell c)
    {
        cell = c;
        _changeCellStart = true;
        if (!cell.full)
        {
            cell.letterFull = true;    
        }
        
    }


    #region ChangeLightBluePanel
    public void AddingLetters(LightBlueButtonChange blueButtonChange)
    {
        lightBlueButtonChange = blueButtonChange;
        letterToBeInserted = lightBlueButtonChange.charLetter;
        letterToBeInsertedInt = lightBlueButtonChange.point;
        _changeLightBlueStart = true;
        if (_changeCellStart)
        {
            Changing(cell);
            
        }
    }

    
    public void Changing(Cell c)
    {
        if (_changeLightBlueStart)
        {
            cell = c;
            if (cell.scoreIncreased)
            {
                cell.NegativeCheckPositionFun();
                cell.scoreIncreased = false;   
            }
            lightBlueButtonChange.charLetter = cell.currentCedilla;
            lightBlueButtonChange.point = cell.cedillaPoint;
            cell.currentCedilla = letterToBeInserted;
            cell.cedillaPoint = letterToBeInsertedInt;
            cell.CedillaChange();
            lightBlueButtonChange.LightTextChange();
            lightBlueButtonChange = null;
            _changeLightBlueStart = false;
            _changeCellStart = false;
            cell.letterFull = false;
            cell.full = true;
            cell.CellPointWord();
            GameManager.Instance.OnUpdate();
        }
        
    }
    #endregion

    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
