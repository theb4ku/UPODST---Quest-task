using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] Canvas canvas = default;
    [SerializeField] GameObject scrollView;
    [SerializeField] GameObject scrollViewQuestDescription;
    [SerializeField] Button buttonQuestListPrefab = default;
    [SerializeField] Button npcButton = default;
    [SerializeField] Button acceptButton = default;
    [SerializeField] Button declineButton = default;
    [SerializeField] GameObject content;
    [SerializeField] TMP_Text textDescription = default;
    //[SerializeField] GameObject contentQuestDescription;
    public List<QuestWithGiverStatus> ActiveQuest = new List<QuestWithGiverStatus>();
    public List<QuestWithGiverStatus> currentNpcQuest;
   
    public void DrawButtons()
    {
        


        scrollView.SetActive(true);
        buttonQuestListPrefab.gameObject.SetActive(false);
        
        var buttonPrefabText = buttonQuestListPrefab.GetComponentInChildren<TMP_Text>();

        foreach (var item in currentNpcQuest)
        {
            buttonPrefabText.text = item.Quest.Name;
           // buttonQuestListPrefab.onClick.RemoveAllListeners();
           // buttonQuestListPrefab.onClick.AddListener(delegate { ShowQuestInfo(item);});
            var spawnedButton = Instantiate(buttonQuestListPrefab, content.transform);
            spawnedButton.gameObject.SetActive(true);
            spawnedButton.onClick.RemoveAllListeners();
            spawnedButton.onClick.AddListener(() => ShowQuestInfo(item));
            declineButton.onClick.RemoveAllListeners();
            declineButton.onClick.AddListener(DeclineQuest);

            
        }
    }
    public void ShowQiestList()
    {
        foreach (var item in currentNpcQuest)
        {
            Debug.Log(item.Quest.Name);
            
        }
        
        npcButton.gameObject.SetActive(false);
    }

    void ShowPlayersQuest()
    {
        foreach(var item in ActiveQuest)
        {
            Debug.Log(item.Quest.Name);
        }
    }
    public void ClearQuets()
    {

        var eldo = content.GetComponentsInChildren<Button>().Where(x => x);
        foreach (var item in eldo)
        {
            Destroy(item.gameObject);
        }
        scrollView.SetActive(false);
    }
    void ShowQuestInfo(QuestWithGiverStatus quest)
    {
        scrollView.SetActive(false);
        scrollViewQuestDescription.SetActive(true);
        textDescription.text = quest.Quest.Description;
        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => AcceptQuest(quest));

    }
  public void CancelDescription()
    {
        scrollViewQuestDescription.SetActive(false);
        textDescription.text = "";
    }
    void DeclineQuest()
    {
        scrollView.SetActive(true);
        scrollViewQuestDescription.SetActive(false);
    }

    void AcceptQuest(QuestWithGiverStatus quest)
    {
        if (!ActiveQuest.Contains(quest))
        {
            ActiveQuest.Add(quest);
            Debug.Log($"{quest.Quest.Name} has been added");
        }
        else
        {
            Debug.Log($"You already have this quest");
        }
        ShowPlayersQuest();
    }



}
