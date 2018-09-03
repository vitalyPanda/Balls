using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress
{
    const string key = "Progress";
    public Progress Load()
    {
        if (!PlayerPrefs.HasKey(key)) return new Progress();
        return JsonUtility.FromJson<Progress>(PlayerPrefs.GetString(key));
    }



    public void Save(Progress progress)
    {

        PlayerPrefs.SetString(key, JsonUtility.ToJson(progress));
        PlayerPrefs.Save();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(key);
    }

}
[Serializable]
public class Progress
{
    public bool new_Progress = true;
    public bool isShooting;
    public float Angle;
    public List<ObjectToSet> objects = new List<ObjectToSet>();
    public int row_Count;
    public int CountBalls;
    public int currentScore;

    public Progress()
    {

    }
    public void Set(bool aimcanshoot, float angle, int countR, int countB)
    {
        new_Progress = false;
        isShooting = !aimcanshoot;
        Angle = angle;
        row_Count = countR;
        CountBalls = countB;

    }
    public void SetScore(int score)
    {
        currentScore = score;
    }

    public void SetObjects(List<IObject> objs)
    {
        objects.Clear();
        if (objs.Count == 0) return;
        for (int i = 0; i < objs.Count; i++)
        {

            objects.Add(new ObjectToSet() { Name = objs[i].Name, index = objs[i].Index, Pos = objs[i].pos, color = objs[i].num });
        }
    }

}


[Serializable]
public class ObjectToSet
{
    public string Name;
    public int index;
    public Vector2 Pos;
    public int color;
}