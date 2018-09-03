using UnityEngine;

public class GameBiheviour : MonoBehaviour
{

    public static GameBiheviour singleton;
    public static SaveProgress saveProgress = new SaveProgress();
    public Progress progress;
    void Awake()
    {
        BallPool.pos = ballHolder.transform.position;
        singleton = this;
        progress = saveProgress.Load();
        if (progress.new_Progress)
        {
            aim.CanShoot = true;
            objSetter.AddRow();
        }
        else
        {
            objSetter.LoadObjects(progress.objects);
            objSetter._numberRows = progress.row_Count;
            score.SetScore(progress.currentScore);
            ballsCounter.count = progress.CountBalls;
            ballsCounter.SetText();
            ballHolder.CoutBalls = progress.CountBalls;
            aim.CanShoot = true;
            aim.Angle = progress.Angle;
            if (progress.isShooting)
            {
                aim.CanShoot = false;

                ballHolder.PushBalls(progress.Angle);
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause) return;
        SaveProgress();
    }
    private void OnApplicationQuit()
    {
        SaveProgress();
    }

    private void SaveProgress()
    {
        progress.Set(aim.CanShoot, aim.Angle, objSetter._numberRows, ballHolder.CoutBalls);
        saveProgress.Save(progress);
    }

    public BallHolder ballHolder;
    public Aim aim;
    public ObjectSetter objSetter;
    public ScoreCounter score;
    public BallsCounter ballsCounter;
    public RestartUI restart;
    public BestScoreUI bestScore;
    public SoundManager sound;
    public float BallSpeed;


    public void BallsEnded()
    {
        objSetter.AddRow();
    }

    public void RowAdded()
    {
        progress.SetObjects(objSetter.rows);
        progress.SetScore(score.GetScore());
        aim.CanShoot = true;
        ballsCounter.count = ballHolder.CoutBalls;
        ballsCounter.SetText();
    }

    [ContextMenu("Clear Progress")]
    public void InspectorClearProgress()
    {
        new SaveProgress().Clear();
    }
}
