using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueController : MonoBehaviour, IPointerDownHandler
{
    public Text dialogueText;
    public GameObject nextText;

    public List<string> sentences;
    private int currentSentenceIndex;
    private bool isTyping;

    public float typingSpeed = 0.1f;

    public static DialogueController instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new List<string>();

        List<string> initialLines = new List<string>
        {
        "안녕하세요!"
        };

        StartDialogue(initialLines);
    }

    public void StartDialogue(List<string> lines)
    {
        sentences = lines;
        currentSentenceIndex = 0;
        NextSentence();
    }

    public void Ondialogue(List<string> lines)
    {
        if (lines != null)
        {
            sentences.Clear();
            sentences.AddRange(lines);
        }
    }

    public void NextSentence()
    {
        if(currentSentenceIndex < sentences.Count)
        {
            string currentSentence = sentences[currentSentenceIndex];  
            isTyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
            currentSentenceIndex++;
        }
    }

    public void AutoNextSentence()
    {
        if (!isTyping)
            NextSentence();
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nextText.SetActive(true);
        isTyping = false;
    }

    /*void Update()
    {
        if(dialogueText.text.Equals(sentences[currentSentenceIndex - 1]))
        {
            nextText.SetActive(true);
            isTyping = false;
        }
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        /*if (!isTyping)
            NextSentence();*/
        AutoNextSentence();
    }
}