using System;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.Infrastructure;

namespace Signicat.SDK.Tests;

[TestFixture]
public class MapperTests
{
    [Test]
    public void MapFromJson_ValidJson_ReturnsMappedObject()
    {
        // Arrange
        var json = "{\"name\":\"John\",\"age\":30}";
        
        // Act
        var result = Mapper.MapFromJson<Person>(json);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("John", result.Name);
        Assert.AreEqual(30, result.Age);
    }
    
    [Test]
    public void MapFromJson_InvalidJson_ReturnsDefault()
    {
        // Arrange
        var json = "invalid json";
        
        // Act
        var result = Mapper.MapFromJson<Person>(json);
        
        // Assert
        Assert.AreEqual(default(Person), result);
    }
    
    [Test]
    public void MapToJson_ValidObject_ReturnsJsonString()
    {
        // Arrange
        var person = new Person { Name = "John", Age = 30 };
        
        // Act
        var result = Mapper.MapToJson(person);
        
        // Assert
        var expectedJson = "{\"name\":\"John\",\"age\":30}";
        Assert.AreEqual(expectedJson, result);
    }
    
    [Test]
    public void MapFromJson_SignicatResponse_ReturnsMappedObject()
    {
        // Arrange
        var response = new SignicatResponse { ResponseJson = "{\"name\":\"John\",\"age\":30}" };
        
        // Act
        var result = Mapper.MapFromJson<Person>(response);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("John", result.Name);
        Assert.AreEqual(30, result.Age);
    }

    [Test]
    public void MapToJson_DemRecordSearchQueryCondition_EnumValue()
    {
        var query = new DemRecordSearchQueryCondition()
        {
            Field = "key",
            Operator = DemRecordSearchQueryOperator.Equal,
            Value = "value"
        };

        var json = Mapper.MapToJson(query);

        Console.WriteLine(json);
        
        Assert.AreEqual("{\"field\":\"key\",\"operator\":\"eq\",\"value\":\"value\"}",json);
    }

    [Test]
    public void MapEnterpriseDateTime()
    {
        var json = @"{""date"":""2023-10-01T20:55:57+0200""}";
        DateTime.TryParse("2023-10-01T20:55:57+0200", out DateTime newDate);
        Console.WriteLine(newDate);
        var value = Mapper.MapFromJson<ClassWithDateTime>(json);
        
        Assert.IsNotNull(value.Date);
        Assert.That(value.Date, Is.Not.EqualTo(DateTime.MinValue));
        Console.WriteLine(value.Date);
        Console.WriteLine(value.Date.Value.Kind);
    }
    
    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    private class ClassWithDateTime
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date { get; set; }
    }
    
}