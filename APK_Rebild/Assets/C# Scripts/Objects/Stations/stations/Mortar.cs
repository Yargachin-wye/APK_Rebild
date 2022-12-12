using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    [SerializeField] private ParticleSystem _mortarParticles;
    [SerializeField] private ResourceConverter _resourceConverter;
    public void TryInteract()
    {
        if (_resourceConverter.TryInteract())
            _mortarParticles.Play();
    }
}
