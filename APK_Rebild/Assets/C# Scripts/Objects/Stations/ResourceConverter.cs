using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceConverter : MonoBehaviour
{
    [SerializeField] private Resource _productResource;
    [Header("Resources.length == ResourceNum.length !!!")]
    [SerializeField] private Resource[] _priceResources;
    [SerializeField] private int[] _priceResourceNum;

    private Dictionary<Resource, int> priceResources = new Dictionary<Resource, int>();
    private void Awake()
    {
        if (_priceResources.Length != _priceResourceNum.Length)
        {
            Debug.LogError("_priceResources.Length != _priceResourceNum.Length");
            return;
        }
        for (int i = 0; i < _priceResources.Length; i++)
            priceResources.Add(_priceResources[i], _priceResourceNum[i]);
    }
    public bool TryInteract()
    {
        if (_priceResources.Length != _priceResourceNum.Length)
        {
            Debug.LogError("_priceResources.Length != _priceResourceNum.Length");
            return false;
        }

        if (Resources.TryRemoveResource(priceResources))
        {
            Resources.AddResource(_productResource);
            return true;
        }
        return false;
    }
}
