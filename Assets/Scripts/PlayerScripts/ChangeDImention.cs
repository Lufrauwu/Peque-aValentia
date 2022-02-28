using UnityEngine;

public class ChangeDImention : MonoBehaviour
{

    [SerializeField] private GameObject _dimention;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_dimention.activeSelf)
            {           
                _dimention.SetActive(false);
            }
            else
            {
                _dimention.SetActive(true);
            }
           
        }

        
    }

}
