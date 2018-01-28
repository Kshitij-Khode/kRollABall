using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
	int i;

    public void LoadByIndex(int sceneIndex)
    {	
    	i = sceneIndex;
    	Invoke("now",3);
    }

    void now(){

        SceneManager.LoadScene(i);
        Time.timeScale = 1;
    }

}