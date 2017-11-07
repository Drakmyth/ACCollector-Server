using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ACCollector_Server.Models.Requests
{
	public class CreateFossilRequest
	{
		[Required]
		public string Name { get; }

		[Required]
		public int SalePrice { get; }

		[Required]
		public FossilGroup Group { get; }

		[JsonConstructor]
		public CreateFossilRequest(string name, int salePrice, FossilGroup group)
		{
			Name = name;
			SalePrice = salePrice;
			Group = group;
		}
	}
}