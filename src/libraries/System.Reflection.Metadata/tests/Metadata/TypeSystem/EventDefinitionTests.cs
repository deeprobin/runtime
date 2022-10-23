// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Reflection.Metadata.Tests.Metadata.TypeSystem
{
    public sealed class EventDefinitionTests
    {
        [Fact]
        public void TestGetDeclaringType()
        {
            var reader = MetadataReaderTests.GetMetadataReader(Misc.Members);
            foreach (var typeDefinitionHandle in reader.TypeDefinitions)
            {
                var typeDefinition = reader.GetTypeDefinition(typeDefinitionHandle);
                Assert.All(typeDefinition.GetEvents(), eventDefinitionHandle =>
                {
                    var eventDefinition = reader.GetEventDefinition(eventDefinitionHandle);
                    Assert.Equal(typeDefinitionHandle, eventDefinition.GetDeclaringType());
                });
            }
        }
    }
}
