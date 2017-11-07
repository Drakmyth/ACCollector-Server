using ACCollector_Server.Models.Requests;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACCollector_Server.Models.Entities
{
	[Table("Art", Schema = "dbo")]
	public class ArtEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ArtId { get; set; }

		[Required]
		public Guid GameId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int SalePrice { get; set; }

		[Required]
		public int PurchasePrice { get; set; }

		[Required]
		[Column(nameof(Type))]
		public string TypeString { get; set; }

		[NotMapped]
		public ArtType Type
		{
			get => ArtTypeExtensions.Lookup(TypeString);
			set => TypeString = value.GetArtType();
		}

		[Required]
		[Column(nameof(Source))]
		public string SourceString { get; set; }

		[NotMapped]
		public ArtSource Source
		{
			get => ArtSourceExtensions.Lookup(SourceString);
			set => SourceString = value.GetArtSource();
		}

		private ArtEntity()
		{
			// EF Constructor
		}

		public ArtEntity(Guid gameId, CreateArtRequest request)
		{
			ArtId = Guid.Empty;
			GameId = gameId;
			Name = request.Name;
			SalePrice = request.SalePrice;
			PurchasePrice = request.PurchasePrice;
			Type = request.Type;
			Source = request.Source;
		}

		public Art ToModel()
		{
			var builder = new Art.Builder(ArtId, GameId, Name)
				.WithSalePrice(SalePrice)
				.WithPurchasePrice(PurchasePrice)
				.AsType(Type)
				.FromSource(Source);

			return builder.Build();
		}

		public ArtSummary ToSummary()
		{
			return new ArtSummary(ArtId, Name, Type);
		}
	}
}