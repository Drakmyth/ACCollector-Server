using ACCollector_Server.Models.Entities;
using ACCollector_Server.Models.Entities.Mapping;
using EntityFramework.DbContextScope.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACCollector_Server.DataAccess
{
	public class ACCollectorDbContext : DbContext, IDbContext
	{
		public DbSet<GameEntity> Games => Set<GameEntity>();
		public DbSet<ReleaseEntity> Releases => Set<ReleaseEntity>();
		public DbSet<BugEntity> Bugs => Set<BugEntity>();
		public DbSet<FishEntity> Fish => Set<FishEntity>();
		public DbSet<AvailabilityEntity> Availabilities => Set<AvailabilityEntity>();
		public DbSet<NoteEntity> Notes => Set<NoteEntity>();

		public DbSet<BugAvailabilityEntity> BugAvailabilityMappings => Set<BugAvailabilityEntity>();
		public DbSet<FishAvailabilityEntity> FishAvailabilityMappings => Set<FishAvailabilityEntity>();
		public DbSet<BugNoteEntity> BugNoteMappings => Set<BugNoteEntity>();
		public DbSet<FishNoteEntity> FishNoteMappings => Set<FishNoteEntity>();

		public ACCollectorDbContext(DbContextOptions<ACCollectorDbContext> options) : base(options)
		{
		}
	}
}