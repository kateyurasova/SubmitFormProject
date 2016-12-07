
namespace FormSite.API
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]

    public partial class fs_response
    {

        private string total_resultsField;

        private fs_responseHeadingsHeading[] headingsField;

        private fs_responseResultsResult[] resultsField;

        private string statusField;

        private string timestampField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string total_results
        {
            get { return this.total_resultsField; }
            set { this.total_resultsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("heading", typeof(fs_responseHeadingsHeading),
             Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public fs_responseHeadingsHeading[] headings
        {
            get { return this.headingsField; }
            set { this.headingsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("result", typeof(fs_responseResultsResult),
             Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public fs_responseResultsResult[] results
        {
            get { return this.resultsField; }
            set { this.resultsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get { return this.statusField; }
            set { this.statusField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fs_responseHeadingsHeading
    {

        private string forField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @for
        {
            get { return this.forField; }
            set { this.forField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fs_responseResultsResult
    {

        private fs_responseResultsResultMetasMeta[] metasField;

        private fs_responseResultsResultItemsItem[] itemsField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("meta", typeof(fs_responseResultsResultMetasMeta),
             Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public fs_responseResultsResultMetasMeta[] metas
        {
            get { return this.metasField; }
            set { this.metasField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", typeof(fs_responseResultsResultItemsItem),
             Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public fs_responseResultsResultItemsItem[] items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fs_responseResultsResultMetasMeta
    {

        private string idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fs_responseResultsResultItemsItem
    {

        private string valueField;

        private string idField;

        private string indexField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string index
        {
            get { return this.indexField; }
            set { this.indexField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private fs_response[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("fs_response")]
        public fs_response[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }
    }
}
