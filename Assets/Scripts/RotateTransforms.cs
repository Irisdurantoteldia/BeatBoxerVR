using System.Collections.Generic;
using UnityEngine;

public class RotateTransforms : MonoBehaviour
{
    // La barra central que servirá de pivote
    public Transform centralBarPivot;

    // Lista de Transforms (cuadrados) a rotar
    public List<Transform> transformsToRotate;

    // Velocidad angular base en grados por segundo
    public float angularSpeed = 90f;

    // Desplazamiento de la rotación en grados
    public float rotationOffset = 0f;

    // Incremento de velocidad por índice
    public float speedIncrement = 0.5f; // Cada elemento rotará 0.5 grados por segundo más rápido que el anterior

    // Actualización por fotograma
    void Update()
    {
        // Si la barra central no está asignada, salir del método
        if (centralBarPivot == null)
        {
            Debug.LogError("Central bar pivot is not assigned!");
            return;
        }

        // Calcula el punto central de la barra
        Vector3 centerPoint = centralBarPivot.position;

        // Recorrer cada cuadrado con su índice
        for (int i = 0; i < transformsToRotate.Count; i++)
        {
            Transform t = transformsToRotate[i];

            // Calcular la posición central del cuadrado (su punto medio)
            Vector3 squareCenter = t.position;

            // Calcular la posición relativa del cuadrado respecto al punto central de la barra
            Vector3 relativePosition = squareCenter - centerPoint;

            // Ajustar la velocidad de rotación en función del índice
            float rotationSpeed = angularSpeed + (speedIncrement * i); // Velocidad base + incremento lineal

            // Calcular la rotación para este fotograma
            float rotationAmount = rotationSpeed * Time.deltaTime;

            // Añadir el desplazamiento de rotación a la cantidad de rotación
            rotationAmount += rotationOffset;

            // Aplicar la rotación sobre su eje Z, respetando el punto central de la barra
            relativePosition = Quaternion.Euler(0f, 0f, rotationAmount) * relativePosition;

            // Actualizar la posición del cuadrado con la nueva posición relativa
            t.position = centerPoint + relativePosition;

            // Mantener la rotación del objeto si es necesario (opcional)
            t.rotation = Quaternion.Euler(0f, 0f, t.rotation.eulerAngles.z + rotationAmount);
        }
    }
}
