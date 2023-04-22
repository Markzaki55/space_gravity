using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cuttoscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tonextsence());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tonextsence()
    {
        yield return new WaitForSeconds(6.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            
    }
}
