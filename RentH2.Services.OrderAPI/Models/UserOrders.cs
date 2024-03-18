using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.EntityFrameworkCore;

namespace RentH2.Services.OrderAPI.Models
{
	[BsonIgnoreExtraElements]
	[Collection("UserOrders")]
	public class UserOrders
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		[Display(Name = "Código do Usuário")]
		public string? UserId { get; set; }
		
		[Display(Name = "Pedidos")]
		public List<Order>? Orders { get; set; }
	}
}
