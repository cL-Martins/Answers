using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 1.2f;
    float sensitivityY = 1.2f;

    float rotationX = 0, rotationY = 0;

    float angleYMin = -90, angleYMax = 90;

    float smoothRotX = 0;
    float smoothRotY = 0;

    float smoothCoefx = 0.5f;
    float smoothCoefy = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void LateUpdate()//Para seguir o objeto com a posi��o j� atualizada
    {
        transform.position = characterHead.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.mode.Equals(Phases.Control) || GameController.mode.Equals(Phases.Die) || GameController.mode.Equals(Phases.Narrative))
        {
            float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
            float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

            //Suaviza��o da c�mera
            smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefx);
            smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefy);
            //

            //rotationX += horizontalDelta; Esses s�o da c�mera bruta
            //rotationY += verticalDelta;
            rotationX += smoothRotX;
            rotationY += smoothRotY;

            rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax); // Limitar rota��o da c�mera entre dois valores

            characterBody.localEulerAngles = new Vector3(0, rotationX, 0);// Fazer o personagem se mover na dire��o para onde a c�mera aponta

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        
    }
}
