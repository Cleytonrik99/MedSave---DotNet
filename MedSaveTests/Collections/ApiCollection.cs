using MedSaveTests.Fixtures;
using Xunit;

namespace MedSaveTests.Collections;

[CollectionDefinition("Api collection")]
public class ApiCollection : ICollectionFixture<ApiFactoryFixture>
{
}