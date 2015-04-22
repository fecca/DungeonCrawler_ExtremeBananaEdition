using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object lockObject = new object();

    public static T Instance
    {
        get
        {
            if (ApplicationIsQuitting)
            {
                Debug.LogWarning("The singleton called for has already been destroyed due to application quitting.");
                return null;
            }

            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                    if (instance != null)
                    {
                        return instance;
                    }

                    GameObject go = new GameObject(typeof(T).ToString());
                    instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
        protected set
        {
            if (GameObject.FindObjectOfType<T>() == null)
            {
                instance = value;
            }
            else
            {
                Debug.LogWarning("An instance of " + typeof(T) + " already exists in the current context.");
            }
        }
    }

    private static bool ApplicationIsQuitting = false;
    /// <summary>
    /// To prevent a singleton being called by a living object after it's been destroyed.
    /// </summary>
    public void OnDestroy()
    {
        ApplicationIsQuitting = true;
    }
}