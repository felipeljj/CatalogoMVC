namespace catalogoMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Em um projeto real, seria melhor usar hashes de senha
        public bool IsAdmin { get; set; }     // Define se o usuário é administrador
    }
}