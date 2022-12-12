using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMessage : MonoBehaviour
{
    [SerializeField] private Text _bgText;
    [SerializeField] private Animator _bgAnimator;
    [SerializeField] private GameObject _textMainMessagePrefab;
    [SerializeField] private Transform _mainTextConteiner;
    public void Play(Dictionary<string, Color> text)
    {
        _bgAnimator.SetTrigger("message");
        StartCoroutine(Destroy());// такое решение принято всвязи с тем что автор не умеет согласовывать две анимации
        _bgText.text = "";
        foreach (var line in text)
        {
            _bgText.text = _bgText.text + line.Key + "\n";
            GameObject obj = Instantiate(_textMainMessagePrefab, _mainTextConteiner);
            obj.GetComponent<TextMainMessage>().Play(line.Key, line.Value);
        }
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);// ДЛИННА АНИМАЦИИ НЕ БОЛЬШЕ СЕКУНДЫ!!!!!!!
        Destroy(this.gameObject);
    }
}
