using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMainMessage : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Text _text;
    public void Play(string text, Color color)
    {
        _animator.SetTrigger("message");
        _text.text = text;
        _text.color = color;
    }
}
