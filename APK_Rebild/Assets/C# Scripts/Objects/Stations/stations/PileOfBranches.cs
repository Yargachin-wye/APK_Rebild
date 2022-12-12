using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfBranches : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pileOfBranchesParticles;
    [SerializeField] private Resource _resource;
    [SerializeField] private ResourceConverter _resourceConverter;
    public void TryInteract()
    {
        if (_resourceConverter.TryInteract())
            _pileOfBranchesParticles.Play();
    }
}
