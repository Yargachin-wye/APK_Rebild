using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMessage : MonoBehaviour
{
    [SerializeField] private Text _bgText;
    [SerializeField] private Animator _bgAnimator;
    [SerializeField] private GameObject _textMainMessagePrefab;
    public void Play(Dictionary<string, Color> text)
    {
        _bgAnimator.SetTrigger("message");
        StartCoroutine(Destroy());// ����� ������� ������� ������ � ��� ��� ����� �� ����� ������������� ��� ��������
        _bgText.text = "";
        foreach (var line in text)
        {
            _bgText.text = _bgText.text + line.Key + "\n";
            GameObject obj = Instantiate(_textMainMessagePrefab, transform);
            obj.GetComponent<TextMainMessage>().Play(line.Key, line.Value);
        }
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);// ������ �������� �� ������ �������!!!!!!!
        Destroy(this.gameObject);
    }
}
