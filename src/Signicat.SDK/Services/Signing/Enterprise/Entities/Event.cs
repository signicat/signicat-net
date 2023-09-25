using System;

namespace Signicat.Services.Signing.Enterprise.Entities
{
    public class Event
    {
        public EventType EventType { get; set; }
        
        public DateTime? EventTime { get; set; }

        public string Data { get; set; }
    }

    public enum EventType
    {
        TASK_CREATED, 
        NOTIFICATION_SENT, 
        TASK_STARTED, 
        TASK_REJECTED, 
        TASK_COMPLETED, 
        ERROR, 
        DOCUMENT_UPLOADED, 
        DOCUMENT_SIGNED,
        DOCUMENT_VIEWED,
        DOCUMENT_SIGN_CANCELLED, 
        DOCUMENT_DELETED, 
        USER_AUTHENTICATED, 
        USER_AUTHENTICATION_CANCELLED, 
        PACKAGING_TASK_CREATED,
        PACKAGING_TASK_COMPLETED, 
        PACKAGING_TASK_FAILED, 
        INTERNAL
    }
}