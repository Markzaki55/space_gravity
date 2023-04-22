using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnextscene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManger.instance.nexLevel();
        }
    }
}