using UnityEngine;
using UnityEngine.UI;

public class BallsCounter : MonoBehaviour
{

    private Text text;
    [HideInInspector]
    public int count = 0;
    public void SetText()
    {
        if (!text) text = GetComponent<Text>();
        text.text = "x" + count;
    }
}
