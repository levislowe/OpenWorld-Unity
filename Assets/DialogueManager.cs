using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button contin;
    public Queue<string> sentences;
    public Queue<string> questsentences;
    public Animator Dial;
    public GameObject questGiver;
    public bool questStarted = false;
    public Quest quest;
    public jumpHit character;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        questsentences = new Queue<string>();
        Button Con = contin.GetComponent<Button>();
        Con.onClick.AddListener(DisplayNextSentence);

    }
    public void StartDialogue(Dialogue dialogue)
    {
        Dial.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void QuestCompleted(QuestCompleted quest)
    {
        Dial.SetBool("IsOpen", true);
        nameText.text = quest.Name;

        questsentences.Clear();

        foreach (string sentence in quest.sentences)
        {
            questsentences.Enqueue(sentence);
        }
        QuestDoneDisplayNextSentence();
    }
    public void QuestDoneDisplayNextSentence()
    {
        if (questsentences.Count == 0)
        {
            questStarted = false;
            quest.Complete();
            character.CoinCollect();
            EndDialogue();
            return;
        }

        string sentence = questsentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            questStarted = true;
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        Button Con = contin.GetComponent<Button>();
        Dial.SetBool("IsOpen", false);
        QuestGiver questgiver = questGiver.GetComponent<QuestGiver>();
        if (questStarted)
        {
            //contin.gameObject.SetActive(false);
            questgiver.GetComponent<QuestGiver>().OpenQuestWindow();
            questStarted = false;
            Con.onClick.RemoveListener(DisplayNextSentence);

            Con.onClick.AddListener(QuestDoneDisplayNextSentence);

        }
    }
}
