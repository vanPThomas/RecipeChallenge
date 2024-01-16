using Persistence.DatalayerModel;

ChallengeContext ctx = new ChallengeContext();
ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();
