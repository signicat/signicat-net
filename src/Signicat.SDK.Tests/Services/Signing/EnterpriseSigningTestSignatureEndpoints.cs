using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Services.Signing.Enterprise;
using Signicat.Services.Signing.Enterprise.Entities;

namespace Signicat.SDK.Tests.Services.Signing;

public class EnterpriseSigningTestSignatureEndpoints : BaseTest
{
    private IEnterpriseSignatureService _service;
    private Guid _taskId, _packagingTaskId;
    private readonly byte[] _fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
    private List<TaskDocument> _documents;
    private SigningOrderCreateOptions _validSignRequest;
    private readonly HashSet<string> _documentIds = new HashSet<string>(), _signOrderIds = new HashSet<string>();

    [SetUp]
    public void Setup()
    {
        _service = new EnterpriseSignatureService();
        _taskId = Guid.NewGuid();
        _packagingTaskId = Guid.NewGuid();

        Console.WriteLine("TaskId: {0}", _taskId);
        Console.WriteLine("PackagingTaskId: {0}", _packagingTaskId);

        _documents = new List<TaskDocument>()
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

        Console.WriteLine("DocumentId: {0}", _documents[0].Id);

        _validSignRequest = new SigningOrderCreateOptions()
        {
            ClientReference = Guid.NewGuid(),
            DaysUntilDeletion = 1,

            Tasks = new List<SignatureTask>()
            {
                new SignatureTask()
                {
                    Id = _taskId,
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
                    Language = "en",
                    Documents = _documents,
                    DaysToLive = 1,
                    OnTaskComplete = "https://signicat.com#success",
                    OnTaskReject = "httsp://signicat.com#reject",
                    OnTaskPostpone = "https://signicat.com#postpone",
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
                    Id = _packagingTaskId,
                    Method = "pades",
                    Documents = new List<PackagingTaskDocument>()
                    {
                        new PackagingTaskDocument()
                        {
                            TaskId = _taskId,
                            DocumentIds = new List<string>()
                            {
                                _documents[0].Id.ToString()
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

        var documentId = _service.UploadSessionDocument("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;


        var response = _service.Create(_validSignRequest);
        Assert.IsNotEmpty(response.Id);
        _signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);

    }

    [Test]
    public async Task TestCreateSigninOrderSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;

        var response = await _service.CreateAsync(_validSignRequest);

        Assert.IsNotEmpty(response.Id);
        _signOrderIds.Add(response.Id);
    }

    [Test]
    public void TestGetTaskStatusSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;


        var response = _service.Create(_validSignRequest);

        Assert.IsNotNull(response.Id);
        _signOrderIds.Add(response.Id);
        Console.WriteLine(response.Id);
        var taskResponseInfo = _service.GetTaskStatus(response.Id, _taskId);

        Assert.IsNotNull(taskResponseInfo);

        Assert.That(taskResponseInfo.TaskId, Is.EqualTo(_taskId));

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(taskResponseInfo));

    }

    [Test]
    public async Task TestGetTaskStatusSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;


        var response = await _service.CreateAsync(_validSignRequest);
        Assert.IsNotNull(response.Id);
        _signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);
        var taskResponseInfo = await _service.GetTaskStatusAsync(response.Id, _taskId);

        Assert.IsNotNull(taskResponseInfo);

        Assert.That(taskResponseInfo.TaskId, Is.EqualTo(_taskId));

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(taskResponseInfo));

    }

    [Test]
    public void TestGetGetOrderSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;

        Console.WriteLine(_taskId);
        var response = _service.Create(_validSignRequest);
        Assert.IsNotNull(response.Id);
        _signOrderIds.Add(response.Id);
        
        Console.WriteLine(response.Id);
        var order = _service.GetOrder(response.Id);

        Assert.IsNotNull(order);

        Assert.That(order.Id, Is.EqualTo(response.Id));
        Assert.That(order.Tasks.First().Id, Is.EqualTo(_validSignRequest.Tasks.First().Id));
    }

    [Test]
    public async Task TestGetGetOrderSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;


        var response = await _service.CreateAsync(_validSignRequest);
        Assert.IsNotNull(response.Id);
        _signOrderIds.Add(response.Id);
        Console.WriteLine(response.Id);
        
        var order = await _service.GetOrderAsync(response.Id);

        Assert.IsNotNull(order);

        Assert.That(order.Id, Is.EqualTo(response.Id));
        Assert.That(order.Tasks.First().Id, Is.EqualTo(_validSignRequest.Tasks.First().Id));

    }


    [Test]
    public void TestGetTaskEventsSuccess()
    {

        var documentId = _service.UploadSessionDocument("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;

        Console.WriteLine(_taskId);
        var response = _service.Create(_validSignRequest);
        Assert.IsNotNull(response.Id);
        _signOrderIds.Add(response.Id);
        
        
        var taskEvents = _service.GetTaskEvents(response.Id, _taskId);
        Assert.IsNotNull(taskEvents);
        // ReSharper disable once PossibleMultipleEnumeration
        Assert.AreEqual(2, taskEvents.Count());
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(taskEvents));
    }



    [Test]
    public async Task TestGetTaskEventsSuccessAsync()
    {

        var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
        Assert.IsNotNull(documentId);
        _documentIds.Add(documentId.DocumentId);
        _documents.First().DocumentRef = documentId.DocumentId;
        
        var response = await _service.CreateAsync(_validSignRequest);
        Assert.IsNotNull(response.Id);
        Console.WriteLine(response.Id);
        _signOrderIds.Add(response.Id);
        
        var taskEvents = await _service.GetTaskEventsAsync(response.Id, _taskId);
        Assert.IsNotNull(taskEvents);
        Assert.AreEqual(2, taskEvents.Count());

    }

    [Test]
    public void TestDeleterSignOrderSuccess()
    {

        var document = _service.UploadSessionDocument("dummy.pdf", _fileData);
        Assert.IsNotNull(document);
        _documentIds.Add(document.DocumentId);
        _documents.First().DocumentRef = document.DocumentId;

        Console.WriteLine(_taskId);
        var response = _service.Create(_validSignRequest);
        Assert.IsNotNull(response.Id);
        _service.DeleteSignOrder(response.Id);


    }

    [Test]
    public async Task TestDeleteSignOrderSuccessAsync()
    {

        var document = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
        Assert.IsNotNull(document);
        _documentIds.Add(document.DocumentId);
        _documents.First().DocumentRef = document.DocumentId;


        var response = await _service.CreateAsync(_validSignRequest);

        Assert.IsNotNull(response.Id);
        await _service.DeleteSignOrderAsync(response.Id);

    }
    

    [Test]
    public void TestCreateSigningOrderInvalidMapErrorCorrect()
    {

        var ex = Assert.ThrowsAsync<SignicatException>(async () =>
        {
            var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", _fileData);
            _documents.First().DocumentRef = documentId.DocumentId;
            _documentIds.Add(documentId.DocumentId);

            await _service.CreateAsync(new SigningOrderCreateOptions()
            {
                ClientReference = Guid.NewGuid(),
                DaysUntilDeletion = 1,

                Tasks = new List<SignatureTask>()
                {
                    new SignatureTask()
                    {
                        Id = _taskId,
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
                        Documents = _documents,
                        DaysToLive = 1,
                        OnTaskComplete = "https://signicat.com#success",
                        OnTaskReject = "https://signicat.com#reject",
                        OnTaskPostpone = "https://signicat.com#postpone",
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
                        Id = _packagingTaskId,
                        Method = "pades",
                        Documents = new List<PackagingTaskDocument>()
                        {
                            new PackagingTaskDocument()
                            {
                                TaskId = _taskId,
                                DocumentIds = new List<string>()
                                {
                                    _documents[0].Id.ToString()
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

        Assert.That(ex, Is.Not.Null);
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
        List<Task> tasks = _documentIds.Select(documentId => _service.DeleteDocumentAsync(documentId)).ToList();
        tasks.AddRange(_signOrderIds.Select(orderId => _service.DeleteSignOrderAsync(orderId)));

        await Task.WhenAll(tasks);
    }


}