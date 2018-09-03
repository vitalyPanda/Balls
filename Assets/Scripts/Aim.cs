using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private Transform Ball;
    [SerializeField]
    private Image Points;
    [HideInInspector]
    public bool CanShoot;
    [HideInInspector]
    public float Angle;

    void Update()
    {
        if (!CanShoot) return;
        if (Input.GetMouseButtonUp(0))
        {
            GameBiheviour.singleton.ballHolder.PushBalls(Angle);
            CanShoot = false;
        }
        if (!Input.GetMouseButton(0))
        {
            Points.enabled = false;
            return;
        }
        if (!Points.enabled)
            Points.enabled = true;
        Vector2 diference = Ball.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float sign = (Ball.position.y < Camera.main.ScreenToWorldPoint(Input.mousePosition).y) ? -1.0f : 1.0f;
        Angle = Vector2.Angle(Vector2.right, diference) * sign;
        transform.localEulerAngles = new Vector3(0, 0, Angle - 90);
    }
}
