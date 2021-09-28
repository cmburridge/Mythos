using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Collections : ScriptableObject
{
    public List<Collectable> collection;

    public void Collect(Collectable obj)
    {
        collection.Add(obj);
        obj.collected = true;
    }
    
    public void Remove(Collectable obj)
    {
        foreach (var collectable in collection.Where(collectable => collectable == obj))
        {
            collectable.collected = false;
            collection.Remove(collectable);
        }
    }

    public void clear()
    {
        foreach (var collectable in collection)
        {
            collectable.collected = false;
        }
        collection.Clear();
    }
}
