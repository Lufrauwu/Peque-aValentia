using UnityEngine;

public class ChangeDimention : MonoBehaviour
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
