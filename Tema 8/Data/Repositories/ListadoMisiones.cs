using Domain.Entities;
using Domain.Interfaces;


namespace Data.Repositories
{
    public class ListadoMisiones : ListadoMisionesRepositorio
    {
        private static List<Mision> _misiones = new List<Mision>()
        {
            new Mision(1, "Rescatar al gato", "Rescata al gato atrapado en el árbol.", 50.0),
            new Mision(2, "Encontrar el tesoro", "Encuentra el tesoro escondido en la isla.", 200.0),
            new Mision(3, "Derrotar al dragón", "Derrota al dragón que amenaza el pueblo.", 500.0)
        };

        public List<Mision> getMisiones()
        {
            return _misiones;
        }
    }
}