using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestGiver : MonoBehaviour
{
    public GameObject questWindow;
    public TMP_Text TitleText;
    public TMP_Text descriptionText;
    public TMP_Text rewardsText;
    public TMP_Text rewardsNameText;
    public TMP_Text questNameText;
    public TMP_Text LogTitleText;
    public TMP_Text LogDescriptionText;
    public TMP_Text LogRewardsText;
    public TMP_Text LogRewardsNameText;
    public TMP_Text LogQuestNameText;
    public TMP_Text NextPartText;
    public TMP_Text questAccepted;
    public TMP_Text NextPartQuestTitle;
    public TMP_Text started;
    public jumpHit player;
    public Quest quest;
    public Animator questTitle;
    public TMP_Text questStartedTitleText;
    public bool QuestCompleted = false;


    public void Start()
    {
        NextPartQuestTitle.gameObject.SetActive(false);
        questTitle.SetBool("QuestStarted", false);
        LogTitleText.gameObject.SetActive(false);
        LogDescriptionText.gameObject.SetActive(false);
        LogRewardsText.gameObject.SetActive(false);
        LogRewardsNameText.gameObject.SetActive(false);
        LogQuestNameText.gameObject.SetActive(false);
        NextPartText.gameObject.SetActive(false);
    }
    public void Update()
    {
        quest.goal.IsReached();
        if (quest.goal.IsReached())
        {
            QuestLogClear();
            QuestCompleted = true;
        }
    }
    public void QuestLog()
    {
            LogTitleText.gameObject.SetActive(true);
            LogDescriptionText.gameObject.SetActive(true);
            LogRewardsText.gameObject.SetActive(true);
            LogRewardsNameText.gameObject.SetActive(true);
            LogQuestNameText.gameObject.SetActive(true);
        LogTitleText.text = quest.title;
        LogDescriptionText.text = quest.description;
        LogRewardsText.text = quest.reward.ToString();
        LogRewardsNameText.text = quest.rewardsName;
        LogQuestNameText.text = quest.questDescrption;
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        TitleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardsNameText.text = quest.rewardsName;
        questNameText.text = quest.questDescrption;
        rewardsText.text = quest.reward.ToString();

    }
    public void NextPart()
    {
        started.gameObject.SetActive(false);
        questAccepted.gameObject.SetActive(false);
        started.gameObject.SetActive(false);
        questStartedTitleText.gameObject.SetActive(false);
        NextPartQuestTitle.gameObject.SetActive(true);
        NextPartText.gameObject.SetActive(true);
        questTitle.SetBool("QuestStarted", true);
        NextPartQuestTitle.text = quest.title;
        NextPartText.text = quest.nextpart;
        StartCoroutine(QuestTitle());
        IEnumerator QuestTitle()
        {
            yield return new WaitForSeconds(5f);
            questTitle.SetBool("QuestStarted", false);
        }
    }
    public void AcceptQuest()
    {
        quest.isActive = true;
        player.quest = quest;
        questWindow.SetActive(false);
        QuestLog();
        questStartedTitleText.text = quest.title;
        questTitle.SetBool("QuestStarted", true);
        StartCoroutine(QuestTitle());
        IEnumerator QuestTitle()
        {
            yield return new WaitForSeconds(3f);
            questTitle.SetBool("QuestStarted", false);
        }
    }
   public void QuestLogClear()
    {
        LogTitleText.gameObject.SetActive(false);
        LogDescriptionText.gameObject.SetActive(false);
        LogRewardsText.gameObject.SetActive(false);
        LogRewardsNameText.gameObject.SetActive(false);
        LogQuestNameText.gameObject.SetActive(false);

    }
}
