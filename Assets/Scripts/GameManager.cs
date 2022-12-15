using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private bool _startPoint;
    public Image pointButton;
    public GameObject winPanel;
    [SerializeField] private TMP_Text winzoneText;
    [SerializeField] private TMP_Text pointText;
    
    


    #region IsGame
    
        public Action OnUpdate;
        public bool click;
        public List<string> word = new List<string>();
        [Header("Letters on the Stage")]
        [SerializeField] private List<Vector2Int> lettersOnTheStage = new List<Vector2Int>();
        private const string SLetterOnStage = "METİN";
        [Header("Letters on the Stage H")]
        [SerializeField] private List<Vector2Int> hPositions = new List<Vector2Int>();
        public Dictionary<Vector2Int, Cell> positionList = new Dictionary<Vector2Int, Cell>();
        public GameObject gameButtonPrefabs;
        [SerializeField] private GameObject gameButtonParent;
        public Vector2 startPosition;
    
    #endregion



    #region You Earned Points
    private void Update()
    {
        if (_startPoint)
        {
            pointButton.color = Color.green;
        }
        else
        {
            pointButton.color = Color.red;
        }
    }

    public void ButtonTimerStartPanel()
    {
        if (_startPoint)
        {
            StartCoroutine(TimerPanel());
        }
    }


    public void AddValue(int i,string workCell)
    {
        
        winzoneText.text = workCell;
        pointText.text = "" + i;
        _startPoint = true;
    }

    IEnumerator TimerPanel()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        winPanel.SetActive(false);
        _startPoint = false;

    }
    
    #endregion
    
    #region ButtonSpawn
    
    private void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 8 ; j++)
            {
                GameObject currentGameButton =  Instantiate(gameButtonPrefabs, Vector3.zero, Quaternion.identity, gameButtonParent.transform);
                currentGameButton.gameObject.transform.GetComponent<Cell>().position = new Vector2Int(i, j);
                var lPos = currentGameButton.gameObject.transform.localPosition;
                lPos = new Vector3(startPosition.x,startPosition.y);
                currentGameButton.gameObject.transform.localPosition = lPos;
                
                startPosition.x += 136;
            }
            startPosition.x = -453;
            startPosition.y -= 132;
        }
        StartCoroutine(HCellCancel());
    }

    
    
    public void LettersToBePlaced()
    {
        for (int i = 0; i < lettersOnTheStage.Count; i++)
        {
            Cell cell = positionList[lettersOnTheStage[i]];
            cell.currentCedilla = SLetterOnStage[i].ToString();
            cell.CedillaChange();
            cell.letterFull = false;
            cell.full = true;
            cell.CellPointWord();
        }
    }
    IEnumerator HCellCancel()
    {
        yield return new WaitForSeconds(0.01f);
        LettersToBePlaced();
        for (int i = 0; i < hPositions.Count; i++)
        {
            Vector2Int vector2Int = hPositions[i];
            Cell cell = positionList[vector2Int];
            cell.areYouH = true;
            cell.cedillaButton.enabled = false;
        }
        OnUpdate();
        yield return new WaitForSeconds(0.81f);
        for (int i = 0; i < 3; i++)
        {
            OnUpdate();    
        }
        
        /*
        * new positions(0,2);
        * new positions(1,6);
        * new positions(2,5);
        * new positions(3,0);
        * new positions(4,1);
        * new positions(5,7);
        * new positions(6,1);
        * new positions(6,3);
        * new positions(7,0);
        * new positions(7,4);
        * new positions(8,5);
        * new positions(9,6);
         */
    }
    
    #endregion
}
