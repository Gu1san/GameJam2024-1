using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float pushForce = 6f;
    [SerializeField] KeyCode pushKey = KeyCode.LeftShift;

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box") && Input.GetKey(pushKey))
        {
            GameObject collidedObj = collision.gameObject;
            Rigidbody otherRb = collidedObj.GetComponent<Rigidbody>();
            // Calcula a dire��o do empurr�o
            Vector3 pushDirection = GetPushDirection(collidedObj.transform.position);

            otherRb.velocity = pushDirection * pushForce;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Rigidbody otherRb = other.GetComponent<Rigidbody>();
            otherRb.velocity = Vector3.zero;
        }
    }

    // Calcula a dire��o do empurr�o baseada na posi��o do objeto alvo
    Vector3 GetPushDirection(Vector3 targetPosition)
    {
        // Calcula a dire��o do empurr�o
        Vector3 pushDirection = targetPosition - transform.position;

        // Normaliza a dire��o para manter uma for�a constante
        pushDirection.Normalize();

        // Limita a dire��o do empurr�o a quatro dire��es (cima, baixo, esquerda, direita)
        float x = Mathf.Abs(pushDirection.x);
        float z = Mathf.Abs(pushDirection.z);

        if (x > z)
        {
            pushDirection.z = 0f; // Limita a dire��o vertical
        }
        else
        {
            pushDirection.x = 0f; // Limita a dire��o horizontal
        }

        pushDirection.y = 0;

        return pushDirection;
    }

    public void Test()
    {
        Debug.Log("aaaaaaa");
    }
}
