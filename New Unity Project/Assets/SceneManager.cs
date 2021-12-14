using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public int num;
    public GameObject transition;
    
    public void SceneSelect()
    {
        Instantiate(transition,this.transform.position, Quaternion.identity);
        StartCoroutine(SceneOpt());
    }

    private IEnumerator SceneOpt()
    {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: num);
    }
}
