using ACCollector_Server.Models.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Fossil", Schema = "dbo")]
	public class FossilEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid FossilId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int SalePrice { get; set; }

		[Required]
		[Column(nameof(Group))]
		public string GroupString { get; set; }

		[NotMapped]
		public FossilGroup Group
		{
			get => FossilGroupExtensions.Lookup(GroupString);
			set => GroupString = value.GetGroup();
		}

		private FossilEntity()
		{
			// EF Constructor
		}

		public FossilEntity(Guid gameId, CreateFossilRequest request)
		{
			FossilId = Guid.Empty;
			GameId = gameId;
			Name = request.Name;
			SalePrice = request.SalePrice;
			Group = request.Group;
		}

		public Fossil ToModel()
		{
			var builder = new Fossil.Builder(FossilId, GameId, Name)
				.WithSalePrice(SalePrice)
				.InGroup(Group);

			return builder.Build();
		}

		public FossilSummary ToSummary()
		{
			return new FossilSummary(FossilId, Name, Group);
		}
	}
}