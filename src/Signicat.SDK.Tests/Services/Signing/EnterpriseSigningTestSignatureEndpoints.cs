using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Infrastructure;
using Signicat.Services.Signing.Enterprise;
using Signicat.Services.Signing.Enterprise.Entities;


namespace Signicat.SDK.Tests.Signing;

public class EnterpriseSigningTestSignatureEndpoints : BaseTest
{
    private IEnterpriseSignatureService _service;

    [SetUp]
    public void Setup()
    {
        _service = new EnterpriseSignatureService();
    }
    
    [Test]
    public async Task TestCreateSigninOrder() {

        try
        {
            var fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
            var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);

            Guid taskId = Guid.NewGuid(), packagingTaskId = Guid.NewGuid();

            var documents = new List<TaskDocument>()
            {
                new TaskDocument()
                {
                    Action = DocumentAction.SIGN,
                    Description = "Document description: Nice document to sign",
                    DocumentRef = documentId.DocumentId,
                    Source = DocumentSource.SESSION,
                    ExternalReference = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    SendResultToArchive = true,

                }
            };

            Console.WriteLine("TaskId: {0}", taskId);
            Console.WriteLine("PackagingTaskId: {0}", packagingTaskId);
            Console.WriteLine("DocumentId: {0}", documents[0].Id);

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
                        Authentication = new Services.Signing.Enterprise.Entities.Authentication()
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
                                Recipient = "runsyn@signicat.com",
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

            Console.WriteLine(response.Id);
            var taskResponseInfo = await _service.GetTaskStatusAsync(response.Id, taskId);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(taskResponseInfo));
            //Console.WriteLine("----------------------------------");

            //File.WriteAllBytes("signedDocument.pdf",await signatureService.GetSignedDocument(response.Id,taskId, documents[0].Id));
            Console.WriteLine("Downloading result");
            var packageResult = await _service.GetPackagedTaskResultAsync(response.Id, packagingTaskId);
            using (var ms = new MemoryStream())
            {
                packageResult.CopyTo(ms);
                File.WriteAllBytes(@"packagedResult.pdf", ms.ToArray());
            }


        }
        catch (SignicatException e)
        {
            Console.WriteLine(e.Message);
            foreach (var validationError in e.Error?.ValidationErrors ?? Array.Empty<ValidationError>())
            {
                Console.WriteLine($"{validationError.PropertyName}: {validationError.Reason}");
            }

            throw;
        }
    }
    
    [Test]
    public async Task TestCreateSigningOrderInvalidMapErrorCorrect()
    {

        var ex = Assert.ThrowsAsync<SignicatException>(async () =>
        {
            var fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
            var documentId = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);

            Guid taskId = Guid.NewGuid(), packagingTaskId = Guid.NewGuid();

            var documents = new List<TaskDocument>()
            {
                new TaskDocument()
                {
                    Action = DocumentAction.SIGN,
                    Description = "Document description: Nice document to sign",
                    DocumentRef = documentId.DocumentId,
                    Source = DocumentSource.SESSION,
                    ExternalReference = Guid.NewGuid(),
                    Id = Guid.NewGuid(),
                    SendResultToArchive = true,

                }
            };

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
                        Authentication = new Services.Signing.Enterprise.Entities.Authentication()
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
                                Recipient = "runsyn@signicat.com",
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

  
}