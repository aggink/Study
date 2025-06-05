using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.UnitTests.SuperSalad007.DtoModels
{
    public sealed record ResponseDto
    {
        [JsonPropertyName("message")]
        public string Message { get; init; }
    }
}
