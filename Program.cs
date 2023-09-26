using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cola_estatica_con_arreglos
{
    internal class Program
    {
        public class StaticQueue<Cola>
        {
            private Cola[] queueArray; // Arreglo para almacenar elementos de la cola
            private int front;      // Índice del elemento frontal de la cola
            private int rear;       // Índice del elemento trasero de la cola
            private int capacity;   // Capacidad máxima de la cola
            private int count;      // Cantidad actual de elementos en la cola

            // Constructor para inicializar la cola con una capacidad especificada
            public StaticQueue(int capacity)
            {
                this.capacity = capacity;
                this.queueArray = new Cola[capacity]; // Inicializamos el arreglo con la capacidad especificada
                this.front = 0; // Inicialmente, la cola está vacía, por lo que el frente y el trasero se establecen en 0
                this.rear = -1;
                this.count = 0;
            }

            // Método para agregar un elemento al final de la cola (Enqueue)
            public void Enqueue(Cola item)
            {
                if (count < capacity) // Verificamos si hay espacio en la cola
                {
                    rear = (rear + 1) % capacity; // Movemos el índice trasero circularmente
                    queueArray[rear] = item; // Agregamos el elemento en la posición trasera
                    count++; // Incrementamos la cantidad de elementos en la cola
                }
                else
                {
                    Console.WriteLine("La cola está llena. No se puede agregar más elementos.");
                }
            }

            // Método para eliminar y retornar el elemento frontal de la cola (Dequeue)
            public Cola Dequeue()
            {
                if (count > 0) // Verificamos si la cola no está vacía
                {
                    Cola item = queueArray[front]; // Obtenemos el elemento en la posición frontal
                    front = (front + 1) % capacity; // Movemos el índice frontal circularmente
                    count--; // Decrementamos la cantidad de elementos en la cola
                    return item; // Retornamos el elemento extraído
                }
                else
                {
                    Console.WriteLine("La cola está vacía. No se puede extraer ningún elemento.");
                    return default(Cola); // Retornamos el valor predeterminado del tipo (por ejemplo, null para referencias)
                }
            }

            // Método para consultar el elemento frontal de la cola sin eliminarlo (Peek)
            public Cola Peek()
            {
                if (count > 0) // Verificamos si la cola no está vacía
                {
                    return queueArray[front]; // Retornamos el elemento en la posición frontal
                }
                else
                {
                    Console.WriteLine("La cola está vacía.");
                    return default(Cola);
                }
            }

            // Método para verificar si la cola está vacía
            public bool IsEmpty()
            {
                return count == 0;
            }

            // Método para verificar si la cola está llena
            public bool IsFull()
            {
                return count == capacity;
            }

            // Método para obtener la cantidad de elementos en la cola
            public int Count()
            {
                return count;
            }
        }

        class Queue
        {
            static void Main(string[] args)
            {
                // Ejemplo de uso de la cola estática
                StaticQueue<int> queue = new StaticQueue<int>(5);

                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                Console.WriteLine("Elementos en la cola: " + queue.Count());

                Console.WriteLine("Elemento frontal de la cola: " + queue.Peek());

                while (!queue.IsEmpty())
                {
                    Console.WriteLine("Elemento extraído de la cola: " + queue.Dequeue());
                }
            }
        }
    }
}
