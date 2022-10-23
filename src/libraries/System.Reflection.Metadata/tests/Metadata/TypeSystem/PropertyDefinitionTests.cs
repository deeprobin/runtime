// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Reflection.Metadata.Tests.Metadata.TypeSystem
{
    public sealed class PropertyDefinitionTests
    {
        [Fact]
        public void TestGetDeclaringType()
        {
            var reader = MetadataReaderTests.GetMetadataReader(Misc.Members);
            foreach (var typeDefinitionHandle in reader.TypeDefinitions)
            {
                var typeDefinition = reader.GetTypeDefinition(typeDefinitionHandle);
                Assert.All(typeDefinition.GetProperties(), propertyDefinitionHandle =>
                {
                    var propertyDefinition = reader.GetPropertyDefinition(propertyDefinitionHandle);
                    Assert.Equal(typeDefinitionHandle, propertyDefinition.GetDeclaringType());
                });
            }
        }
    }
}
