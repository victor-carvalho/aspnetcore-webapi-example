using System;
using Newtonsoft.Json;

namespace WebApi.ContactService.Models
{
    public class Endereco
    {
        public Guid ID { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid PessoaID { get; set; }
        
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
    }
}