using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = default;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
           
        }
        else
        {
            instance = this;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
