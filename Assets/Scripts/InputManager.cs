
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    // public delegate void StartTouchEvent(Vector2 position, float time);
    // public event StartTouchTouchEvent OnStartTouch;
    // public delegate void EndTouchEvent(Vector2 position, float time);
    // public event EndTouchTouchEvent OnStartTouch;

    private TouchControls touchControls;

    private void Awake() {
        touchControls = new TouchControls();
        Debug.Log("Hello: Awake");
        touchControls.Enable();
    }

    private void onEnable(){
        touchControls.Enable();
        Debug.Log("Hello: Enable");
    }

    private void onDisable(){
        touchControls.Disable();
        Debug.Log("Hello: Disable");
    }

    private void Start(){
        Debug.Log("Hello: Start");
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.started += ctx =>  Debug.Log("Touched");
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        Debug.Log("Hello: End of Start");
    }

    private void StartTouch(InputAction.CallbackContext context){
        Debug.Log("Touch Start" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        // if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context){
        Debug.Log("Touch End");
        // if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }    
}
