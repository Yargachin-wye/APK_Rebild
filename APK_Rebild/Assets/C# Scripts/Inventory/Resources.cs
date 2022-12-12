using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    static Dictionary<Resource, int> resources;
    static ResourcesUI resourcesUI;
    static Messager _messager;
    private void Awake()
    {
        resources = new Dictionary<Resource, int>();
        resourcesUI = GetComponent<ResourcesUI>();
        _messager = GetComponent<Messager>();
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
    public static bool TryRemoveResource(Dictionary<Resource, int> ress)
    {
        Dictionary<string,Color> text = new Dictionary<string, Color>();
        foreach(var res in ress)
        {
            if (!resources.ContainsKey(res.Key))
            {
                text.Add("you need " + res.Value.ToString() + " " + res.Key.name, res.Key.color);
            }
            else if(resources[res.Key] < res.Value)
            {
                text.Add("you need + " + (res.Value - resources[res.Key]).ToString() + " " + res.Key.name, res.Key.color);
            }
        }
        if(text.Count < 1)
        {
            foreach (var res in ress)
            {
                resources[res.Key] -= res.Value;
                resourcesUI.UpdateSlot(res.Key, resources[res.Key]);
            }
            return true;
        }
        _messager.DoMessage(text);
        return false;
    }
}
