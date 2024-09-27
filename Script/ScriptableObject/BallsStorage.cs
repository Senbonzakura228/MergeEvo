using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Script;
using UnityEngine;


[CreateAssetMenu(fileName = "BallsStorage", menuName = "Balls/Storage", order = 0)]
public class BallsStorage : ScriptableObject
{
    [SerializeField] private List<Ball> storage;

    public int maxBallLevel => storage.Count - 1;

    public Ball GetNextLevelBall(int currentLevel)
    {
        var coincidences = storage.Where(item => item.Level == currentLevel + 1);
        List<Ball> result = new List<Ball>();
        foreach (var ball in coincidences)
        {
            result.Add(ball);
        }

        if (result.Count == 0) return storage.First(item => item.Level == currentLevel);
        return result[0];
    }
}