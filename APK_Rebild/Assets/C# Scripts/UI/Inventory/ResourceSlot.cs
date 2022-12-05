using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    [SerializeField] private Image _spriteRenderer;
    [SerializeField] private Text _Text;
    public void RenderSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    public void RenderText(string name, string num)
    {
        _Text.text = name;
        _Text.text = _Text.text + "\n" + num;
    }
    public void ÑhangeTextColor(Color color)
    {
        _Text.color = color;
    }
}
