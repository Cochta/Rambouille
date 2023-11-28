using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBodyCollider : MonoBehaviour
{
    [SerializeField]
    private SawBody _sawBody;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Chain")
        {
            StartCoroutine("Offset");
        }
    }
    IEnumerator Offset()
    {
        Vector2 tempDir = _sawBody.Direction;
        float tempRotation = _sawBody.RotationSpeed;
        _sawBody.Direction = new Vector2(0, 0);
        _sawBody.RotationSpeed = 0;
        yield return new WaitForSeconds(_sawBody.TimeOffset);
        _sawBody.Direction = tempDir * -1;
        _sawBody.RotationSpeed = tempRotation * -1;
    }
}
