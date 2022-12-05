using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMessagePrefab;
    [SerializeField] private Transform _messagesConteiner;

    private void Start()
    {

    }

    public void DoMessage(Dictionary<string, Color> text)
    {
        GameObject obj = Instantiate(_mainMessagePrefab, _messagesConteiner);
        MainMessage mainMessage = obj.GetComponent<MainMessage>();
        mainMessage.Play(text);
    }
}