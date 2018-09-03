using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUI : MonoBehaviour
{

    public void SetActive()
    {
        gameObject.SetActive(true);
        GameBiheviour.singleton.sound.Lose();
        GameBiheviour.saveProgress.Clear();
    }

    public void Restart()
    {

        BallPool.Reset();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
