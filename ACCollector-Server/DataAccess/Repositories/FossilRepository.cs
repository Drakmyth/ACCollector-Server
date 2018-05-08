using ACCollector_Server.Models;
using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACCollector_Server.DataAccess.Repositories
{
	public sealed class FossilRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public FossilRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Fossil CreateFossilForGame(Guid gameId, CreateFossilRequest request)
		{
			var entity = new FossilEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<FossilEntity> entry = context.Fossils.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<FossilSummary> GetFossilSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fossils // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(f => f.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public IReadOnlyList<Fossil> GetFossilForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fossils
				.Where(f => f.GameId == gameId)
				.ToList()
				.Select(f => f.ToModel())
				.ToList()
				.AsReadOnly();
		}

		public Fossil GetFossil(Guid fossilId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Fossils
				.Where(f => f.FossilId == fossilId)
				.Single()
				.ToModel();
		}
	}
}