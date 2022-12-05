using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    [SerializeField] private Image _spriteRenderer;
    [SerializeField] private Text _text;
    [SerializeField] private Animator _animator;
    public void RenderSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    public void RenderText(string name, string num)
    {
        _text.text = name;
        _text.text = _text.text + "\n" + num;
        _animator.SetTrigger("add");
        Debug.Log("RenderText");
    }
    public void ÑhangeTextColor(Color color)
    {
        _text.color = color;
    }
}
