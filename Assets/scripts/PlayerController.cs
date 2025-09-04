using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Controler input;
    [SerializeField] private float rotation=10f;
    [SerializeField] private float speed=10f;
    private Vector3 dir;
    
    void Start()
    {
        input = new Controler();
        input.PlayerMove.Enable();
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = input.PlayerMove.Move.ReadValue<Vector2>().normalized;
        dir.x = moveDir.x;
        dir.z = moveDir.y;
        transform.position+=dir*speed*Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward,dir,Time.deltaTime*rotation);
    }
}
