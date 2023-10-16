namespace MemoryPersistence;

public class Save_Load_Delete_Exists_Query
{
	[Fact]
	public async Task _()
	{
		var persistence = X.Services.Get<IPersistence>();

		var someDataA = new SomeDataA();
		var someDataB = new SomeDataB();

		Assert.False(persistence.Query<IHasId>().Any());
		Assert.Empty(persistence.Query<SomeDataA>().Where(x => x.Id == someDataA.Id));
		Assert.False(await persistence.ExistsAsync(someDataA));
		await Assert.ThrowsAsync<KeyNotFoundException>(async () => await persistence.LoadAsync<SomeDataA>(someDataA.Id));
		await Assert.ThrowsAsync<KeyNotFoundException>(async () => await persistence.LoadAsync<SomeDataB>(someDataB.Id));

		await persistence.DeleteAsync(someDataA, someDataB);

		await persistence.SaveAsync(someDataA, someDataB);
		Assert.True(persistence.Query<IHasId>().Any());
		Assert.Single(persistence.Query<SomeDataA>().Where(x => x.Id == someDataA.Id));
		Assert.Single(persistence.Query<SomeDataB>().Where(x => x.Id == someDataB.Id));
		Assert.True(await persistence.ExistsAsync(someDataA));
		Assert.True(await persistence.ExistsAsync(someDataB));

		Assert.Equal(someDataA, await persistence.LoadAsync<SomeDataA>(someDataA.Id));
		Assert.Equal(someDataB, await persistence.LoadAsync<SomeDataB>(someDataB.Id));

		await persistence.DeleteAsync(someDataA, someDataB);
		Assert.False(await persistence.ExistsAsync(someDataA));
		Assert.False(await persistence.ExistsAsync(someDataB));
		await Assert.ThrowsAsync<KeyNotFoundException>(async () => await persistence.LoadAsync<SomeDataA>(someDataA.Id));
		await Assert.ThrowsAsync<KeyNotFoundException>(async () => await persistence.LoadAsync<SomeDataB>(someDataB.Id));
	}
}
