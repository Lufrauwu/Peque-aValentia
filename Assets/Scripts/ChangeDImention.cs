using UnityEngine;

public class ChangeDImention : MonoBehaviour
{

    [SerializeField] private GameObject dimention;
    //[SerializeField] private GameObject plataforma;
    private bool verify;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dimention.activeSelf)
            {           
                dimention.SetActive(false);
            }
            else
            {
                dimention.SetActive(true);
            }
           
        }
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            if (plataforma.)
            {
                plataforma.SetActive(false);
            }
            else
            {
                plataforma.SetActive(true);
            }*/

        
    }

}
