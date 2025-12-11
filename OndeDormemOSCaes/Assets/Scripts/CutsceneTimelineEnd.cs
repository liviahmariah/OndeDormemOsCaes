using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneTimelineEnd : MonoBehaviour
{
    public PlayableDirector director;
    public string nextScene;

    void Start()
    {
        director.stopped += OnTimelineStopped;
    }

    void OnTimelineStopped(PlayableDirector d)
    {
        SceneManager.LoadScene(nextScene);
    }
}
