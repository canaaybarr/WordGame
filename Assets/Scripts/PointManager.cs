using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : Singleton<PointManager>
{
    public List<int> points;

    public int totalScore;
    
    // totalScoreText.text = ""+ PointManager.Instance.totalScore;

    
}
