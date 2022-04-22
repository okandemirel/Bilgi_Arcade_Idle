using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {

            EventManager.Instance.onInputDragged?.Invoke(InputData);
        }
        else
        {
            EventManager.Instance.onInputReleased?.Invoke();
        }
    }

    private Vector2 InputData => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

}
