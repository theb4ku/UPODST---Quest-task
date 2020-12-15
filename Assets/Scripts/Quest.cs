using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class Quest : ScriptableObject
{
   
    public int Reward => reward;
    public string Name => name;
    public string Description => description;
    public int ID => id;

    [SerializeField] private int reward;
    [SerializeField] private new string name;
    [SerializeField] private string description;
    [SerializeField] private int id;


    public virtual void OnFinished()
    {

    }
    public virtual void OnStart()
    {

    }
    public virtual void OnUpdated()
    {

    }
}
