using System;
using System.Collections.Concurrent;
using UnityEngine;

public class UnityMainThreadDispatcher : MonoBehaviour
{
    private static UnityMainThreadDispatcher _instance;
    private static ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();

    public static UnityMainThreadDispatcher Instance()
    {
        if (!_instance)
        {
            var obj = new GameObject("MainThreadDispatcher");
            _instance = obj.AddComponent<UnityMainThreadDispatcher>();
            DontDestroyOnLoad(obj);
        }
        return _instance;
    }

    void Update()
    {
        while (_actions.TryDequeue(out Action action))
        {
            action.Invoke();
        }
    }

    public static void Enqueue(Action action)
    {
        _actions.Enqueue(action);
    }
}
