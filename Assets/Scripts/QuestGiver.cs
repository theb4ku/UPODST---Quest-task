using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] protected List<QuestWithGiverStatus> questsToGive;
    protected QuestManager subscribePlayer = null;


    private void OnTriggerEnter(Collider other)
    {
        SubscribePlayer(other);
        Debug.Log($"Entered");

    }
    private void OnTriggerExit(Collider other)
    {
        UnSubscribePlayer(other);
        Debug.Log($"Left");
    }
    public virtual void StartQuest()
    {


    }
    public virtual void FinishQuest()
    {

    }
    public virtual void UpdateQuest()
    {

    }
    protected virtual bool SubscribePlayer(Collider other)
    {
        subscribePlayer = other.GetComponent<QuestManager>();
        return (subscribePlayer != null);

    }
    protected virtual void UnSubscribePlayer(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            subscribePlayer = null;
        }
    }
    protected void SubscribeQuest()
    {
        foreach (var item in questsToGive)
        {
            subscribePlayer.currentNpcQuest.Add(item);
        }

    }
    protected void UnsubscribeQuest()
    {
        subscribePlayer.currentNpcQuest.Clear();
        Debug.Log("czysci");
    }
    


}
