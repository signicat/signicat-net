using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Enterprise.Entities
{
    public class SigningOrder : SigningOrderCreateOptions
    {
        public string Id { get; set; }
        
        public string Artifact { get; set; }
    }
    
    public  class SigningOrderCreateOptions
    {
        public Guid ClientReference { get; set; }

        public List<SignatureTask> Tasks { get; set; }

        public List<SigningOrderNotification> Notifications { get; set; }
        
        public long DaysUntilDeletion { get; set; }
        
        public List<PackagingTask> PackagingTasks { get; set; }
    }

    public  class SigningOrderNotification
    {
        public Guid Id { get; set; }

        public string Recipient { get; set; }
        
        public string Sender { get; set; }

        public string Header { get; set; }
        
        public string Message { get; set; }
        
        public TaskType Type { get; set; }

    }

    public class TaskNotification
    {
        public Guid Id { get; set; }
        
        public string Recipient { get; set; }

        public string Sender { get; set; }

        public string Header { get; set; }

        public string Message { get; set; }

        public TaskType Type { get; set; }

        [JsonPropertyName ("schedule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<TaskNotificationSchedule> Schedule { get; set; }
    }
    
    public class TaskForwardDetails
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("taskId")]
        public Guid TaskId { get; set; }
        
        [JsonPropertyName("originalTaskId")]
        public Guid OriginalTaskId { get; set; }

        [JsonPropertyName("forwarderName")]
        public string ForwarderName { get; set; }

        [JsonPropertyName("forwarderEmail")]
        public string ForwarderEmail { get; set; }
        
        [JsonPropertyName("recipientName")]
        public string RecipientName { get; set; }

        [JsonPropertyName("recipientEmail")]
        public string RecipientEmail { get; set; }

        [JsonPropertyName("recipientMobile")]
        public string RecipientMobile { get; set; }
    }

    public class PackagingTaskNotification
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }

        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        [JsonPropertyName("header")]
        public string Header { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("type")]
        public TaskType Type { get; set; }

        [JsonPropertyName("schedule")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<PackagingTaskSchedule> Schedule { get; set; }
    }

    public enum TaskType {
        SMS,
        EMAIL,
        URL
    }

    public class TaskNotificationSchedule
    {
        [JsonPropertyName("triggerStatus")]
        public TriggerStatus TriggerStatus { get; set; }

        [JsonPropertyName("delay")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Delay Delay { get; set; }
    }

    public  class PackagingTaskSchedule
    {
        [JsonPropertyName("triggerStatus")]
        public PackagingTaskScheduleTriggerStatus TriggerStatus { get; set; }


    }

    public enum PackagingTaskScheduleTriggerStatus
    {
        CREATED, COMPLETED
    }

    public enum TriggerStatus {
        CREATED, COMPLETED, REJECTED, EXPIRED, FORWARDED, STARTED
    }

    public  class Delay
    {
        [JsonPropertyName("minutes")]
        public long? Minutes { get; set; }

        [JsonPropertyName("hours")]
        public long? Hours { get; set; }

        [JsonPropertyName("days")]
        public long? Days { get; set; }
    }

    public  class PackagingTask
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("sendToArchive")]
        public bool SendToArchive { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("notifications")]
        public List<PackagingTaskNotification> Notifications { get; set; }

        [JsonPropertyName("documents")]
        public List<PackagingTaskDocument> Documents { get; set; }
    }


    public  class PackagingTaskDocument
    {
        [JsonPropertyName("taskId")]
        public Guid TaskId { get; set; }

        [JsonPropertyName("documentIds")]
        public List<string> DocumentIds { get; set; }
    }

    public class SignatureTask
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("daysToLive")]
        public long DaysToLive { get; set; }

        [JsonPropertyName("configuration")] 
        public string Configuration { get; set; }

        [JsonPropertyName("documents")]
        public List<TaskDocument> Documents { get; set; }

        [JsonPropertyName("signatureMethods")]
        public List<SignatureMethod> SignatureMethods { get; set; }

        [JsonPropertyName("authentication")]
        public Authentication Authentication { get; set; }

        [JsonPropertyName("onTaskPostpone")]
        public string OnTaskPostpone { get; set; }

        [JsonPropertyName("onTaskComplete")]
        public string OnTaskComplete { get; set; }

        [JsonPropertyName("onTaskReject")]
        public string OnTaskReject { get; set; }

        [JsonPropertyName("dialog")]
        public Dialog Dialog { get; set; }

        [JsonPropertyName("notifications")]
        public List<TaskNotification> Notifications { get; set; }

        [JsonPropertyName("signText")]
        public string SignText { get; set; }

        [JsonPropertyName("signingUrl")]
        public string SigningUrl { get; set; }

        [JsonPropertyName("subject")]
        public Subject Subject { get; set; }

        [JsonPropertyName("dependsOnTasks")]
        public IEnumerable<string> DependsOnTasks { get; set; }
    }

    public  class Authentication
    {
        [JsonPropertyName("methods")]
        public List<string> Methods { get; set; }

        [JsonPropertyName("artifact")]
        public bool Artifact { get; set; }
    }

    public  class Dialog
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public  class TaskDocument
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("action")]
        public DocumentAction Action { get; set; }

        [JsonPropertyName("source")]
        public DocumentSource Source { get; set; }

        [JsonPropertyName("documentRef")]
        public string DocumentRef { get; set; }

        [JsonPropertyName("externalReference")]
        public Guid ExternalReference { get; set; }

        [JsonPropertyName("signTextEntry")]
        public string SignTextEntry { get; set; }

        [JsonPropertyName("sendResultToArchive")]
        public bool SendResultToArchive { get; set; }

        [JsonPropertyName("form")]
        public Form Form { get; set; }
    }

    public enum DocumentSource {
        SESSION,
        UPLOAD,
    }

    public enum DocumentAction {
        SIGN,
        VIEW,
        UPLOAD
    }

    public  class Form
    {
        [JsonPropertyName("interactive")]
        public bool Interactive { get; set; }

        [JsonPropertyName("inputParams")]
        public List<InputParam> InputParams { get; set; }
    }

    public  class InputParam
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class SignatureMethod
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public SignatureMethodType? Type { get; set; }

        [JsonPropertyName("handwritten")]
        public bool Handwritten { get; set; }
    }

    public enum SignatureMethodType
    {
        AUTHENTICATION_BASED, SIGNED_STATEMENT, THIRD_PARTY
    }



    public class TaskStatusInfo
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("taskId")]
        public Guid TaskId { get; set; }

        [JsonPropertyName("taskStatus")]
        public TaskStatus TaskStatus { get; set; }

        [JsonPropertyName("clientReference")]
        public Guid ClientReference { get; set; }

        [JsonPropertyName("clientStatus")]
        public Guid ClientStatus { get; set; }

        [JsonPropertyName("documents")]
        public Document[] Documents { get; set; }
    }

    public enum TaskStatus
    {
        CREATED, COMPLETED, REJECTED, EXPIRED, DELETED
    }

    public  class Document
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("originalUri")]
        public Uri OriginalUri { get; set; }

        [JsonPropertyName("generatedUri")]
        public Uri GeneratedUri { get; set; }

        [JsonPropertyName("resultUri")]
        public Uri ResultUri { get; set; }

        [JsonPropertyName("formOutputParam")]
        public FormOutputParam[] FormOutputParam { get; set; }
    }

    public  class FormOutputParam
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
