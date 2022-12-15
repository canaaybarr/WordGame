using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public bool addPoint;
    public bool scoreIncreased;
    public bool full;
    public bool areYouH;
    public bool letterFull;
    public Vector2Int position = Vector2Int.zero;
    [SerializeField] private Color mainColor;
    public string currentCedilla;
    
    public string wordCellX;
    public string wordCellY;
    private int _x = 1;
    private int _y = 1;
    private string _newWordX = null;
    public int pointX;
    private string _newWordY = null;
    public int pointY;
    
    [SerializeField] private Image gameButtonImage;
    [SerializeField] private TMP_Text cedillaText;
    public Button cedillaButton;
    [SerializeField] private TMP_Text cedillaPointText;
    public int cedillaPoint;
    void Start()
    {
        GameManager.Instance.positionList.Add(position,this);
    }

    public void CellPointWord()
    {
        wordCellX = currentCedilla;
        pointX = cedillaPoint;
        wordCellY = currentCedilla;
        pointY = cedillaPoint;
    }

    public void AddCell()
    {
        Mechanic.Instance.Changing(this);
        Mechanic.Instance.ChangeCell(this);
    }
    
    private void OnEnable()
    {
        GameManager.Instance.OnUpdate += Checking;
        GameManager.Instance.OnUpdate += SearchingWord;

    }
    private void OnDisable()
    {
        GameManager.Instance.OnUpdate -= Checking;
        GameManager.Instance.OnUpdate -= SearchingWord;

    }

    #region Searching for a Meaningful Word
    
    private void SearchingWord()
    {
        if (full && !addPoint)
        {
            #region PositionXY
            
            Vector2Int vector2Int = new Vector2Int(position.x, position.y + _x);
            Vector2Int vector2IntY = new Vector2Int(position.x + _y, position.y);
            Cell cellX = GameManager.Instance.positionList[vector2Int];
            Cell cellY = GameManager.Instance.positionList[vector2IntY];
            
            #endregion
            
            #region CheckNullPosition
            
            if (cellX.full)
            {
                wordCellX += cellX.currentCedilla;
                pointX += cellX.cedillaPoint;
                _x++;
                if (GameManager.Instance.word.Contains(wordCellX))
                {
                    GameManager.Instance.AddValue(pointX,wordCellX);
                    addPoint = true;
                }
            }
            if (cellY.full)
            {
                wordCellY += cellY.currentCedilla;
                pointY += cellY.cedillaPoint;
                _y++;
                if (GameManager.Instance.word.Contains(wordCellY))
                {
                    GameManager.Instance.AddValue(pointY,wordCellY);
                    addPoint = true;
                }
            }
            
            #endregion
        }
    }

    void WinPoint(int i,string l)
    {
        
    }

    private Cell CheckChar(Cell cell)
    {
        if (CheckingWord(cell.currentCedilla))
        {
            return cell;
        }
        return null;
    }
    
    public bool CheckingWord(string wordPres)
    {
        if (wordPres != null)
        {
            for (int i = 0; i < GameManager.Instance.word.Count; i++)
            {
                string sPres = GameManager.Instance.word[i];
            }
        }
        return false;
    }
    
    #endregion
    
    #region HButton
    
    
    
    
    #region Checking
    private void Checking()
    {
        if (areYouH)
        {
            Vector2Int vector2Int = new Vector2Int(position.x, position.y + 1);
            Vector2Int vector2Int2= new Vector2Int(position.x + 1, position.y);
            Cell cell1 = GameManager.Instance.positionList[vector2Int];
            Cell cell2 = GameManager.Instance.positionList[vector2Int2];
            if (cell1.full && !cell1.scoreIncreased)
            {
                cell1.PositiveCheckPositionFun();
                cell1.scoreIncreased = true;
            }
            else if (cell2.full && !cell2.scoreIncreased)
            {
                cell2.PositiveCheckPositionFun();
                cell2.scoreIncreased = true;
            }
        }
        
    }
    private void PositiveCheckPositionFun()
    {
        cedillaPoint *= 2;
        pointX = cedillaPoint;
        cedillaPointText.text = "" + cedillaPoint;
    }
    
    public void NegativeCheckPositionFun()
    {
        cedillaPoint /= 2;
        cedillaPointText.text = "" + cedillaPoint;
    }
    #endregion
    
    #endregion
    
    #region Normal
    
    public void CedillaChange()
    {
        if (areYouH) return;
        YellowColor();
        cedillaText.gameObject.SetActive(true);
        cedillaPointText.gameObject.SetActive(true);
        cedillaText.text = currentCedilla;
        cedillaPointText.text = "" + cedillaPoint;
    }
    
    public void CedillaChangeReturn()
    {
        if (areYouH) return;
        cedillaText.text = currentCedilla;
        cedillaPointText.text = "" + cedillaPoint;
    }

    #region Color
    
    public void ChangeCedilla()
    {
        if (areYouH) return;
        ChangeColor(mainColor);
    }
    public void GreenColor()
    {
        if (areYouH) return;
        cedillaText.gameObject.SetActive(true);
        cedillaPointText.gameObject.SetActive(true);
        AddCell();
        if (full)
        { 
            return;   
        }
        ChangeColor(Color.green);
        
    }
    public void FalseGreenColor()
    {
        if (letterFull)
        {
            cedillaText.gameObject.SetActive(false);
            cedillaPointText.gameObject.SetActive(false);
            ChangeColor(mainColor);
        }
    }
    private void YellowColor()
    {
        if (areYouH) return;
        ChangeColor(Color.yellow);
    }
    private void ChangeColor(Color c)
    {
        if (areYouH) return;
        gameButtonImage.color = c;
    }
    
    #endregion
    
    #endregion
}
