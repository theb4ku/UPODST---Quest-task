using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Zul : QuestGiver
{
    [SerializeField] Button button = default;
    [SerializeField] Canvas canvas = default;
    
    protected override bool SubscribePlayer(Collider other)
    {
        if (!base.SubscribePlayer(other))
            return false;
        Debug.Log(button);
        
        button.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(SubscribeQuest);
        button.onClick.AddListener(subscribePlayer.ShowQiestList); 
        button.onClick.AddListener(subscribePlayer.DrawButtons);
        return true;
    }
    protected override void UnSubscribePlayer(Collider other)
    {
        UnsubscribeQuest();
        subscribePlayer.CancelDescription();
        subscribePlayer.ClearQuets();
        base.UnSubscribePlayer(other);
        button.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
    }

    public override void StartQuest()
    {


    }
    public override void FinishQuest()
    {

    }
    public override void UpdateQuest()
    {

    }
   
}

