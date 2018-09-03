using System.Collections.Generic;
using UnityEngine;

public static class BallPool
{
    private static List<Ball> BallsPool = new List<Ball>();
    private static List<Ball> activeBalls = new List<Ball>();
    public static Vector3 pos = Vector3.zero;

    public static Ball Get()
    {
        Ball Resultball = null;
        foreach (var ball in BallsPool)
            if (!ball.Active)
            {
                Resultball = ball;
                break;
            }
        if (!Resultball)
        {
            Resultball = Object.Instantiate(Resources.Load<GameObject>("Ball")).GetComponent<Ball>();
            BallsPool.Add(Resultball);
        }
        Resultball.Reset();
        activeBalls.Add(Resultball);
        return Resultball;
    }

    public static void Reset()
    {
        BallsPool.Clear();
        activeBalls.Clear();
    }

    public static void Deactivate(this Ball ball)
    {
        GameBiheviour.singleton.ballsCounter.count++;
        GameBiheviour.singleton.ballsCounter.SetText();
        activeBalls.Remove(ball);
        if (activeBalls.Count == 0)
            GameBiheviour.singleton.BallsEnded();
    }

}
