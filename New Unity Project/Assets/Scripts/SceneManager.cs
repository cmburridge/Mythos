using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SceneManager : MonoBehaviour
{
    public int opt1;
    public int opt2;
    public int randomValue;
    public GameObject transition;
    
    public void SceneSelect()
    {
        randomValue = Random.Range(opt1, opt2);
        Instantiate(transition,this.transform.position, Quaternion.identity);
        StartCoroutine(SceneOpt());
    }

    private IEnumerator SceneOpt()
    {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: randomValue);
    }
}
