using System;
using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Enterprise.Entities
{
    public class PackagingTaskStatusInfo
    {
        [JsonPropertyName("orderId")] public string OrderId { get; set; }

        [JsonPropertyName("packagingTaskId")] public Guid PackagingTaskId { get; set; }

        [JsonPropertyName("packagingTaskStatus")]
        public string PackagingTaskStatus { get; set; }

        [JsonPropertyName("packagingTaskResultUri")]
        public string PackagingTaskResultUri { get; set; }
    }

    public enum PackagingTaskStatus
    {
        CREATED,
        COMPLETED,
        FAILED
    }
}