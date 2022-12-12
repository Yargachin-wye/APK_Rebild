using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bonfireParticles;
    [SerializeField] private ResourceConverter _resourceConverter;
    public void TryInteract()
    {
        if (_resourceConverter.TryInteract())
            _bonfireParticles.Play();
    }
}
