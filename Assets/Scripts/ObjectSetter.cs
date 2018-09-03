using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetter : MonoBehaviour
{

    public int y;
    public List<IObject> rows = new List<IObject>();
    public int _numberRows = 1;
    public int BonusInterval = 9;
    public int startY = -90;
    public float min = -150, max = 150, widht = 120;

    private readonly string[] Objects = new string[] { "BoxObject", "SphereObject", "TriangleObject", "SixObject", "StarObject" };

    public void LoadObjects(List<ObjectToSet> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject ga = Instantiate(Resources.Load<GameObject>(objects[i].Name));
            if (objects[i].Name == "Bonus")
            {
                var o = ga.GetComponent<BonusBiheviour>();
                o.index = _numberRows;
                o.ObjectName = "Bonus";
                rows.Add(o);
            }
            else
            {
                var o = ga.GetComponent<ObjectBiheviour>();
                o.index = objects[i].index;
                o.ObjectName = objects[i].Name;
                o.ColorNum = objects[i].color;
                o.SetColor();
                rows.Add(o);
            }
            ga.transform.SetParent(transform);
            ga.transform.localPosition = objects[i].Pos;
            ga.transform.localScale = Vector3.one;
        }
    }

    public void AddRow()
    {
        if (!Check()) return;
        int rnd = Random.Range(2, 4);
        List<Transform> local = new List<Transform>();
        bool bonus = true;
        for (int i = 0; i < rnd; i++)
        {
            float[][] d = HelperClass.GetSpace(local, widht, min, max);

            if (d.GetLength(0) == 0) break;
            var curpos = d[Random.Range(0, d.GetLength(0))];

            if (bonus && _numberRows % BonusInterval == 0)
            {
                bonus = false;
                GameObject ga = Instantiate(Resources.Load<GameObject>("Bonus"));
                var o = ga.GetComponent<BonusBiheviour>();
                o.index = _numberRows;
                o.ObjectName = "Bonus";
                local.Add(ga.transform);
                ga.transform.SetParent(transform);
                ga.transform.localPosition = new Vector2(Random.Range(curpos[0], curpos[1]), startY);
                ga.transform.localScale = Vector3.one;
                rows.Add(o);
                continue;
            }
            string objname = Objects[Random.Range(0, Objects.Length)];
            ObjectBiheviour go = Instantiate(Resources.Load<GameObject>(objname)).GetComponent<ObjectBiheviour>();
            int color = Random.Range(_numberRows - 3, _numberRows);
            go.ColorNum = color < 1 ? 1 : color;
            go.SetColor();
            rows.Add(go);
            go.index = _numberRows;
            go.ObjectName = objname;
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector2(Random.Range(curpos[0], curpos[1]), startY);
            go.x = go.transform.localPosition.x;
            go.transform.localScale = Vector3.one;
            local.Add(go.transform);

        }
        _numberRows++;
        startY -= 100;

        StartCoroutine("MoveUP");
    }

    private bool Check()
    {
        if (rows.Count == 0) return true;
        if (rows[0].Index == _numberRows - 7)
        {
            GameBiheviour.singleton.restart.SetActive();
            GameBiheviour.singleton.bestScore.SetBestScore(GameBiheviour.singleton.score.GetScore());
            return false;
        }
        return true;
    }

    private IEnumerator MoveUP()
    {
        float y = (int)transform.localPosition.y + 100;
        while (y - transform.localPosition.y > 0.1)
        {
            transform.localPosition += new Vector3(0, Speed);
            yield return new WaitForSeconds(time);
        }
        transform.localPosition = new Vector3(0, y);
        GameBiheviour.singleton.RowAdded();
    }
    public float Speed, time;

}

