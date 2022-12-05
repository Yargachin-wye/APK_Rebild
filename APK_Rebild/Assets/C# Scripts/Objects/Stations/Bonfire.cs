using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bonfireParticles;
    [SerializeField] private Resource _priceResource;
    [SerializeField] private int _priceResourceNum = 1;
    [SerializeField] private Resource _productResource;
    public void TryInteract()
    {
        if(Resources.TryRemoveResource(_priceResource, _priceResourceNum))
        {
            _bonfireParticles.Play();
            Resources.AddResource(_productResource);
        }
    }
}
