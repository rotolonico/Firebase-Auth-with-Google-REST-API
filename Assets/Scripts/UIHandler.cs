using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles test UIs present in the SignIn Scene
/// </summary>

public class UIHandler : MonoBehaviour
{
    public void OnClickGetGoogleCode()
    {
        GoogleAuthenticator.SignInWithGoogle();
    }
}
