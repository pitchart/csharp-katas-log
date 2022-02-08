namespace Approval.Shared.SalesForce.Templating
{
    public record Template(
        DocumentType DocumentType,
        SfRecordType RecordType,
        string TemplateId,
        string TemplateFile)
    {
        public static IEnumerable<Template> TemplateMappings() => new[]
        {
            new Template(DocumentType.DEER, SfRecordType.INDIVIDUAL_PROSPECT, "DEERPP", "DEERPP.ftl"),
            new Template(DocumentType.DEER, SfRecordType.LEGAL_PROSPECT, "DEERPM", "DEERPM.ftl"),
            new Template(DocumentType.AUTP, SfRecordType.INDIVIDUAL_PROSPECT, "FSI1LSCI_CBS", "AUTP.ftl"),
            new Template(DocumentType.AUTM, SfRecordType.LEGAL_PROSPECT, "FSI1LSCE_CBS", "AUTM.ftl"),
            new Template(DocumentType.SPEC, SfRecordType.ALL, "SIGNSPEC", "SPEC.ftl"),
            new Template(DocumentType.GLPP, SfRecordType.INDIVIDUAL_PROSPECT, "GUIDEPP", "GLPP.ftl"),
            new Template(DocumentType.GLPM, SfRecordType.LEGAL_PROSPECT, "GUIDEPM", "GLPM.ftl")
        };

        public static Template FindTemplateFor(string documentType, string recordType)
        {
            foreach (var dtt in TemplateMappings())
            {
                if (dtt.DocumentType.ToString().Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
                    dtt.RecordType.ToString().Equals(recordType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dtt;
                }
                else if (dtt.DocumentType.ToString()
                             .Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
                         dtt.RecordType.ToString().Equals("ALL"))
                {
                    return dtt;
                }
            }

            throw new ArgumentException("Invalid Document template type or record type");
        }
    }
}
