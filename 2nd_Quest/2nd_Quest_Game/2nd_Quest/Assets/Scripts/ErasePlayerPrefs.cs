using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorTools : EditorWindow
{
    // Start is called before the first frame update
    [MenuItem ("Tools/Reset Player Pref")]
    public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("<b> **** Player Prefs Deleted Sucessfully **** </b>");
    }
}
