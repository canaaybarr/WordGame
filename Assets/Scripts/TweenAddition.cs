﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Scripts._Managers
{
    public enum TweenAdditionType
    {
        Enable,
        Start,
        Sequence,
        SequenceEnable,
        Call
    }
    public abstract class TweenAddition : MonoBehaviour
    {
        public TweenAdditionType tweenType = TweenAdditionType.Enable;
        [Space(5)]
        public float duration;  
        public Tween tween;
        [ContextMenu("Developer/Do Elastic Tween")]
        public abstract Tween TweenEffect();
    }
}