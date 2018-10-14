using System;
using Realms;

namespace RealmExample.Model
{
    public class Cliente : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }
    }
}
