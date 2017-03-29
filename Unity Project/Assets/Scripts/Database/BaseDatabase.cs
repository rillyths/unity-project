using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class BaseDatabase<T> : ScriptableObject where T: Item
{
    // Created Mar 24, 2017 by rillyths


    [SerializeField]
    private List<T> database;

    private void OnEnable()
    {
        if (database == null) database = new List<T>();
    }

    public void Add(T item)
    {
        database.Add(item);
    }

    public void Remove(T item)
    {
        database.Remove(item);
    }

    public void RemoveAt(int index)
    {
        database.RemoveAt(index);
    }

    public int Count()
    {
        return database.Count;
    }

    public T GetItem(int index)
    {
        return database.ElementAt(index);
    }
}
