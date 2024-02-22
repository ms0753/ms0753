using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public TMP_Text txtSentence;
    [SerializeField] private GameObject _UIControl;

    Queue<string> sentences = new Queue<string>();

    public Animator anim;


    public void Begin(Dialogue Info)
    {
        sentences.Clear();

        foreach (var sentence in Info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        StartCoroutine(StartDelay());
    }

    public void Next()
    {
        if(sentences.Count == 0)
        {
            End();
            return;
        }
        //txtSentence.text = sentences.Dequeue();
        SoundManager.instance.PlayEffect("option");
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(0.1f);
        foreach(var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void End()
    {
        txtSentence.text = string.Empty;
        _UIControl.GetComponent<IntroSceneUIController>().OnGameInfoClose();
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Next();
    }

}
