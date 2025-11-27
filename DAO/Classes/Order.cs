using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;

namespace DAO.Classes
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public decimal TotalAmount { get; set; }
        public int ClientId { get; set; }
        public Order(DateTime dateOrder, decimal totalAmount, int clientId)
        {
            DateOrder = dateOrder;
            TotalAmount = totalAmount;
            ClientId = clientId;
        }
        public Order(int id, DateTime dateOrder, decimal totalAmount, int clientId)
        {
            Id = id;
            DateOrder = dateOrder;
            TotalAmount = totalAmount;
            ClientId = clientId;
        }
        public override string ToString()
        {
            return $"Order [Id={Id}, DateOrder={DateOrder}, TotalAmount={TotalAmount}, ClientId={ClientId}]";


        }
    }
}
