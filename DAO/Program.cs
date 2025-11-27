using DAO.Dao;
using DAO.Classes;

namespace DAO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientDAO clientDAO = new ClientDAO();
            OrderDAO orderDAO = new OrderDAO();

            bool continuer = true;

            while (continuer)
            {
                AfficherMenu();
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherClients(clientDAO);
                        break;

                    case "2":
                        AjouterClient(clientDAO);
                        break;

                    case "3":
                        ModifierClient(clientDAO);
                        break;

                    case "4":
                        SupprimerClient(clientDAO);
                        break;

                    case "5":
                        AfficherClientDetails(clientDAO);
                        break;

                    case "6":
                        AjouterCommande(orderDAO);
                        break;

                    case "7":
                        ModifierCommande(orderDAO);
                        break;

                    case "8":
                        SupprimerCommande(orderDAO);
                        break;

                    case "0":
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Méthodes client

        private static void AfficherMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Lister les clients");
            Console.WriteLine("2. Ajouter un client");
            Console.WriteLine("3. Modifier un client");
            Console.WriteLine("4. Supprimer un client");
            Console.WriteLine("5. Afficher les détails d'un client");
            Console.WriteLine("6. Ajouter une commande");
            Console.WriteLine("7. Modifier une commande");
            Console.WriteLine("8. Supprimer une commande");
            Console.WriteLine("0. Quitter");
            Console.Write("Choisissez une option: ");
        }

        private static void AfficherClients(ClientDAO clientDAO)
        {
            List<Client> clients = clientDAO.GetAll();
            Console.WriteLine("Liste des clients:");
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        private static void AjouterClient(ClientDAO clientDAO)
        {
            Console.WriteLine("Ajouter un nouveau client:");
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Prénom: ");
            string prenom = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Téléphone: ");
            string telephone = Console.ReadLine();
            Console.Write("Adresse: ");
            string adresse = Console.ReadLine();
            Console.Write("Code Postal: ");
            string codePostal = Console.ReadLine();

            Client nouveauClient = new Client(nom, prenom, email, telephone, adresse, codePostal);
            clientDAO.Save(nouveauClient);
            Console.WriteLine("Client ajouté avec succès!");
        }

        private static void ModifierClient(ClientDAO clientDAO)
        {
            Console.WriteLine("Modifier un client existant:");
            Console.Write("ID du client à modifier: ");
            Console.WriteLine("Laisser vide pour conserver l'actuel");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Client? client = clientDAO.GetById(id);
                if (client != null)
                {
                    Console.Write("Nouveau nom : ");
                    string nom = Console.ReadLine();
                    Console.Write("Nouveau prénom : ");
                    string prenom = Console.ReadLine();
                    Console.Write("Nouvel email : ");
                    string email = Console.ReadLine();
                    Console.Write("Nouveau téléphone : ");
                    string telephone = Console.ReadLine();
                    Console.Write("Nouvelle adresse : ");
                    string adresse = Console.ReadLine();
                    Console.Write("Nouveau code postal : ");
                    string codePostal = Console.ReadLine();

                    if (!string.IsNullOrEmpty(nom)) client.Nom = nom;
                    if (!string.IsNullOrEmpty(prenom)) client.Prenom = prenom;
                    if (!string.IsNullOrEmpty(email)) client.Email = email;
                    if (!string.IsNullOrEmpty(telephone)) client.Telephone = telephone;
                    if (!string.IsNullOrEmpty(adresse)) client.Adresse = adresse;
                    if (!string.IsNullOrEmpty(codePostal)) client.CodePostal = codePostal;

                    clientDAO.Update(client);
                    Console.WriteLine("Client modifié avec succès!");
                }
                else
                {
                    Console.WriteLine("Client non trouvé.");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
        }

        private static void SupprimerClient(ClientDAO clientDAO)
        {
            Console.WriteLine("Supprimer un client:");
            Console.Write("ID du client à supprimer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                clientDAO.DeleteById(id);
                Console.WriteLine("Client supprimé avec succès!");
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }

        }

        public static void AfficherClientDetails(ClientDAO clientDAO)
        {
            Console.WriteLine("Afficher les détails d'un client :");
            Console.Write("ID du client à afficher : ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Client? client = clientDAO.GetById(id);

                if (client != null)
                {
                    Console.WriteLine("\n--- Détails du client ---");
                    Console.WriteLine($"ID        : {client.Id}");
                    Console.WriteLine($"Nom       : {client.Nom}");
                    Console.WriteLine($"Prénom    : {client.Prenom}");
                    Console.WriteLine($"Email     : {client.Email}");
                    Console.WriteLine($"Téléphone : {client.Telephone}");
                    Console.WriteLine($"Adresse   : {client.Adresse}");
                    Console.WriteLine($"CodePostal: {client.CodePostal}");
                }
                else
                {
                    Console.WriteLine("Aucun client trouvé avec cet ID.");
                }
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }
        }

        //Order methods

        public static void AjouterCommande(OrderDAO orderDAO)
        {
            Console.WriteLine("Ajouter une commande a un client:");
            Console.Write("ID du client : ");
            if (int.TryParse(Console.ReadLine(), out int clientId))
            {
                Console.Write("Date de la commande (yyyy-MM-dd) : ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOrder))
                {
                    Console.Write("Montant total : ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal totalAmount))
                    {
                        Order newOrder = new Order(dateOrder, totalAmount, clientId);
                        orderDAO.Save(newOrder);
                        Console.WriteLine("Commande ajoutée avec succès !");
                    }
                    else
                    {
                        Console.WriteLine("Montant total invalide.");
                    }
                }
                else
                {
                    Console.WriteLine("Date invalide.");
                }
            }
            else
            {
                Console.WriteLine("ID client invalide.");
            }

        }

        public static void SupprimerCommande(OrderDAO orderDAO)
        {
            Console.WriteLine("Supprimer une commande:");
            Console.Write("ID de la commande à supprimer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                orderDAO.DeleteById(id);
                Console.WriteLine("Commande supprimée avec succès!");
            }
            else
            {
                Console.WriteLine("ID invalide.");
            }

        }

        public static void ModifierCommande(OrderDAO orderDAO)
        {
               Console.WriteLine("Modifier une commande:");
               Console.Write("ID de la commande à modifier: ");

               if (int.TryParse(Console.ReadLine(), out int id))
                {
                      Order? order = orderDAO.GetById(id);
                     if (order != null)
                     {
                        Console.Write("Nouveau montant : ");
                        string montantStr = Console.ReadLine();
                    if (decimal.TryParse(montantStr, out decimal montant))
                        order.TotalAmount = montant;

                         Console.Write("Nouvelle date yyyy-MM-dd : ");
                         string dateStr = Console.ReadLine();
                    if (DateTime.TryParse(dateStr, out DateTime date))
                        order.DateOrder = date;

                    Console.Write("Nouvel ID client : ");
                    string clientIdStr = Console.ReadLine();
                    if (int.TryParse(clientIdStr, out int clientId))
                        order.ClientId = clientId;

                    orderDAO.Update(order);

                    Console.WriteLine("\nCommande mise à jour avec succès !");

                     }

               }

        }
    }

}
