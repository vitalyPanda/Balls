using UnityEngine;
using UnityEngine.UI;

public class ObjectBiheviour : MonoBehaviour, IObject
{
    public float x;
    private Image _i;
    private Image _image
    {
        get
        {
            if (!_i) _i = GetComponent<Image>();
            return _i;
        }
    }

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
            return ColorNum;
        }
    }

    public string ObjectName;
    [SerializeField]
    private Text text;

    public int index;
    public int ColorNum;
    private Animator animator;

    public float RotateSpeed;

    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        transform.eulerAngles += new Vector3(0, 0, RotateSpeed * Time.deltaTime);
        text.transform.rotation = Quaternion.identity;
    }

    public void SetColor()
    {
        text.text = ColorNum.ToString();
        _image.color = HelperClass.GetColor(ColorNum, .7f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ColorNum--;
        SetColor();
        if (ColorNum == 0)
        {
            GameBiheviour.singleton.objSetter.rows.Remove(this);
            GameBiheviour.singleton.score.AddScore();
            Destroy();
            return;
        }
        if (!animator) animator = GetComponent<Animator>();
        animator.SetTrigger("Blash");
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
