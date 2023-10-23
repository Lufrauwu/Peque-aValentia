using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator _transition = default;
    private float _transitionTime = 1.0f;
    
    public static LevelManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);       
        }
        else
        {
            Instance = this;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public IEnumerator Transition()
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
    }
}
