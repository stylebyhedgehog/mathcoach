
using UnityEngine;
using UnityEngine.UI;

public class FirebaseInit : MonoBehaviour
{
    public static FirebaseInit Instance;

    [SerializeField] private Text text;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                Debug.Log("loaded1");

                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    var app = Firebase.FirebaseApp.DefaultInstance;
                    text.text = "loaded";
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                }
                else
                {
                    UnityEngine.Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });

        }
    }

    
}
