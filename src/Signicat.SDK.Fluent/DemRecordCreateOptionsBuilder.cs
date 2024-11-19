using System.Runtime.CompilerServices;
using Signicat.DigitalEvidenceManagement.Entities;

[assembly: InternalsVisibleTo("Signicat.SDK.Tests")]
[assembly: InternalsVisibleTo("Signicat.SDK.Internal")]

namespace Signicat;

public class DemRecordCreateOptionsBuilder
{
    private readonly DemRecordCreateOptions _options = new();

    public static DemRecordCreateOptionsBuilder Create()
    {
        return new DemRecordCreateOptionsBuilder();
    }

    /// <summary>
    ///     You are required to supply a record type in the 'type' parameter when posting a new record.
    /// </summary>
    /// <param name="type">One of: <c>GDPR</c>, <c>TRANSACTION</c>, <c>LOG_IN</c>, <c>SIGNATURE</c> or <c>OTHER</c>.</param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithType(RecordTypes type)
    {
        _options.Type = type;
        return this;
    }

    /// <summary>
    ///     Time to Live as denoted in amount of days. Required to set
    /// </summary>
    /// <param name="days">Number of days</param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithTimeToLiveInDays(int days)
    {
        _options.TimeToLiveInDays = days;
        return this;
    }

    /// <summary>
    ///     Optional field.
    ///     Decides which level of timestamping and verification will be applied to the record. The different levels have
    ///     different pricing.
    /// </summary>
    /// <param name="level">One of: <c>SIMPLE</c>, <c>ADVANCED</c> or <c>QUALIFIED</c>. Default is <c>QUALIFIED</c></param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithAuditLevel(AuditLevels level)
    {
        _options.AuditLevel = level;
        return this;
    }

    /// <summary>
    ///     Can contain any amount of data which will then be searchable in future queries.
    /// </summary>
    /// <param name="metadata">MetaData in form of a key/value</param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithMetaData(Dictionary<string, object> metadata)
    {
        _options.Metadata = metadata;
        return this;
    }

    /// <summary>
    ///     Can contain any amount of data which will then be timestamped.
    /// </summary>
    /// <param name="coreData">Coredata in form of a key/value</param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithCoreData(Dictionary<string, object> coreData)
    {
        _options.CoreData = coreData;
        return this;
    }

    /// <summary>
    ///     Optional field. List of the IDs (String) of the related records. Default: Empty list
    /// </summary>
    /// <param name="relations">One of more related Id of records</param>
    /// <returns></returns>
    public DemRecordCreateOptionsBuilder WithRelations(params string[] relations)
    {
        _options.Relations = relations;
        return this;
    }

    /// <summary>
    ///     Builds the authentication request after all properties are set
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public DemRecordCreateOptions Build()
    {
        if (_options.Type is null)
        {
            throw new ValidationException("RecordType must be set");
        }

        if (_options.CoreData is null || !_options.CoreData.Any())
        {
            throw new ValidationException("Core data must contain minimum one property");
        }

        return _options;
    }

    internal DemRecordCreateOptions BuildWithOutValidation()
    {
        return _options;
    }
}