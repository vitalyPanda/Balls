using UnityEngine;

public class BonusBiheviour : MonoBehaviour, IObject
{
    public int Index
    {
        get
        {
            return index;
        }
    }

    public string Name
    {
        get
        {
            return ObjectName;
        }
    }

    public Vector2 pos
    {
        get
        {
            return transform.position;
        }
    }

    public int num
    {
        get
        {
            return 0;
        }
    }
    [Header("Свойства")]
    public int index;
    public string ObjectName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameBiheviour.singleton.sound.PlayBonus();
        GameBiheviour.singleton.objSetter.rows.Remove(this);
        GameBiheviour.singleton.ballHolder.CoutBalls++;
        GameBiheviour.singleton.ballsCounter.count++;
        GameBiheviour.singleton.ballsCounter.SetText();
        Destroy(gameObject);
    }
}
