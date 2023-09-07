using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Characters;

    public static GameManager instance; 
    private int _charIndex;
    public int charIndex {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {

    // }

    // private void OnEnable() {
    //     SceneManager.sceneLoaded += OnLevelFinishedLoading;
    // }

    // private void OnDisable() {
    //     SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    // }
}
