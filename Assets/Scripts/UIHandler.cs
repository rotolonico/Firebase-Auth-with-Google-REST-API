using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles test UIs present in the SignIn Scene
/// </summary>

public class UIHandler : MonoBehaviour
{
    public InputField code;

    public void OnClickGetGoogleCode()
    {
        GoogleAuthenticator.GetAuthCode();
    }

    public void OnClickGoogleSignIn()
    {
        GoogleAuthenticator.ExchangeAuthCodeWithIdToken(code.text, idToken =>
            {
                FirebaseAuthHandler.SingInWithToken(idToken, "google.com");
            });
    }
}
