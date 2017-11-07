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
	[UsedImplicitly]
	public sealed class ArtRepository
	{
		private readonly IAmbientDbContextLocator _contextLocator;

		public ArtRepository(IAmbientDbContextLocator contextLocator)
		{
			_contextLocator = contextLocator;
		}

		public Art CreateArtForGame(Guid gameId, CreateArtRequest request)
		{
			var entity = new ArtEntity(gameId, request);
			var context = _contextLocator.Get<ACCollectorDbContext>();
			EntityEntry<ArtEntity> entry = context.Art.Add(entity);
			return entry.Entity.ToModel();
		}

		public IReadOnlyList<ArtSummary> GetArtSummaries()
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Art // TODO: Consider making Summaries a DB view
				.ToList()
				.Select(b => b.ToSummary())
				.ToList()
				.AsReadOnly();
		}

		public IReadOnlyList<Art> GetArtForGame(Guid gameId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Art
				.Where(b => b.GameId == gameId)
				.ToList()
				.Select(b => b.ToModel())
				.ToList()
				.AsReadOnly();
		}

		public Art GetArt(Guid bugId)
		{
			var context = _contextLocator.Get<ACCollectorDbContext>();
			return context.Art
				.Where(b => b.ArtId == bugId)
				.Single()
				.ToModel();
		}
	}
}