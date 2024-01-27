using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static Dictionary<string, List<Delegate>> events = new Dictionary<string, List<Delegate>>();

    private static void CommonAdd (string eventName, Delegate callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Add(callback);
        }
        else
        {
            actions = new List<Delegate>();
            actions.Add(callback);
            events.Add(eventName, actions);
        }
    }

    public static void AddEvent(string eventName, Action callback)
    {
        CommonAdd(eventName, callback);
    }

    public static void AddEvent<T> (string eventName, Action<T> callback)
    {
        CommonAdd(eventName, callback);
    }

    public static void AddEvent<T, T1>(string eventName, Action<T, T1> callback)
    {
        CommonAdd(eventName, callback);
    }

    public static void AddEvent<T, T1, T2>(string eventName, Action<T, T1, T2> callback)
    {
        CommonAdd(eventName, callback);
    }

    private static void CommonRemove (string eventName, Delegate callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Remove(callback);
            if (actions.Count == 0)
            {
                events.Remove(eventName);
            }
        }
    }

    public static void RemoveEvent(string eventName, Action callback)
    {
        CommonRemove(eventName, callback);
    }

    public static void RemoveEvent<T>(string eventName, Action<T> callback)
    {
        CommonRemove(eventName, callback);
    }

    public static void RemoveEvent<T, T1>(string eventName, Action<T, T1> callback)
    {
        CommonRemove(eventName, callback);
    }

    public static void RemoveEvent<T, T1, T2>(string eventName, Action<T, T1, T2> callback)
    {
        CommonRemove(eventName, callback);
    }

    public static void RemoveAllEvents ()
    {
        events.Clear();
    }

    public static void DispatchEvent(string eventName)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke();
            }
        }
    }

    public static void DispatchEvent<T>(string eventName, T arg)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg);
            }
        }
    }

    public static void DispatchEvent<T, T1>(string eventName, T arg, T1 arg2)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg, arg2);
            }
        }
    }

    public static void DispatchEvent<T1, T2, T3>(string eventName, T1 arg, T2 arg2, T3 arg3)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg, arg2, arg3);
            }
        }
    }
}
