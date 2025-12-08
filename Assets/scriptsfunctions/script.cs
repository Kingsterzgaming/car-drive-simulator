using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public Button play; 
    public Button pause;
    public Button reset;
    public Button quit;
    public Button cancel;

    private void Awake()
    {
        play.onClick.AddListener(() => { SceneManager.LoadScene("new_game"); Debug.Log("pressed"); });
        quit.onClick.AddListener(() => { Application.Quit();Debug.Log("pressed");  });
    }

    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
