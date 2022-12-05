using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    static Dictionary<Resource, int> resources;
    static ResourcesUI resourcesUI;
    static Message _message;
    private void Awake()
    {
        resources = new Dictionary<Resource, int>();
        resourcesUI = GetComponent<ResourcesUI>();
        _message = GetComponent<Message>();
    }
    private void Start()
    {
        resourcesUI.UpdateAll(resources);
    }
    public static void AddResource(Resource res)
    {
        if (resources.ContainsKey(res))
        {
            resources[res]++;
        }
        else
        {
            resources.Add(res, 1);
        }
        resourcesUI.UpdateSlot(res, resources[res]);
    }
    public static bool TryRemoveResource(Resource res, int number)
    {
        if (!resources.ContainsKey(res))
        {
            _message.DoMessage("you need " + number.ToString() + " " + res.name, res.color);
            return false;
        }
        else if (resources.ContainsKey(res) && resources[res] < number)
        {
            _message.DoMessage("you need + " + (number - resources[res]).ToString() + " " + res.name, res.color);
            return false;
        }
        resources[res] -= number;
        resourcesUI.UpdateSlot(res, resources[res]);
        return true;
    }
}
