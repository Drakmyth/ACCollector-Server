﻿using ACCollector_Server.Models.Entities;
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
		public DbSet<DeepSeaCreatureEntity> DeepSeaCreatures => Set<DeepSeaCreatureEntity>();
		public DbSet<ArtEntity> Art => Set<ArtEntity>();
		public DbSet<FossilEntity> Fossils => Set<FossilEntity>();
		public DbSet<AvailabilityEntity> Availabilities => Set<AvailabilityEntity>();
		public DbSet<NoteEntity> Notes => Set<NoteEntity>();

		public DbSet<BugAvailabilityEntity> BugAvailabilityMappings => Set<BugAvailabilityEntity>();
		public DbSet<FishAvailabilityEntity> FishAvailabilityMappings => Set<FishAvailabilityEntity>();
		public DbSet<DeepSeaCreatureAvailabilityEntity> DeepSeaCreatureAvailabilityMappings => Set<DeepSeaCreatureAvailabilityEntity>();
		public DbSet<BugNoteEntity> BugNoteMappings => Set<BugNoteEntity>();
		public DbSet<FishNoteEntity> FishNoteMappings => Set<FishNoteEntity>();
		public DbSet<DeepSeaCreatureNoteEntity> DeepSeaCreatureNoteMappings => Set<DeepSeaCreatureNoteEntity>();

		public ACCollectorDbContext(DbContextOptions<ACCollectorDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BugAvailabilityEntity>().HasKey(bae => new {bae.BugId, bae.AvailabilityId});
			modelBuilder.Entity<BugNoteEntity>().HasKey(bne => new {bne.BugId, bne.NoteId});
			modelBuilder.Entity<FishAvailabilityEntity>().HasKey(fae => new {fae.FishId, fae.AvailabilityId});
			modelBuilder.Entity<FishNoteEntity>().HasKey(fne => new {fne.FishId, fne.NoteId});
			modelBuilder.Entity<DeepSeaCreatureAvailabilityEntity>().HasKey(dscae => new {dscae.DeepSeaCreatureId, dscae.AvailabilityId});
			modelBuilder.Entity<DeepSeaCreatureNoteEntity>().HasKey(dscne => new {dscne.DeepSeaCreatureId, dscne.NoteId});
		}
	}
}