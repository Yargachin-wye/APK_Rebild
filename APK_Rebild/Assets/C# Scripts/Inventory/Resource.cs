using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewResource", menuName = "Resource")]
public class Resource : ScriptableObject
{
    [SerializeField] private string _name = "nun";
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private Sprite _sprite;

    public string name => _name;
    public Sprite sprite => _sprite;
    public Color color => _color;

}
