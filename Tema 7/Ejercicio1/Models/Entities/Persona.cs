namespace Ejercicio1.Models.Entities
{
    public class Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _edad;
        #endregion

        #region getters y setters
        public int id { get { return _id; } }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string apellidos
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public int edad
        {
            get { return _edad; }
            set { _edad = value; }
        }
        #endregion

        #region constructores
        public Persona() { }

        public Persona(int id, string nombre, string apellido, int edad)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _edad = edad;
        }
        #endregion
    }
}