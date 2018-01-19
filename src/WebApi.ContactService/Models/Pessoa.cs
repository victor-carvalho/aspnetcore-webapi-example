using System;
using System.Collections.Generic;

namespace WebApi.ContactService.Models
{
    public class Pessoa
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}