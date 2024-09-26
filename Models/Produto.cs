namespace catalogoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int estoque { get; set; }
    }
}
