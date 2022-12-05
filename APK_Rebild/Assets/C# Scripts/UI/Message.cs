using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Animator animator;
    private void Start()
    {
        DoMessage("CYKA \n cyka", Color.white);
    }
    public void DoMessage(string text, Color color)
    {
        _text.text = text;
        _text.color = color;
        animator.SetTrigger("message");
    }
}