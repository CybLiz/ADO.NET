using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DAO.Classes
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }

        public Client(string nom, string prenom, string email, string telephone, string adresse, string codePostal)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
        }
        public Client(int id, string nom, string prenom, string email, string telephone, string adresse, string codePostal)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
        }

        public override string ToString()
        {
            return $"Client [Id={Id}, Nom={Nom}, Prenom={Prenom}, Email={Email}, Telephone={Telephone}, Adresse={Adresse}, CodePostal={CodePostal}]";
        }

    }
}
