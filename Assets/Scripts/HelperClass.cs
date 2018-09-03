using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HelperClass
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static float[][] GetSpace(List<Transform> objects, float wight, float min, float max)
    {
        if (objects.Count == 0)
            return new float[][] { new float[] { min, max } };
        List<float[]> result = new List<float[]>();
        float I = min;
        int counter = 0;
        var sorted = objects.ToList().OrderBy(x => x.localPosition.x).ToArray();
        for (int i = 0; i < objects.Count + 1; i++)
        {
            float[] length = new float[2];
            length[0] = I;
            if (sorted.Length == counter)
                length[1] = max;
            else
            {
                length[1] = sorted[counter].localPosition.x - wight / 2;
                I = sorted[counter].localPosition.x + wight / 2;
            }
            if (length[0] < length[1])
                result.Add(length);
            counter++;
        }
        return result.ToArray();
    }
    public static Color GetColor(int n, float v)
    {
        float value = (float)n % 50f / 50f;
        return Color.HSVToRGB(value, v, v);
    }
}
