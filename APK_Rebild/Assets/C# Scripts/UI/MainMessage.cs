using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMessage : MonoBehaviour
{
    [SerializeField] private Text _mainText;
    [SerializeField] private Text _bgText;
    [SerializeField] private Animator _bgAnimator;
    [SerializeField] private Animator _mainAnimator;
    public void Play(string text, Color color)
    {
        _bgText.text = text;
        _mainText.text = text;
        _mainText.color = color;
        _bgAnimator.SetTrigger("message");
        _mainAnimator.SetTrigger("message");
        StartCoroutine(Destroy());// такое решение принято всвязи с тем что автор не умеет согласовывать две анимации
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);// КОНСТАНТА
        Destroy(this.gameObject);
    }
}
