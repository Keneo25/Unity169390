using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject nextLevel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            nextLevel.SetActive(true);
        }
    }



}
