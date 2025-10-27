using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
 private Rigidbody rb; 


 private int count;

 private float movementX;
 private float movementY;

 public float speed = 0;

 public TextMeshProUGUI countText;

 public GameObject winTextObject;

 // Start is called before the first frame update.
 void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

        rb.AddForce(movement * speed); 
    }

 
 void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "PickUp" tag.
 if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }

 // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();

 if (count >= 10)
        {
            winTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

private void OnCollisionEnter(Collision collision)
{
 if (collision.gameObject.CompareTag("Enemy"))
    {
        Destroy(gameObject); 
 
 // Update the winText to display "You Lose!"
        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
 
    }

}


}