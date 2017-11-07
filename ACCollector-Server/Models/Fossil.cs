using System;

namespace ACCollector_Server.Models
{
	public class Fossil
	{
		public Guid FossilId { get; }
		public Guid GameId { get; }
		public string Name { get; }
		public int SalePrice { get; private set; }
		public FossilGroup Group { get; private set; }

		private Fossil(Guid fossilId, Guid gameId, string name)
		{
			FossilId = fossilId;
			GameId = gameId;
			Name = name;
			SalePrice = 0;
			Group = FossilGroup.Standalone;
		}

		private Fossil(Fossil copy) : this(copy.FossilId, copy.GameId, copy.Name)
		{
			SalePrice = copy.SalePrice;
			Group = copy.Group;
		}

		public class Builder : Fossil
		{
			public Builder(Guid fossilId, Guid gameId, string name) : base(fossilId, gameId, name)
			{
			}

			public Builder WithSalePrice(int salePrice)
			{
				SalePrice = salePrice;
				return this;
			}

			public Builder InGroup(FossilGroup group)
			{
				Group = group;
				return this;
			}

			public Fossil Build()
			{
				return new Fossil(this);
			}
		}
	}
}