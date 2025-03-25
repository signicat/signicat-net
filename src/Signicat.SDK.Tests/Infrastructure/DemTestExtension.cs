using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.SDK.Tests
{
    public static class DemTestExtension
    {
        internal static bool IsTheSame(this DemRecordCreateOptions options, DemRecord record)
        {
            if (!options.Type.Equals(record.RecordType))
            {
                return false;
            }

            if (!options.AuditLevel.Equals(record.AuditLevels))
            {
                return false;
            }

            if (options.Metadata != null)
            {
                foreach (var item in options.Metadata)
                {
                    if (!record.Metadata.ContainsKey(item.Key))
                    {
                        return false;
                    }

                    if (item.Value is not object)
                    {
                        if (!item.Value.Equals(options.Metadata[item.Key]))
                        {
                            return false;
                        }
                    }
                }
            }

            foreach (var item in options.CoreData)
            {
                if (!record.CoreData.ContainsKey(item.Key))
                {
                    return false;
                }

                if (item.Value is not object)
                {
                    if (!item.Value.Equals(options.CoreData[item.Key]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}