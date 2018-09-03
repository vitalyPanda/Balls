using System.Collections;
using UnityEngine;

public class BallHolder : MonoBehaviour
{
    [HideInInspector]
    public int CoutBalls = 2;

    [Header("Свойства шарика")]
    public float Interval;
    public float BallSpeed;

    private float angle;


    public void PushBalls(float angle)
    {
        this.angle = angle;
        StartCoroutine("PushTimed");
    }

    IEnumerator PushTimed()
    {
        int cv = CoutBalls;

        GameBiheviour.singleton.ballsCounter.count = cv;
        for (int i = 0; i < cv; i++)
        {
            GameBiheviour.singleton.ballsCounter.count--;
            GameBiheviour.singleton.ballsCounter.SetText();
            PushBall();

            yield return new WaitForSeconds(Interval);
        }


    }

    private void PushBall()
    {
        Ball ball = BallPool.Get();
        ball.transform.SetParent(transform);
        ball.transform.localRotation = Quaternion.Euler(0, 0, angle);
        ball.transform.localScale = Vector3.one;
        ball.SetActive(true);
        ball.transform.localPosition = Vector2.zero;
        ball.Rigid.AddForce(-ball.transform.right * BallSpeed, ForceMode2D.Impulse);

    }
}
