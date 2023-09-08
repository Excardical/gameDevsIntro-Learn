using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void restartGame() {
        SceneManager.LoadScene("Gameplay");
    }
}
