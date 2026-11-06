using djaramilloS5.Models;
using SQLite;

namespace djaramilloS5.Repositories
{
    public class PersonRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection? _conn;

        public string StatusMessage { get; set; } = string.Empty;

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private SQLiteConnection Init()
        {
            if (_conn is not null)
                return _conn;

            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Persona>();
            return _conn;
        }

        //INSERT
        public void AddNewPerson(string name)
        {
            StatusMessage = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("El nombre es requerido");

                Init().Insert(new Persona { Name = name.Trim() });
                StatusMessage = "Dato ingresado";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        //SELECT
        public List<Persona> GetAllPerson()
        {
            StatusMessage = string.Empty;
            try
            {
                return Init().Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return new List<Persona>();
        }

        //DELETE
        public void DeletePerson(int id)
        {
            StatusMessage = string.Empty;
            try
            {
                int result = Init().Delete<Persona>(id);
                StatusMessage = result > 0 ? "Dato eliminado" : "No se encontró el registro";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
