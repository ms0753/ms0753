using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneUIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _commentator;
    [SerializeField] private GameObject _dialog;
    [SerializeField] private Animator _mainCanvasAnim;
    [SerializeField] private Animator _commentatorAnim;
    [SerializeField] private Animator _dialogAnim;

    private static readonly int Disappear = Animator.StringToHash("Disappear");
    private static readonly int Appear = Animator.StringToHash("Appear");

    public void ToHomeScene()
    {
        SoundManager.instance.PlayEffect("positive");
        SceneManager.LoadScene("HomeScene");
    }
    public void OnGameInfoOpen()
    {
        SoundManager.instance.PlayEffect("positive");
        _mainCanvasAnim.SetTrigger(Disappear);
        StartCoroutine(ToggleUI(_commentator, true, 0.4f));
        StartCoroutine(ToggleUI(_dialog, true, 0.4f));
    }

    public void OnGameInfoClose()
    {
        _mainCanvasAnim.SetTrigger(Appear);
        _commentatorAnim.SetTrigger(Disappear);
        _dialogAnim.SetTrigger(Disappear);
        StartCoroutine(ToggleUI(_commentator, false, 0.8f));
        StartCoroutine(ToggleUI(_dialog, false, 0.8f));
    }

    IEnumerator ToggleUI(GameObject obj, bool toggle, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(toggle);
    }
}
