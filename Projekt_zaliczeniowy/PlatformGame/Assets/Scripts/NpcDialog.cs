using UnityEngine;

public class NpcDialog : MonoBehaviour
{
    
    [Header("Obiekt Dialogowy Npc")]
    [SerializeField] private GameObject dialogObject;

    private void Start()
    {
        if (dialogObject)
            dialogObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogObject.SetActive(false);
        }
    }
}