using System;
using System.Collections.Generic;
using UnityEngine;

public class AccomplishmentTracker : MonoBehaviour
{
    private static Dictionary<string, Tuple<List<ICreditObserver>, int>> accomplishments = 
        new Dictionary<string, Tuple<List<ICreditObserver>, int>>();

    #region Transactions

    public static int GetProperty(string propertyName) => accomplishments[propertyName].Item2;

    public static void ResetProperty(string propertyName)
    {
        var obj = accomplishments[propertyName];
        var obj2 = new Tuple<List<ICreditObserver>, int>(obj.Item1, 0);
        accomplishments[propertyName] = obj2;
    }

    public static void CreditProperty(string propertyName, int amount)
    {
        StartTracking(propertyName);

        var obj = accomplishments[propertyName];
        var obj2 = new Tuple<List<ICreditObserver>, int>(obj.Item1, obj.Item2 + amount);
        accomplishments[propertyName] = obj2;
        foreach (var observer in accomplishments[propertyName].Item1)
            observer.Credit();
    }

    #endregion

    #region Subscriptions

    public static void AddObserverForCreditRedSquare(string propertyName, ICreditObserver observer)

    {
        StartTracking(propertyName);

        var observers = accomplishments[propertyName].Item1;
        if (observers != null)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }
    }

    public static void RemoveObserverForCreditRedSquare(string propertyName, ICreditObserver observer)
    {
        if (accomplishments.ContainsKey(propertyName))
        {
            var observers = accomplishments[propertyName].Item1;
            if (observers != null)
            {
                if (observers.Contains(observer))
                    observers.Remove(observer);
            }
            if (observers.Count == 0)
                accomplishments[propertyName] = null;
        }
    }

    #endregion

    #region Private Helpers

    private static void StartTracking(string propertyName)
    {
        if (!accomplishments.ContainsKey(propertyName))
            accomplishments[propertyName] = new Tuple<List<ICreditObserver>, int>(new List<ICreditObserver>(), 0);
    }

    #endregion

}