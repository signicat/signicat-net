using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.SDK.Tests.Helpers;
using Signicat.Services.Signing.Enterprise;
using Signicat.Services.Signing.Enterprise.Entities;


namespace Signicat.SDK.Tests.Signing;

public class EnterpriseSigningTestSignatureEndpoints : BaseTest
{
    private IEnterpriseSignatureService _service;
    private Guid taskId, packagingTaskId;
    private byte[] fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
    private List<TaskDocument> documents;
    private SigningOrderCreateOptions validSignRequest;
    private HashSet<string> documentIds = new HashSet<string>(), signOrderIds = new HashSet<string>();

    [SetUp]
    public void Setup()
    {
        _service = new EnterpriseSignatureService();
        taskId = Guid.NewGuid();
        packagingTaskId = Guid.NewGuid();

        Console.WriteLine("TaskId: {0}", taskId);
        Console.WriteLine("PackagingTaskId: {0}", packagingTaskId);

        documents = new List<TaskDocument>()
        {
            new TaskDocument()
            {
                Action = DocumentAction.SIGN,
                Description = "Document description: Nice document to sign",
                Source = DocumentSource.SESSION,
                ExternalReference = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                SendResultToArchive = true,

            }
        };

        Console.WriteLine("DocumentId: {0}", documents[0].Id);

        validSignRequest = new SigningOrderCreateOptions()
        {
            ClientReference = Guid.NewGuid(),
            DaysUntilDeletion = 1,

            Tasks = new List<SignatureTask>()
            {
                new SignatureTask()
                {
                    Id = taskId,
                    SignatureMethods = new List<SignatureMethod>()
                    {
                        new SignatureMethod()
                        {
                            Handwritten = true
                        },

                    },
                    Authentication = new Signicat.Services.Signing.Enterprise.Entities.Authentication()
                    {
                        Methods =
                        [
                            "scid-sms"
                        ],

                    },
                    Language = "en",
                    Documents = documents,
                    DaysToLive = 1,
                    OnTaskComplete = "http://www.vg.no#success",
                    OnTaskReject = "http://www.vg.no#reject",
                    OnTaskPostpone = "http://www.vg.no#postpone",
                    Notifications = new List<TaskNotification>()
                    {
                        new TaskNotification()
                        {
                            Header = "Documents to be signed",
                            Id = Guid.NewGuid(),
                            Message = "Please sign this document: ${taskUrl}",
                            Recipient = "test@signicat.com",
                            Schedule = new List<TaskNotificationSchedule>()
                            {
                                new TaskNotificationSchedule()
                                {
                                    TriggerStatus = TriggerStatus.CREATED,
                                }
                            },
                            Type = TaskType.EMAIL,
                            Sender = "noreply@signicat.com",
                        },
                    }
                },
            },
            PackagingTasks = new List<PackagingTask>()
            {
                new PackagingTask()
                {
                    Id = packagingTaskId,
                    Method = "pades",
                    Documents = new List<PackagingTaskDocument>()
                    {
                        new PackagingTaskDocument()
                        {
                            TaskId = taskId,
                            DocumentIds = new List<string>()
                            {
                                documents[0].Id.ToString()
                            },
                        },
                    },
                    Notifications = new List<PackagingTaskNotification>()
                    {
                        new PackagingTaskNotification()
                        {
                            Id = Guid.NewGuid(),
                            Recipient = "https://enl5nk9b44bj.x.pipedream.net",
                            Type = TaskType.URL,
                            Message = "test"
                        }
                    }
                }
            }
        };
    }

    [Test]
    public void TestCreateSigninOrderSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;


        var response = _service.Create(validSignRequest);
        Assert.That(response.Id, Is.Not.Empty);
        signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);

    }

    [Test]
    public async Task TestCreateSigninOrderSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;

        var response = await _service.CreateAsync(validSignRequest);

        Assert.That(response.Id, Is.Not.Empty);
        signOrderIds.Add(response.Id);
    }

    [Test]
    public void TestGetTaskStatusSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;


        var response = _service.Create(validSignRequest);

        Assert.That(response.Id, Is.Not.Null);
        signOrderIds.Add(response.Id);
        Console.WriteLine(response.Id);
        var taskResponseInfo = _service.GetTaskStatus(response.Id, taskId);

        Assert.That(taskResponseInfo, Is.Not.Null);

        Assert.That(taskResponseInfo.TaskId, Is.EqualTo(taskId));

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(taskResponseInfo));

    }

    [Test]
    public async Task TestGetTaskStatusSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;


        var response = await _service.CreateAsync(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);
        var taskResponseInfo = await _service.GetTaskStatusAsync(response.Id, taskId);

        Assert.That(taskResponseInfo, Is.Not.Null);

        Assert.That(taskResponseInfo.TaskId, Is.EqualTo(taskId));

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(taskResponseInfo));

    }

    [Test]
    public void TestGetGetOrderSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;

        Console.WriteLine(taskId);
        var response = _service.Create(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);
        var order = _service.GetOrder(response.Id);

        Assert.That(order, Is.Not.Null);

        Assert.That(order.Id, Is.EqualTo(response.Id));
        Assert.That(order.Tasks.First().Id, Is.EqualTo(validSignRequest.Tasks.First().Id));
    }

    [Test]
    public async Task TestGetGetOrderSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;


        var response = await _service.CreateAsync(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        signOrderIds.Add(response.Id);
        Console.WriteLine(response.Id);
        
        var order = await _service.GetOrderAsync(response.Id);

        Assert.That(order, Is.Not.Null);

        Assert.That(order.Id, Is.EqualTo(response.Id));
        Assert.That(order.Tasks.First().Id, Is.EqualTo(validSignRequest.Tasks.First().Id));

    }


    [Test]
    public void TestGetTaskEventsSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;

        Console.WriteLine(taskId);
        var response = _service.Create(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        signOrderIds.Add(response.Id);
        
        
        var taskEvents = _service.GetTaskEvents(response.Id, taskId);
        Assert.That(taskEvents, Is.Not.Null);
        Assert.That(2, Is.EqualTo(taskEvents.Count()));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(taskEvents));
    }



    [Test]
    public async Task TestGetTaskEventsSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
        Assert.That(documentId, Is.Not.Null);
        documentIds.Add(documentId.DocumentId);
        documents.First().DocumentRef = documentId.DocumentId;
        
        var response = await _service.CreateAsync(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        Console.WriteLine(response.Id);
        signOrderIds.Add(response.Id);
        
        var taskEvents = await _service.GetTaskEventsAsync(response.Id, taskId);
        Assert.That(taskEvents, Is.Not.Null);
        Assert.That(2, Is.EqualTo(taskEvents.Count()));

    }

    [Test]
    public void TestDeleterSignOrderSuccess()
    {

        var document = _service.UploadSessionDocument("dummy.pdf", fileData);
        Assert.That(document, Is.Not.Null);
        documentIds.Add(document.DocumentId);
        documents.First().DocumentRef = document.DocumentId;

        Console.WriteLine(taskId);
        var response = _service.Create(validSignRequest);
        Assert.That(response.Id, Is.Not.Null);
        _service.DeleteSignOrder(response.Id);


    }

    [Test]
    public async Task TestDeleteSignOrderSuccessAsync()
    {

        var document = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
        Assert.That(document, Is.Not.Null);
        documentIds.Add(document.DocumentId);
        documents.First().DocumentRef = document.DocumentId;


        var response = await _service.CreateAsync(validSignRequest);

        Assert.That(response.Id, Is.Not.Null);
        await _service.DeleteSignOrderAsync(response.Id);

    }
    

    [Test]
    public void TestCreateSigningOrderInvalidMapErrorCorrect()
    {
        var ex = Assert.ThrowsAsync<SignicatException>(async () =>
        {
            var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);
            documents.First().DocumentRef = documentId.DocumentId;
            documentIds.Add(documentId.DocumentId);

            var response = await _service.CreateAsync(new SigningOrderCreateOptions()
            {
                ClientReference = Guid.NewGuid(),
                DaysUntilDeletion = 1,

                Tasks = new List<SignatureTask>()
                {
                    new SignatureTask()
                    {
                        Id = taskId,
                        SignatureMethods = new List<SignatureMethod>()
                        {
                            new SignatureMethod()
                            {
                                Handwritten = true
                            },

                        },
                        Authentication = new Signicat.Services.Signing.Enterprise.Entities.Authentication()
                        {
                            Methods = new List<string>()
                            {
                                "scid-sms",
                            },

                        },
                        Subject = new Subject()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Attributes = new List<Signicat.Services.Signing.Enterprise.Entities.Attribute>()
                            {
                                new Signicat.Services.Signing.Enterprise.Entities.Attribute()
                                {
                                    Name = "Bruce Wayne"
                                }
                            }
                        },
                        Language = "nb",
                        Documents = documents,
                        DaysToLive = 1,
                        OnTaskComplete = "http://www.vg.no#success",
                        OnTaskReject = "http://www.vg.no#reject",
                        OnTaskPostpone = "http://www.vg.no#postpone",
                        Notifications = new List<TaskNotification>()
                        {
                            new TaskNotification()
                            {
                                Header = "Documents to be signed",
                                Id = Guid.NewGuid(),
                                Message = "Please sign this document: ${taskUrl}",
                                Recipient = "test@signicat.com",
                                Schedule = new List<TaskNotificationSchedule>()
                                {
                                    new TaskNotificationSchedule()
                                    {
                                        TriggerStatus = TriggerStatus.CREATED,
                                    }
                                },
                                Type = TaskType.EMAIL,
                                Sender = "noreply@signicat.com",
                            },
                        }
                    },
                },
                PackagingTasks = new List<PackagingTask>()
                {
                    new PackagingTask()
                    {
                        Id = packagingTaskId,
                        Method = "pades",
                        Documents = new List<PackagingTaskDocument>()
                        {
                            new PackagingTaskDocument()
                            {
                                TaskId = taskId,
                                DocumentIds = new List<string>()
                                {
                                    documents[0].Id.ToString()
                                },
                            },
                        },
                        Notifications = new List<PackagingTaskNotification>()
                        {
                            new PackagingTaskNotification()
                            {
                                Id = Guid.NewGuid(),
                                Recipient = "https://enl5nk9b44bj.x.pipedream.net",
                                Type = TaskType.URL,
                                Message = "test"
                            }
                        }
                    }
                }
            });

        });

        Assert.That(ex.Error, Is.Not.Null);
        Assert.That(ex.Error.ValidationErrors, Is.Not.Empty);
        Assert.That(ex.HttpStatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        Assert.That(ex.Error.ValidationErrors.First().PropertyName, Is.EqualTo("tasks[0].subject.attributes[0].value"));
        Assert.That(ex.Error.ValidationErrors.First().Reason, Is.EqualTo("Subject attribute value is required"));

        foreach (ValidationError validationError in ex.Error.ValidationErrors)
        {
            Console.WriteLine($"{validationError.PropertyName}:{validationError.Reason}");
        }

    }

    [OneTimeTearDown]
    public async Task Cleanup()
    {
        List<Task> tasks = documentIds.Select(documentId => _service.DeleteDocumentAsync(documentId)).ToList();
        tasks.AddRange(signOrderIds.Select(orderId => _service.DeleteSignOrderAsync(orderId)));

        await Task.WhenAll(tasks);
    }


}