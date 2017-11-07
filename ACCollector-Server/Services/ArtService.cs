using ACCollector_Server.DataAccess.Repositories;
using ACCollector_Server.Models;
using ACCollector_Server.Models.Requests;
using EntityFramework.DbContextScope.Interfaces;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ACCollector_Server.Services
{
	[UsedImplicitly]
	public class ArtService
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly ArtRepository _artRepository;

		public ArtService(IDbContextScopeFactory dbContextScopeFactory, ArtRepository artRepository)
		{
			_dbContextScopeFactory = dbContextScopeFactory;
			_artRepository = artRepository;
		}

		public IReadOnlyList<ArtSummary> GetArtSummaries()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _artRepository.GetArtSummaries();
			}
		}

		public Art CreateArtForGame(Guid gameId, CreateArtRequest request)
		{
			using (IDbContextScope scope = _dbContextScopeFactory.Create())
			{
				Art art = _artRepository.CreateArtForGame(gameId, request);
				scope.SaveChanges();
				return art;
			}
		}

		public IReadOnlyList<Art> GetArtForGame(Guid gameId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _artRepository.GetArtForGame(gameId);
			}
		}

		public Art GetArt(Guid artId)
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _artRepository.GetArt(artId);
			}
		}
	}
}