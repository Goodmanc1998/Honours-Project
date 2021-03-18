using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator animator;
    public string newScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        animator.SetTrigger("Fade");
        
    }

    public void EndAnimation()
    {
        SceneManager.LoadScene(newScene);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void quit()
    {
        Application.Quit();
    }

}
