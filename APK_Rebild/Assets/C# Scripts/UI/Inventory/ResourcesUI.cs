using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private GameObject _resourceSlotPrefab;
    [SerializeField] private Transform _resourcesContainer;
    private Dictionary<Resource, ResourceSlot> resources;
    private void Awake()
    {
        if (_resourceSlotPrefab.GetComponent<ResourceSlot>() == null)
            Debug.LogError("ResourceSlot not set on ResourceSlotPrefab");
        resources = new Dictionary<Resource, ResourceSlot>();
    }

    private void AddSlot(Resource resource, int num)
    {
        GameObject obj = Instantiate(_resourceSlotPrefab, _resourcesContainer);
        resources.Add(resource, obj.GetComponent<ResourceSlot>());
        resources[resource].RenderSprite(resource.sprite);
        resources[resource].RenderText(resource.name, num.ToString());
        resources[resource].ÑhangeTextColor(resource.color);
    }
    public void UpdateSlot(Resource resource, int num)
    {
        if (resources.ContainsKey(resource))
        {
            resources[resource].RenderText(resource.name, num.ToString());
        }
        else
        {
            AddSlot(resource, num);
        }
    }
    public void UpdateAll(Dictionary<Resource, int> resources)
    {
        foreach (Transform child in _resourcesContainer)
        {
            Destroy(child.gameObject);
        }

        foreach(var resource in resources)
        {
            UpdateSlot(resource.Key, resource.Value);
        }
    }
}
