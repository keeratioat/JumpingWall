
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceen : MonoBehaviour
{
    public void loadSceen(string str)
    {
        SceneManager.LoadScene(str);
    }
}
