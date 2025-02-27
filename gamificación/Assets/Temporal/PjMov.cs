using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMov : MonoBehaviour
{
    public List<Transform> puntos; // Lista de puntos de referencia
    public float velocidadMovimiento = 5f; // Velocidad de movimiento
    private int indicePuntoActual = 0; // �ndice del punto actual
    private bool moviendose = false; // Indica si el personaje se est� moviendo

    void Update()
    {
        // Mover al siguiente punto con la tecla derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoverAlSiguientePunto();
        }

        // Mover al punto anterior con la tecla izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoverAlPuntoAnterior();
        }

        // Si el personaje est� en movimiento, moverlo hacia el punto actual
        if (moviendose)
        {
            MoverHaciaPunto();
        }
    }

    void MoverAlSiguientePunto()
    {
        if (indicePuntoActual < puntos.Count - 1)
        {
            indicePuntoActual++;
            moviendose = true;
        }
        else
        {
            Debug.Log("No hay m�s puntos hacia adelante.");
        }
    }

    void MoverAlPuntoAnterior()
    {
        if (indicePuntoActual > 0)
        {
            indicePuntoActual--;
            moviendose = true;
        }
        else
        {
            Debug.Log("No hay m�s puntos hacia atr�s.");
        }
    }

    void MoverHaciaPunto()
    {
        // Obtener la posici�n del punto actual
        Vector2 puntoDestino = puntos[indicePuntoActual].position;

        // Mover al personaje hacia el punto destino
        transform.position = Vector2.MoveTowards(transform.position, puntoDestino, velocidadMovimiento * Time.deltaTime);

        // Si el personaje llega al punto, detener el movimiento
        if ((Vector2)transform.position == puntoDestino)
        {
            moviendose = false;
        }
    }
}
