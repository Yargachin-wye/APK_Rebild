using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfBranches : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pileOfBranchesParticles;
    [SerializeField] private Resource _resource;
    public void TryInteract()
    {
        Resources.AddResource(_resource);
        _pileOfBranchesParticles.Play();
    }
}
