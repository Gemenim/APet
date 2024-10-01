using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");    
    public float MouseX => Input.GetAxis("Mouse X");
}
