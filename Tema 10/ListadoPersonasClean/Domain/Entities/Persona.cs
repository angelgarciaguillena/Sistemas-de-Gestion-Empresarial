namespace Domain.Entities
{
    public class Persona
    {
        #region Atributos privados
        private int _id;
        private string _nombre;
        private string _apellidos;
        private DateTime _fechaNacimiento;
        private string _direccion;
        private string _telefono;
        private string _foto;
        private int _idDepartamento;
        #endregion

        #region Getters y Setters
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string? Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public int? IdDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value ?? 0; }
        }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, string foto, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _fechaNacimiento = fechaNacimiento;
            _direccion = direccion;
            _telefono = telefono;
            _foto = foto;
            _idDepartamento = idDepartamento;
        }
        #endregion
    }
}