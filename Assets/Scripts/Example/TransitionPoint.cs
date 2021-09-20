using UnityEngine;
using SFTool;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.Instance.SceneTransition();
        }
    }
}
